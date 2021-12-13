using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterLoginAPI.Business.Commands.LoginType;

namespace Test.Unit.LoginType
{
    [TestClass]
    public class Delete_LoginTypeUnitTest
    {
        [TestMethod]
        public void Delete_invalid_login_type()
        {
            //Arrange
            int idDelete = -1;

            var command = new DeleteLoginTypeCommand(idDelete);

            //Act
            command.Validate();

            //Assert
            Assert.IsFalse(command.IsValid);
        }
    }
}