using ProjetoESX.Domain.ValueObjetcs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjetoESX.Tests.ValueObjetcs
{
    [TestClass]
    public class EmailTests
    {
        private Email _email;

        public EmailTests()
        {            
        }

        [TestMethod]
        public void ShouldCreateEmailWhenValid()
        {
            _email = new Email("lucas@datavale.com");
            Assert.AreEqual(true, _email.Valid);
        }        
    }
}
