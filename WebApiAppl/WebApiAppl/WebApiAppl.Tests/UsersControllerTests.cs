using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiAppl.Controllers;
using System.Linq;
using WebApiAppl.Models;
using System.Web.Http.Results;
using WebApiAppl.EF;

namespace WebApiAppl.Tests
{
    [TestClass]
    public class UsersControllerTests
    {
        private UsersController controller;

        [TestInitialize]
        public void Setup()
        {
            string root = Environment.CurrentDirectory;
            root = root.Replace(@".Tests\bin\Debug", @"\App_Data");
            AppDomain.CurrentDomain.SetData("DataDirectory", root);

            controller = new UsersController();
        }

        [TestMethod]
        public void GetPosition()
        {
            // Act
            var result = controller.GetPosition(1) as OkNegotiatedContentResult<string>;

            // Assert
            Assert.IsNotNull(result, "User not found.");
            Assert.AreEqual("manager", result.Content);
        }

        [TestMethod]
        public void AddUser()
        {
            // Arrange
            Guid testEmail = Guid.NewGuid();
            User testUser = new User
            {
                PositionId = 1,
                Name = "TestUser",
                SecondName = "TestUser",
                Email = testEmail.ToString() + "@gmail.com",
                PhoneNumber = "(000) 888-88-88",
                Address = "Earth"
            };

            // Act
            var result = controller.AddUser(testUser) as OkResult;

            // Assert
            Assert.IsNotNull(result, "User not added.");
            Assert.AreEqual("System.Web.Http.Results.OkResult", result.ToString());
        }

        [TestMethod]
        public void GetUsers()
        {
            // Arrange
            Context db = new Context();
            var usersCheck = db.Users.ToList();

            // Act
            var users = controller.GetUsers().UsersAll.ToList();
            // Assert
            Assert.IsNotNull(users, "User's list is empty.");
            Assert.AreEqual(usersCheck.Count, users.Count);
        }
    }
}
