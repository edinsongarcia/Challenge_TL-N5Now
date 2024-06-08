using ChallengeN5Now.API.Controllers;
using ChallengeN5Now.Business.Permissions.Methods;
using ChallengeN5Now.Business.Permissions.Queries;
using ChallengeN5Now.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace ChallengeN5Now.Tests
{
    public class UnitTest
    {
        private Mock<IMediator> _mediator;
        private PermissionsController _permissionController;

        [SetUp]
        public void Setup()
        {
            _mediator = new Mock<IMediator>();
            _permissionController = new PermissionsController(_mediator.Object);
        }

        [Test]
        public async Task GetPermissions()
        {
            var data = new List<Permission>
            {
                new() {
                    EmployeeId = 1,
                    PermissionTypeId = 1,
                    CreatedDate = DateTime.Now,
                },
            };

            _mediator.Setup(m => m.Send(It.IsAny<GetAllPermissions>(), default)).ReturnsAsync(data);
            var result = await _permissionController.GetAllPermissions();
            Assert.That(result, Is.Not.Null);
            var dataResult = ((OkObjectResult)result).Value as IEnumerable<Permission>;
            CollectionAssert.AreEqual(data, dataResult);
        }

        [Test]
        public async Task RequestPermission()
        {
            var data = new CreatePermission() { EmployeeId = 1, PermissionTypeId = 1 };
            _mediator.Setup(m => m.Send(It.IsAny<CreatePermission>(), default));
            var result = await _permissionController.Create(data);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<CreatedResult>());
        }

        [Test]
        public async Task ModifyPermission()
        {
            var data = new UpdatePermission() { Id = 1, EmployeeId = 1, PermissionTypeId = 1 };
            _mediator.Setup(m => m.Send(It.IsAny<UpdatePermission>(), default));
            var result = await _permissionController.Update(data);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }
    }
}