using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TruckDream.Domain.Entities;
using TruckDream.Domain.Services;
using TruckDream.Tests.Mocks;
using TruckDream.Web.Controllers;

namespace TruckDream.Tests.Web.Controllers
{
    [TestClass]
    public class TruckControllerTest : ServicesMock
    {
        private readonly Repository repository;
        private readonly TruckController truckController;

        public TruckControllerTest()
        {
            repository = new RepositoryImp(dbContext);
            truckController = new TruckController(repository);
        }

        [TestMethod]
        public async Task GetAll_ShouldReturnCorrectTrucks()
        {
            // Arrange
            CreateTruck();
            var expected = await repository.GetAsync<Truck>();

            // Act
            var result = await truckController.GetAll();
            var trucks = (List<Truck>)((OkObjectResult)result.Result).Value;

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            Assert.IsTrue(expected.SequenceEqual(trucks));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public async Task Insert_ShouldNotAddWithoutRequiredProps()
        {
            // Arrange
            var truck = JsonSerializer.Serialize(new Truck());

            // Act - Assert
            await truckController.Insert(truck);
        }

        [TestMethod]
        public async Task Insert_ShouldAddCorrectObject()
        {
            // Arrange
            var truckJson = JsonSerializer.Serialize(CreateTruck(false));

            // Act
            var result = await truckController.Insert(truckJson);
            var expected = ((CreatedAtActionResult)result.Result).Value;

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(CreatedAtActionResult));
            Assert.AreEqual(1, expected.GetType().GetProperty("Id").GetValue(expected));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public async Task Update_ShouldNotUpdateWithoutRequiredProps()
        {
            // Arrange
            var truck = CreateTruck();

            // Act
            truck.Model = null;
            var truckJson = JsonSerializer.Serialize(truck);

            // Assert
            await truckController.Update(truckJson);
        }

        [TestMethod]
        public async Task Update_ShouldUpdate()
        {
            // Arrange
            var expected = CreateTruck();
            repository.DetachAll();

            // Act
            expected.Color = "Yellow";
            var truckJson = JsonSerializer.Serialize(expected);
            await truckController.Update(truckJson);
            var result = await repository.GetByIdAsync<Truck>(expected.Id);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public async Task Delete_ShouldThrowsExceptionWhenNotFound()
        {
            // Arrange
            CreateTruck();

            // Act - Assert
            await truckController.Delete(int.MaxValue);
        }

        [TestMethod]
        public async Task Delete_ShouldDeleteSuccess()
        {
            // Arrange
            var expected = CreateTruck();

            // Act
            await truckController.Delete(expected.Id);
            var result = await repository.GetByIdAsync<Truck>(expected.Id);

            // Assert
            Assert.AreEqual(null, result);
        }
    }
}
