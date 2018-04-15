using ProjetoESX.Domain.Handlers;
using ProjetoESX.Domain.Commands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjetoESX.Tests.Commands
{
    [TestClass]
    public class EmployeeHandlerTests
    {
        private EmployeeCommand _command;
        private EmployeeHandler _handler;

        public EmployeeHandlerTests()
        {
        }

        [TestMethod]
        public void ShouldCreateEmployeeHandlerWhenValid()
        {
            _command = new EmployeeCommand
            {
                Name = "Lucas",
                Address = "lucas@email.com",
                GrossSalary = 4500
            };

            Assert.AreEqual(true, _command.Validator());

            _handler = new EmployeeHandler();
            var result = _handler.Handle(_command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, result.Success);
        }
    }
}
