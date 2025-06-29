// See https://aka.ms/new-console-template for more information


using QueryGenereateProject;
using QueryGenereateProject.Models;

//var queryGe = new DataGenerator()
//{
//    FromModel = nameof(People),
//    SelectItems=new List<SelectItem> { new SelectItem(nameof(People),nameof(People.FirstName),nameof(QuerySqlModel.FirstName))
//    ,new SelectItem(nameof(People),nameof(People.LastName),nameof(QuerySqlModel.LastName))
//    ,new SelectItem(nameof(People), nameof(People.NationalCode),nameof(QuerySqlModel.NationalCode))
//    ,new SelectItem(nameof(Personel), nameof(Personel.PositionName),nameof(QuerySqlModel.PositionName))},
//    InnerJoins=new List<JoinModel> { new JoinModel(nameof(Personel),nameof(People)) },
//    LeftJoins=new List<JoinModel> { new JoinModel (nameof(Document),nameof(Personel))}
//};

//string g= queryGe.Generate();

var complexQuery = QueryBuilder
    .Select("u.Name", "u.Email", "COUNT(o.Id) AS OrderCount")
    .From("Users", "u")
    .LeftJoin("Orders", "o.UserId = u.Id", "o")
    .Where("u.IsActive", ComparisonOperator.Equals, true)
    .GroupBy("u.Name", "u.Email")
    .Having("COUNT(o.Id) > 5")
    .OrderByDesc("OrderCount")
    .Build();

var query = QueryBuilder
    .Select("Id", "Name", "Email")
    .From("Users")
    .Where("IsActive", ComparisonOperator.Equals, true)
    .OrderBy("Name")
    .Build();

//var parameters = query.GetParameters();
//// SQL: SELECT Id, Name, Email FROM Users WHERE IsActive = @p0 ORDER BY Name ASC

//// مثال 2: JOIN پیچیده
//var complexQuery = QueryBuilder
//    .Select("u.Name", "u.Email", "COUNT(o.Id) AS OrderCount")
//    .From("Users", "u")
//    .LeftJoin("Orders", "o.UserId = u.Id", "o")
//    .Where("u.IsActive", ComparisonOperator.Equals, true)
//    .GroupBy("u.Name", "u.Email")
//    .Having("COUNT(o.Id) > 5")
//    .OrderByDesc("OrderCount")
//    .Build();

//// مثال 3: استفاده از CTE
//var cteQuery = new SqlQueryBuilder()
//    .WithCTE("ActiveUsers", "SELECT * FROM Users WHERE IsActive = 1")
//    .Select("au.Name", "COUNT(o.Id) AS TotalOrders")
//    .From("ActiveUsers", "au")
//    .LeftJoin("Orders", "o.UserId = au.Id", "o")
//    .GroupBy("au.Name")
//    .Build();

//// مثال 4: SubQuery
//var subQueryBuilder = QueryBuilder
//    .Select("UserId")
//    .From("Orders")
//    .Where("OrderDate", ComparisonOperator.GreaterThan, DateTime.Now.AddDays(-30));

//var mainQuery = QueryBuilder
//    .Select("*")
//    .From("Users")
//    .WhereIn("Id", new[] { 1, 2, 3, 4, 5 })
//    .Build();

//// مثال 5: INSERT
//var insertQuery = QueryBuilder
//    .InsertInto("Users")
//    .Value("Name", "John Doe")
//    .Value("Email", "john@example.com")
//    .Value("IsActive", true)
//    .Build();

//// مثال 6: UPDATE
//var updateQuery = QueryBuilder
//    .Update("Users")
//    .Set("Name", "Jane Doe")
//    .Set("UpdatedAt", DateTime.Now)
//    .Where("Id", ComparisonOperator.Equals, 1)
//    .Build();

//// مثال 7: DELETE
//var deleteQuery = QueryBuilder
//    .DeleteFrom("Users")
//    .Where("IsActive", ComparisonOperator.Equals, false)
//    .Where("CreatedAt", ComparisonOperator.LessThan, DateTime.Now.AddYears(-1))
//    .Build();



Console.WriteLine("Hello, World!");
