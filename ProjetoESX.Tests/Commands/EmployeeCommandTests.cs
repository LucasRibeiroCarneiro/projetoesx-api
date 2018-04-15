using ProjetoESX.Domain.Commands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjetoESX.Tests.Commands
{
    [TestClass]
    public class EmployeeCommandTests
    {
        private EmployeeCommand _command;

        public EmployeeCommandTests()
        {
        }

        [TestMethod]
        public void ShouldCreateEmployeeCommandWhenValid()
        {
            _command = new EmployeeCommand
            {
                Name = "Lucas",
                Address = "lucas@email.com",
                GrossSalary = 4500
            };

            Assert.AreEqual(true, _command.Validator());
        }
    }
}
