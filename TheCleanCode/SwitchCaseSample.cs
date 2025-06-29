using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCleanCode
{
    internal class SwitchCaseSample
    {

        public void Example(EmployeeType employeeType)
        {
            var employee = EmployeeFactory.Create(employeeType);

            employee.CalculatePay();
        }
    }

    public static class EmployeeFactory
    {
        public static Employee Create(EmployeeType type)
        {
            switch (type)
            {
                case EmployeeType.CommissionedEmployee:
                    return new CommissionedEmployee();

                case EmployeeType.HourlyEmployee: 
                    return new HourlyEmployee();

                case EmployeeType.SalariedEmployee:
                    return new SalariedEmployee();


                    default:throw new Exception();
            }
        }
    }

    public enum EmployeeType
    {
        CommissionedEmployee,
        HourlyEmployee,
        SalariedEmployee
    }

    public class Money
    {

    }

    public abstract class Employee
    {
        public abstract Money CalculatePay();
        // امکان توسعه برای متدهای همسان مثل isPayday و deliverPay
    }

    public class CommissionedEmployee : Employee
    {
        public override Money CalculatePay()
        {
            return new Money();
            // محاسبات مربوط به کارمندان کمیسیون‌دار
        }
    }

    public class HourlyEmployee : Employee
    {
        public override Money CalculatePay()
        {
            return new Money();

            // محاسبات کارمندان ساعتی
        }
    }

    public class SalariedEmployee : Employee
    {
        public override Money CalculatePay()
        {
            return new Money();

            // محاسبات کارمندان حقوق‌بگیر
        }
    }
}
