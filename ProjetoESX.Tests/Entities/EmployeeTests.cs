using ProjetoESX.Domain.Entities;
using ProjetoESX.Domain.ValueObjetcs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjetoESX.Tests.Entities
{
    [TestClass]
    public class EmployeeTests
    {
        private Email _email;
        private Employee _employee;

        public EmployeeTests()
        {
            _email = new Email("lucas@datavale.com");
        }

        [TestMethod]
        public void ShouldCreateEmployeeWhenValid()
        {
            _employee = new Employee("Lucas", _email, 4000);
            Assert.AreEqual(true, _employee.Valid);
        }

        [TestMethod]
        public void ShouldReturnTax0PercentWhenGrossSalaryIs2000()
        {
            _employee = new Employee("Lucas", _email, 2000);
            Assert.AreEqual(_employee.Tax, 0);
        }

        [TestMethod]
        public void ShouldReturnTax10PercentWhenGrossSalaryIs4000()
        {
            _employee = new Employee("Lucas", _email, 4000);
            Assert.AreEqual(_employee.Tax, 10);
        }

        [TestMethod]
        public void ShouldReturnTax15PercentWhenGrossSalaryIs6000()
        {
            _employee = new Employee("Lucas", _email, 6000);
            Assert.AreEqual(_employee.Tax, 15);
        }

        [TestMethod]
        public void ShouldReturnTax25PercentWhenGrossSalaryIs8000()
        {
            _employee = new Employee("Lucas", _email, 8000);
            Assert.AreEqual(_employee.Tax, 25);
        }

        [TestMethod]
        public void ShouldReturnNetSalary3600WhenGrossSalaryIs4000()
        {
            _employee = new Employee("Lucas", _email, 4000);
            Assert.AreEqual(_employee.NetSalary, 3600);
        }
    }
}
