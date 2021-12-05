using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegisterLoginAPI.Business.Commands;

namespace Test.Unit.RegisterLogin
{
    [TestClass]
    public class InsertRegisterLoginUnitTest
    {
        [TestMethod]
        public void insert_valid_register_login()
        {
            //Arrange
            var nameRegisterLogin = "Register Test";
            var observation = "observation of register";
            var pass = "123456";
            var loginType = 1;

            var command = new CreateRegisterLoginCommand(
                nameRegisterLogin,
                pass,
                observation,
                loginType);

            //Act
            command.Validate();

            //Assert
            Assert.IsTrue(command.IsValid);
        }

        [TestMethod]
        public void insert_invalid_register_login_name_greater_50_characters()
        {
            //Arrange
            var nameRegisterLogin = "Name test with more than 50 characters!!!!!!!!!!!!!";
            var observation = "observation of register";
            var pass = "123456";
            var loginType = 1;

            var command = new CreateRegisterLoginCommand(
                nameRegisterLogin,
                pass,
                observation,
                loginType);

            //Act
            command.Validate();

            //Assert
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        public void insert_invalid_register_login_password_null()
        {
            //Arrange
            var nameRegisterLogin = "Name test";
            var observation = "observation of register";
            string pass = null;
            var loginType = 1;

            var command = new CreateRegisterLoginCommand(
                nameRegisterLogin,
                pass,
                observation,
                loginType);

            //Act
            command.Validate();

            //Assert
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        public void insert_invalid_register_login_type_zero()
        {
            //Arrange
            var nameRegisterLogin = "test name";
            var observation = "observation of register";
            var pass = "123456";
            var loginType = 0;

            var command = new CreateRegisterLoginCommand(
                nameRegisterLogin,
                pass,
                observation,
                loginType);

            //Act
            command.Validate();

            //Assert
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        public void insert_invalid_register_name_null()
        {
            //Arrange
            string nameRegisterLogin = null;
            var observation = "observation of register";
            var pass = "123456";
            var loginType = 1;

            var command = new CreateRegisterLoginCommand(
                nameRegisterLogin,
                pass,
                observation,
                loginType);

            //Act
            command.Validate();

            //Assert
            Assert.IsFalse(command.IsValid);
        }
    }
}