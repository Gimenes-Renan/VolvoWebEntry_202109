using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Volvo_API.Controllers;
using Volvo_API.Models;
using Volvo_API.Repository;
using Volvo_API.Repository.Context;
using Volvo_API.Services;
using Xunit;

namespace Volvo_API.UnitTests
{
    public class TruckServiceTest
    {
        private readonly Mock<DbSet<Truck>> dbSetMock;
        private readonly Mock<DatabaseContext> dbContextMock;
        private readonly Mock<IRepository<Truck>> repositoryMock;
        private readonly Mock<IService<TruckModel>> truckModelService;
        private readonly TruckService service;

        public TruckServiceTest()
        {
            dbSetMock = new Mock<DbSet<Truck>>();
            dbContextMock = new Mock<DatabaseContext>();
            repositoryMock = new Mock<IRepository<Truck>>();
            truckModelService = new Mock<IService<TruckModel>>();
            service = new TruckService(truckModelService.Object, repositoryMock.Object);
        }

        [Fact]
        public void PostServiceShouldAddAndSave()
        {
            dbContextMock.Setup(s => s.Trucks).Returns(dbSetMock.Object);
            truckModelService.Setup(x => x.Get(It.IsAny<long>())).Returns(new TruckModel { Id = 1, Model = "FM" });
            repositoryMock.Setup(x => x.Post(It.IsAny<Truck>())).Returns((Truck t) => t);

            Truck truck = new Truck { Id = 1, FabricationYear = 2021, TruckModelId = 1, ModelYear = 2021 };

            var result = service.Post(truck);

            Assert.Equal(result, truck);
        }


        [Fact]
        public void PostServiceShouldReturnInvalidModelYear()
        {
            dbContextMock.Setup(s => s.Trucks).Returns(dbSetMock.Object);

            var result = service.Post(new Truck { Id = 1, FabricationYear = 2021, TruckModelId = 1, ModelYear = 2055 });

            var exception = Assert.Throws<InvalidOperationException>(() => result);
            Assert.Equal("Invalid Model Year", exception.Message);
        }

        [Fact]
        public void PostServiceShouldReturnInvalidModelId()
        {
            dbContextMock.Setup(s => s.Trucks).Returns(dbSetMock.Object);
            truckModelService.Setup(x => x.Get(It.IsAny<long>()));

            var exception = Assert.Throws<InvalidOperationException>(() =>
                service.Post(new Truck { Id = 1, FabricationYear = 2021, TruckModelId = 3, ModelYear = 2021 }));
            Assert.Equal("Invalid Model Id", exception.Message);
        }

        [Fact]
        public void PostServiceShouldReturnInvalidModelType()
        {
            dbContextMock.Setup(s => s.Trucks).Returns(dbSetMock.Object);
            truckModelService.Setup(x => x.Get(It.IsAny<long>())).Returns(new TruckModel { Id = 3, Model = "XX" });

            var exception = Assert.Throws<InvalidOperationException>(() =>
                service.Post(new Truck { Id = 1, FabricationYear = 2021, TruckModelId = 3, ModelYear = 2021 }));
            Assert.Equal("Invalid Model Type", exception.Message);
        }
    }
}
