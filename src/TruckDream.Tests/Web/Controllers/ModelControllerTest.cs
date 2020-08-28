using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckDream.Domain.Entities;
using TruckDream.Domain.Services;
using TruckDream.Tests.Mocks;
using TruckDream.Web.Controllers;

namespace TruckDream.Tests.Web.Controllers
{
    [TestClass]
    public class ModelControllerTest : ServicesMock
    {
        private readonly Repository repository;
        private readonly ModelController modelController;

        public ModelControllerTest()
        {
            repository = new RepositoryImp(dbContext);
            modelController = new ModelController(repository);
        }

        [TestMethod]
        public async Task GetAll_ShouldReturnCorrectModels()
        {
            // Arrange
            var expected = await repository.GetAsync<Model>();

            // Act
            var result = await modelController.GetAll();
            var models = (List<Model>)((OkObjectResult)result.Result).Value;

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            Assert.IsTrue(expected.SequenceEqual(models));
        }
    }
}
