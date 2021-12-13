using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterLoginAPI.Business.Commands.LoginType;

namespace Test.Unit.LoginType
{
    [TestClass]
    public class UpdateLoginTypeUnitTest
    {
        [TestMethod]
        public void Update_valid_login_type()
        {
            //Arrange
            var idLoginType = 1;
            var nameOfLoginType = "Name test";
            var command = new UpdateLoginTypeCommand(idLoginType, nameOfLoginType);

            //Action
            command.Validate();

            // Assert
            Assert.IsTrue(command.IsValid);
        }

        [TestMethod]
        public void Update_login_type_invalid_id()
        {
            //Arrange
            var idLoginType = -1;
            var nameOfLoginType = "Name test";
            var command = new UpdateLoginTypeCommand(idLoginType, nameOfLoginType);

            //Action
            command.Validate();

            // Assert
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        public void Update_login_type_with_name_more_than_50_characters()
        {
            //Arrange
            var idLoginType = 1;
            var nameOfLoginType = "Update name of test with more than 50 characters!!!!!!!!!!!!!";
            var command = new UpdateLoginTypeCommand(idLoginType, nameOfLoginType);

            //Action
            command.Validate();

            // Assert
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        public void Update_login_type_without_name()
        {
            //Arrange
            var idLoginType = 1;
            string nameOfLoginType = null;
            var command = new UpdateLoginTypeCommand(idLoginType, nameOfLoginType);

            //Action
            command.Validate();

            // Assert
            Assert.IsFalse(command.IsValid);
        }
    }
}