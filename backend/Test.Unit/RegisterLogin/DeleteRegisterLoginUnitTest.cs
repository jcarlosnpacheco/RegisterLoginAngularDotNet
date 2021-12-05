using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterLoginAPI.Business.Commands;

namespace Test.Unit.RegisterLogin
{
    [TestClass]
    public class DeleteRegisterLoginUnitTest
    {
        [TestMethod]
        public void deletee_valid_register_login()
        {
            //Arrange
            var id = 1;

            var command = new DeleteRegisterLoginCommand(id);

            //Act
            command.Validate();

            //Assert
            Assert.IsTrue(command.IsValid);
        }

        [TestMethod]
        public void delete_invalid_register_id_zero()
        {
            //Arrange
            var id = 0;

            var command = new DeleteRegisterLoginCommand(id);

            //Act
            command.Validate();

            //Assert
            Assert.IsFalse(command.IsValid);
        }
    }
}