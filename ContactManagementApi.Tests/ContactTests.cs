using ContactManagementApi.Models;
using ContactManagementApi.Controllers;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagementApi.Tests {

    public class ContactTests {

        ContactController _controller;
        IRepository _service;

        public ContactTests()
        {
            _service = new MemoryRepository();
            _controller = new ContactController(_service);
        }

        [Fact]
        public void TestRetrieveContactRecord()
        {
            // Arrange
            int ContactId = 1;
            string LastName = "Robertson";
            // Act
            var result = _controller.Get(ContactId);
            // Assert
            Assert.Equal(LastName, result.LastName);
        }

    }
}
