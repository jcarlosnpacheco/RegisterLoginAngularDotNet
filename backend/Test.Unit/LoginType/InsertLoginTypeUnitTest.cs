using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterLoginAPI.Business.Commands.LoginType;

namespace Test.Unit
{
    [TestClass]
    public class InsertLoginTypeUnitTest
    {
        [TestMethod]
        public void Insert_valid_login_type()
        {
            //Arrange
            var nameOfLoginType = "Name test";
            var command = new CreateLoginTypeCommand(nameOfLoginType);

            //Action
            command.Validate();

            // Assert
            Assert.IsTrue(command.IsValid);
        }

        [TestMethod]
        public void Insert_invalid_login_type_with_more_50_characters()
        {
            //Arrange
            var nameOfLoginType = "Name test with more than 50 characters!!!!!!!!!!!!!";
            var command = new CreateLoginTypeCommand(nameOfLoginType);

            //Action
            command.Validate();

            // Assert
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        public void Insert_invalid_login_type_without_name()
        {
            //Arrange
            string nameOfLoginType = null;
            var command = new CreateLoginTypeCommand(nameOfLoginType);

            //Action
            command.Validate();

            // Assert
            Assert.IsFalse(command.IsValid);
        }
    }
}