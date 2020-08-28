using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TruckDream.Domain.Data;
using TruckDream.Domain.Entities;

namespace TruckDream.Tests.Mocks
{
    [TestClass]
    public class ServicesMock
    {
        protected readonly TruckDreamDbContext dbContext;

        public ServicesMock()
        {
            var _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();

            var options = new DbContextOptionsBuilder<TruckDreamDbContext>()
                    .UseSqlite(_connection)
                    .Options;

            dbContext = new TruckDreamDbContext(options);
            dbContext.Database.EnsureCreated();
        }

        protected Truck CreateTruck(bool attached = true)
        {
            var truck = new Truck { ProductionYear = 2020, ModelYear = 2020 };
            truck.Model = new Model { Id = 1, Acronym = "XH", Name = "Extra Heavy / Extra Pesado" };
            if (attached)
            {
                dbContext.Attach(truck.Model);
                dbContext.AddAsync(truck);
                dbContext.SaveChangesAsync();
            }
            return truck;
        }
    }
}
