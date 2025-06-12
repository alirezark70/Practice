using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;

namespace QueryGenereateProject
{
    // Enum ها برای انواع مختلف
    public enum JoinType
    {
        Inner,
        Left,
        Right,
        Full,
        Cross
    }

    public enum ComparisonOperator
    {
        Equals,
        NotEquals,
        GreaterThan,
        LessThan,
        GreaterThanOrEqual,
        LessThanOrEqual,
        Like,
        In,
        NotIn,
        Between,
        IsNull,
        IsNotNull
    }

    public enum LogicalOperator
    {
        And,
        Or
    }

    // کلاس اصلی Query Builder
    public class SqlQueryBuilder
    {
        private readonly StringBuilder _query;
        private readonly DynamicParameters _parameters;
        private readonly List<string> _ctes;
        private readonly List<string> _selectColumns;
        private readonly List<string> _tables;
        private readonly List<string> _joins;
        private readonly List<string> _whereConditions;
        private readonly List<string> _groupByColumns;
        private readonly List<string> _havingConditions;
        private readonly List<string> _orderByColumns;
        private int _parameterCounter;
        private int? _limit;
        private int? _offset;

        public SqlQueryBuilder()
        {
            _query = new StringBuilder();
            _parameters = new DynamicParameters();
            _ctes = new List<string>();
            _selectColumns = new List<string>();
            _tables = new List<string>();
            _joins = new List<string>();
            _whereConditions = new List<string>();
            _groupByColumns = new List<string>();
            _havingConditions = new List<string>();
            _orderByColumns = new List<string>();
            _parameterCounter = 0;
        }

        // CTE Support
        public SqlQueryBuilder WithCTE(string cteName, string cteQuery, params object[] parameters)
        {
            var formattedCte = $"{cteName} AS ({cteQuery})";
            _ctes.Add(formattedCte);

            // اضافه کردن پارامترها
            foreach (var param in parameters)
            {
                AddParameter(param);
            }

            return this;
        }

        public SqlQueryBuilder WithRecursiveCTE(string cteName, string anchorQuery, string recursiveQuery)
        {
            var cte = $"{cteName} AS ({anchorQuery} UNION ALL {recursiveQuery})";
            _ctes.Add(cte);
            return this;
        }

        // SELECT
        public SqlQueryBuilder Select(params string[] columns)
        {
            _selectColumns.AddRange(columns);
            return this;
        }

        public SqlQueryBuilder SelectDistinct(params string[] columns)
        {
            var distinctColumns = columns.Select(c => $"DISTINCT {c}");
            _selectColumns.AddRange(distinctColumns);
            return this;
        }

        public SqlQueryBuilder SelectCount(string column = "*", string alias = null)
        {
            var countExpression = string.IsNullOrEmpty(alias)
                ? $"COUNT({column})"
                : $"COUNT({column}) AS {alias}";
            _selectColumns.Add(countExpression);
            return this;
        }

        public SqlQueryBuilder SelectSum(string column, string alias = null)
        {
            var sumExpression = string.IsNullOrEmpty(alias)
                ? $"SUM({column})"
                : $"SUM({column}) AS {alias}";
            _selectColumns.Add(sumExpression);
            return this;
        }

        public SqlQueryBuilder SelectAvg(string column, string alias = null)
        {
            var avgExpression = string.IsNullOrEmpty(alias)
                ? $"AVG({column})"
                : $"AVG({column}) AS {alias}";
            _selectColumns.Add(avgExpression);
            return this;
        }

        public SqlQueryBuilder SelectMax(string column, string alias = null)
        {
            var maxExpression = string.IsNullOrEmpty(alias)
                ? $"MAX({column})"
                : $"MAX({column}) AS {alias}";
            _selectColumns.Add(maxExpression);
            return this;
        }

        public SqlQueryBuilder SelectMin(string column, string alias = null)
        {
            var minExpression = string.IsNullOrEmpty(alias)
                ? $"MIN({column})"
                : $"MIN({column}) AS {alias}";
            _selectColumns.Add(minExpression);
            return this;
        }

        // FROM
        public SqlQueryBuilder From(string table, string alias = null)
        {
            var tableExpression = string.IsNullOrEmpty(alias) ? table : $"{table} AS {alias}";
            _tables.Add(tableExpression);
            return this;
        }

        public SqlQueryBuilder FromSubQuery(SqlQueryBuilder subQuery, string alias)
        {
            var subQuerySql = subQuery.Build();
            _tables.Add($"({subQuerySql}) AS {alias}");

            // ادغام پارامترها
            foreach (var param in subQuery.GetParameters().ParameterNames)
            {
                _parameters.Add(param, subQuery.GetParameters().Get<object>(param));
            }

            return this;
        }

        // JOIN
        public SqlQueryBuilder Join(JoinType joinType, string table, string condition, string tableAlias = null)
        {
            var joinTypeStr = joinType switch
            {
                JoinType.Inner => "INNER JOIN",
                JoinType.Left => "LEFT JOIN",
                JoinType.Right => "RIGHT JOIN",
                JoinType.Full => "FULL OUTER JOIN",
                JoinType.Cross => "CROSS JOIN",
                _ => "INNER JOIN"
            };

            var tableExpression = string.IsNullOrEmpty(tableAlias) ? table : $"{table} AS {tableAlias}";
            var joinClause = $"{joinTypeStr} {tableExpression} ON {condition}";
            _joins.Add(joinClause);
            return this;
        }

        public SqlQueryBuilder InnerJoin(string table, string condition, string tableAlias = null)
        {
            return Join(JoinType.Inner, table, condition, tableAlias);
        }

        public SqlQueryBuilder LeftJoin(string table, string condition, string tableAlias = null)
        {
            return Join(JoinType.Left, table, condition, tableAlias);
        }

        public SqlQueryBuilder RightJoin(string table, string condition, string tableAlias = null)
        {
            return Join(JoinType.Right, table, condition, tableAlias);
        }

        // WHERE
        public SqlQueryBuilder Where(string column, ComparisonOperator op, object value, LogicalOperator logicalOp = LogicalOperator.And)
        {
            var condition = BuildCondition(column, op, value);

            if (_whereConditions.Any())
            {
                var logicalOpStr = logicalOp == LogicalOperator.And ? "AND" : "OR";
                _whereConditions.Add($"{logicalOpStr} {condition}");
            }
            else
            {
                _whereConditions.Add(condition);
            }

            return this;
        }

        public SqlQueryBuilder WhereIn<T>(string column, IEnumerable<T> values, LogicalOperator logicalOp = LogicalOperator.And)
        {
            if (!values.Any()) return this;

            var paramNames = new List<string>();
            foreach (var value in values)
            {
                var paramName = AddParameter(value);
                paramNames.Add($"@{paramName}");
            }

            var condition = $"{column} IN ({string.Join(", ", paramNames)})";

            if (_whereConditions.Any())
            {
                var logicalOpStr = logicalOp == LogicalOperator.And ? "AND" : "OR";
                _whereConditions.Add($"{logicalOpStr} {condition}");
            }
            else
            {
                _whereConditions.Add(condition);
            }

            return this;
        }

        public SqlQueryBuilder WhereBetween(string column, object start, object end, LogicalOperator logicalOp = LogicalOperator.And)
        {
            var startParam = AddParameter(start);
            var endParam = AddParameter(end);
            var condition = $"{column} BETWEEN @{startParam} AND @{endParam}";

            if (_whereConditions.Any())
            {
                var logicalOpStr = logicalOp == LogicalOperator.And ? "AND" : "OR";
                _whereConditions.Add($"{logicalOpStr} {condition}");
            }
            else
            {
                _whereConditions.Add(condition);
            }

            return this;
        }

        public SqlQueryBuilder WhereIsNull(string column, LogicalOperator logicalOp = LogicalOperator.And)
        {
            var condition = $"{column} IS NULL";

            if (_whereConditions.Any())
            {
                var logicalOpStr = logicalOp == LogicalOperator.And ? "AND" : "OR";
                _whereConditions.Add($"{logicalOpStr} {condition}");
            }
            else
            {
                _whereConditions.Add(condition);
            }

            return this;
        }

        public SqlQueryBuilder WhereIsNotNull(string column, LogicalOperator logicalOp = LogicalOperator.And)
        {
            var condition = $"{column} IS NOT NULL";

            if (_whereConditions.Any())
            {
                var logicalOpStr = logicalOp == LogicalOperator.And ? "AND" : "OR";
                _whereConditions.Add($"{logicalOpStr} {condition}");
            }
            else
            {
                _whereConditions.Add(condition);
            }

            return this;
        }

        public SqlQueryBuilder WhereRaw(string rawCondition, object parameters = null, LogicalOperator logicalOp = LogicalOperator.And)
        {
            if (parameters != null)
            {
                _parameters.AddDynamicParams(parameters);
            }

            if (_whereConditions.Any())
            {
                var logicalOpStr = logicalOp == LogicalOperator.And ? "AND" : "OR";
                _whereConditions.Add($"{logicalOpStr} ({rawCondition})");
            }
            else
            {
                _whereConditions.Add($"({rawCondition})");
            }

            return this;
        }

        // GROUP BY
        public SqlQueryBuilder GroupBy(params string[] columns)
        {
            _groupByColumns.AddRange(columns);
            return this;
        }

        // HAVING
        public SqlQueryBuilder Having(string condition, object parameters = null)
        {
            if (parameters != null)
            {
                _parameters.AddDynamicParams(parameters);
            }

            _havingConditions.Add(condition);
            return this;
        }

        // ORDER BY
        public SqlQueryBuilder OrderBy(string column, bool descending = false)
        {
            var orderExpression = descending ? $"{column} DESC" : $"{column} ASC";
            _orderByColumns.Add(orderExpression);
            return this;
        }

        public SqlQueryBuilder OrderByDesc(string column)
        {
            return OrderBy(column, true);
        }

        // LIMIT/OFFSET
        public SqlQueryBuilder Limit(int limit)
        {
            _limit = limit;
            return this;
        }

        public SqlQueryBuilder Offset(int offset)
        {
            _offset = offset;
            return this;
        }

        public SqlQueryBuilder Paginate(int pageNumber, int pageSize)
        {
            _offset = (pageNumber - 1) * pageSize;
            _limit = pageSize;
            return this;
        }

        // Build Query
        public string Build()
        {
            _query.Clear();

            // CTEs
            if (_ctes.Any())
            {
                _query.AppendLine($"WITH {string.Join(", ", _ctes)}");
            }

            // SELECT
            if (_selectColumns.Any())
            {
                _query.Append("SELECT ");
                _query.AppendLine(string.Join(", ", _selectColumns));
            }

            // FROM
            if (_tables.Any())
            {
                _query.Append("FROM ");
                _query.AppendLine(string.Join(", ", _tables));
            }

            // JOINS
            foreach (var join in _joins)
            {
                _query.AppendLine(join);
            }

            // WHERE
            if (_whereConditions.Any())
            {
                _query.Append("WHERE ");
                _query.AppendLine(string.Join(" ", _whereConditions));
            }

            // GROUP BY
            if (_groupByColumns.Any())
            {
                _query.Append("GROUP BY ");
                _query.AppendLine(string.Join(", ", _groupByColumns));
            }

            // HAVING
            if (_havingConditions.Any())
            {
                _query.Append("HAVING ");
                _query.AppendLine(string.Join(" AND ", _havingConditions));
            }

            // ORDER BY
            if (_orderByColumns.Any())
            {
                _query.Append("ORDER BY ");
                _query.AppendLine(string.Join(", ", _orderByColumns));
            }

            // LIMIT/OFFSET
            if (_offset.HasValue)
            {
                _query.AppendLine($"OFFSET {_offset.Value} ROWS");
            }

            if (_limit.HasValue)
            {
                _query.AppendLine($"FETCH NEXT {_limit.Value} ROWS ONLY");
            }

            return _query.ToString().Trim();
        }

        public DynamicParameters GetParameters()
        {
            return _parameters;
        }

        // Helper Methods
        private string BuildCondition(string column, ComparisonOperator op, object value)
        {
            return op switch
            {
                ComparisonOperator.Equals => $"{column} = @{AddParameter(value)}",
                ComparisonOperator.NotEquals => $"{column} <> @{AddParameter(value)}",
                ComparisonOperator.GreaterThan => $"{column} > @{AddParameter(value)}",
                ComparisonOperator.LessThan => $"{column} < @{AddParameter(value)}",
                ComparisonOperator.GreaterThanOrEqual => $"{column} >= @{AddParameter(value)}",
                ComparisonOperator.LessThanOrEqual => $"{column} <= @{AddParameter(value)}",
                ComparisonOperator.Like => $"{column} LIKE @{AddParameter(value)}",
                ComparisonOperator.IsNull => $"{column} IS NULL",
                ComparisonOperator.IsNotNull => $"{column} IS NOT NULL",
                _ => throw new NotSupportedException($"Operator {op} is not supported")
            };
        }

        private string AddParameter(object value)
        {
            var paramName = $"p{_parameterCounter++}";
            _parameters.Add(paramName, value);
            return paramName;
        }
    }

    // کلاس های کمکی برای INSERT, UPDATE, DELETE
    public class InsertQueryBuilder
    {
        private readonly string _table;
        private readonly Dictionary<string, object> _values;
        private readonly DynamicParameters _parameters;
        private int _parameterCounter;

        public InsertQueryBuilder(string table)
        {
            _table = table;
            _values = new Dictionary<string, object>();
            _parameters = new DynamicParameters();
            _parameterCounter = 0;
        }

        public InsertQueryBuilder Value(string column, object value)
        {
            _values[column] = value;
            return this;
        }

        public InsertQueryBuilder Values(object values)
        {
            var properties = values.GetType().GetProperties();
            foreach (var prop in properties)
            {
                _values[prop.Name] = prop.GetValue(values);
            }
            return this;
        }

        public string Build()
        {
            var columns = _values.Keys.ToList();
            var paramNames = new List<string>();

            foreach (var kvp in _values)
            {
                var paramName = $"p{_parameterCounter++}";
                _parameters.Add(paramName, kvp.Value);
                paramNames.Add($"@{paramName}");
            }

            var query = $"INSERT INTO {_table} ({string.Join(", ", columns)}) VALUES ({string.Join(", ", paramNames)})";
            return query;
        }

        public DynamicParameters GetParameters()
        {
            return _parameters;
        }
    }

    public class UpdateQueryBuilder
    {
        private readonly string _table;
        private readonly Dictionary<string, object> _setValues;
        private readonly List<string> _whereConditions;
        private readonly DynamicParameters _parameters;
        private int _parameterCounter;

        public UpdateQueryBuilder(string table)
        {
            _table = table;
            _setValues = new Dictionary<string, object>();
            _whereConditions = new List<string>();
            _parameters = new DynamicParameters();
            _parameterCounter = 0;
        }

        public UpdateQueryBuilder Set(string column, object value)
        {
            _setValues[column] = value;
            return this;
        }

        public UpdateQueryBuilder Where(string column, ComparisonOperator op, object value)
        {
            var paramName = $"p{_parameterCounter++}";
            _parameters.Add(paramName, value);

            var condition = op switch
            {
                ComparisonOperator.Equals => $"{column} = @{paramName}",
                ComparisonOperator.NotEquals => $"{column} <> @{paramName}",
                ComparisonOperator.GreaterThan => $"{column} > @{paramName}",
                ComparisonOperator.LessThan => $"{column} < @{paramName}",
                _ => $"{column} = @{paramName}"
            };

            _whereConditions.Add(condition);
            return this;
        }

        public string Build()
        {
            var setClauses = new List<string>();

            foreach (var kvp in _setValues)
            {
                var paramName = $"p{_parameterCounter++}";
                _parameters.Add(paramName, kvp.Value);
                setClauses.Add($"{kvp.Key} = @{paramName}");
            }

            var query = $"UPDATE {_table} SET {string.Join(", ", setClauses)}";

            if (_whereConditions.Any())
            {
                query += $" WHERE {string.Join(" AND ", _whereConditions)}";
            }

            return query;
        }

        public DynamicParameters GetParameters()
        {
            return _parameters;
        }
    }

    public class DeleteQueryBuilder
    {
        private readonly string _table;
        private readonly List<string> _whereConditions;
        private readonly DynamicParameters _parameters;
        private int _parameterCounter;

        public DeleteQueryBuilder(string table)
        {
            _table = table;
            _whereConditions = new List<string>();
            _parameters = new DynamicParameters();
            _parameterCounter = 0;
        }

        public DeleteQueryBuilder Where(string column, ComparisonOperator op, object value)
        {
            var paramName = $"p{_parameterCounter++}";
            _parameters.Add(paramName, value);

            var condition = op switch
            {
                ComparisonOperator.Equals => $"{column} = @{paramName}",
                ComparisonOperator.NotEquals => $"{column} <> @{paramName}",
                ComparisonOperator.GreaterThan => $"{column} > @{paramName}",
                ComparisonOperator.LessThan => $"{column} < @{paramName}",
                _ => $"{column} = @{paramName}"
            };

            _whereConditions.Add(condition);
            return this;
        }

        public string Build()
        {
            var query = $"DELETE FROM {_table}";

            if (_whereConditions.Any())
            {
                query += $" WHERE {string.Join(" AND ", _whereConditions)}";
            }

            return query;
        }

        public DynamicParameters GetParameters()
        {
            return _parameters;
        }
    }

    // Factory class برای سهولت استفاده
    public static class QueryBuilder
    {
        public static SqlQueryBuilder Select(params string[] columns)
        {
            return new SqlQueryBuilder().Select(columns);
        }

        public static InsertQueryBuilder InsertInto(string table)
        {
            return new InsertQueryBuilder(table);
        }

        public static UpdateQueryBuilder Update(string table)
        {
            return new UpdateQueryBuilder(table);
        }

        public static DeleteQueryBuilder DeleteFrom(string table)
        {
            return new DeleteQueryBuilder(table);
        }
    }
}
