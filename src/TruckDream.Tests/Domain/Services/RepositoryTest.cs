using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckDream.Domain.Entities;
using TruckDream.Domain.Services;
using TruckDream.Tests.Mocks;

namespace PollChallenge.Tests.Services
{
    [TestClass]
    public class RepositoryTest : ServicesMock
    {
        private readonly Repository repository;

        public RepositoryTest()
            => repository = new RepositoryImp(dbContext);

        [TestMethod]
        public async Task GetAsync_ShouldReturnCorrect()
        {
            // Arrange
            Truck expected = CreateTruck();

            // Act
            List<Truck> result = await repository.GetAsync<Truck>();

            // Assert
            Assert.AreEqual(expected, result.FirstOrDefault());
        }

        [TestMethod]
        public async Task GetByIdAsync_ShouldNotFind()
        {
            // Arrange
            CreateTruck();

            // Act
            Truck result = await repository.GetByIdAsync<Truck>(int.MaxValue);

            // Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public async Task GetByIdAsync_ShouldReturnCorrect()
        {
            // Arrange
            Truck expected = CreateTruck();

            // Act
            Truck result = await repository.GetByIdAsync<Truck>(expected.Id);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateException))]
        public async Task InsertAsync_ShouldNotAddWithoutRequiredProps()
        {
            // Arrange
            Truck truck = new Truck();

            // Act
            repository.InsertAsync(truck);

            // Assert
            await repository.CommitAsync();
        }

        [TestMethod]
        public async Task InsertAsync_ShouldIncrementNewId()
        {
            // Arrange
            Truck expected = CreateTruck(false);

            // Act
            repository.Attach(expected.Model);
            repository.InsertAsync(expected);
            await repository.CommitAsync();

            // Assert
            Assert.AreEqual(expected.Id, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteById_ShouldReturnExceptionIfNotFound()
        {
            // Arrange
            CreateTruck();

            // Act - Assert
            repository.DeleteById<Truck>(int.MaxValue);
        }

        [TestMethod]
        public async Task DeleteById_ShouldDelete()
        {
            // Arrange
            Truck expected = CreateTruck();

            // Act
            repository.DeleteById<Truck>(expected.Id);
            await repository.CommitAsync();
            Truck result = await repository.GetByIdAsync<Truck>(expected.Id);

            // Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateException))]
        public async Task Update_ShouldNotUpdateWithoutRequiredProps()
        {
            // Arrange
            Truck expected = CreateTruck();

            // Act
            expected.Model = null;
            repository.Update(expected);

            // Assert
            await repository.CommitAsync();
        }

        [TestMethod]
        public async Task Update_ShouldUpdate()
        {
            // Arrange
            Truck expected = CreateTruck();

            // Act
            expected.Color = "Yellow";
            repository.Update(expected);
            await repository.CommitAsync();
            Truck result = await repository.GetByIdAsync<Truck>(expected.Id);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
