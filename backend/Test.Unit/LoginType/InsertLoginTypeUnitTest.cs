using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterLoginAPI.Business.Commands;

namespace Test.Unit
{
    [TestClass]
    public class InsertLoginTypeUnitTest
    {
        [TestMethod]
        public void insert_valid_login_type()
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
        public void insert_invalid_login_type_with_more_50_characters()
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
        public void insert_invalid_login_type_without_name()
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