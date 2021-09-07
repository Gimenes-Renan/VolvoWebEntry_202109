using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Volvo_API.Controllers;
using Volvo_API.Models;
using Volvo_API.Repository.Context;
using Volvo_API.Services;
using Xunit;

namespace Volvo_API.UnitTests
{
    public class TruckControllerTest
    {
        private List<Truck> trucks = new List<Truck>
        {
              new Truck{
                Id = 1,
                TruckModelId = 1,
                FabricationYear = 2021,
                ModelYear = 2021
              },
              new Truck{
                            Id = 2,
                TruckModelId = 2,
                FabricationYear = 2021,
                ModelYear = 2021
              },
              new Truck{
                            Id = 3,
                TruckModelId = 1,
                FabricationYear = 2021,
                ModelYear = 2021
              },
                new Truck {
                            Id = 4,
                TruckModelId = 2,
                FabricationYear = 2021,
                ModelYear = 2021
                }
        };


        [Fact]
        public void GetAll_ShouldReturnAllTrucks()
        {
            var service = new Mock<IService<Truck>>();
            service.Setup(c => c.Get()).Returns(trucks);

            var controller = new TruckController(service.Object);

            var result = controller.Get();
            var okResult = result as OkObjectResult;

            Assert.True(okResult is OkObjectResult);
            Assert.IsType<List<Truck>>(okResult.Value);
        }

        [Fact]
        public void GetById_ShouldReturnOneTruck()
        {
            int id = 1;
            var service = new Mock<IService<Truck>>();
            service.Setup(c => c.Get(id)).Returns(trucks.Where(t => t.Id == id).FirstOrDefault());

            var controller = new TruckController(service.Object);
            var result = controller.Get(1);
            var okResult = result as OkObjectResult;

            var t = (Truck)okResult.Value;

            Assert.True(okResult is OkObjectResult);
            Assert.IsType<Truck>(okResult.Value);
            Assert.Equal(t.Id, id);
        }

        [Fact]
        public void GetById_ShouldNotReturnTruck()
        {
            int id = 999;
            var service = new Mock<IService<Truck>>();
            service.Setup(c => c.Get(id)).Returns(trucks.Where(t => t.Id == id).FirstOrDefault());

            var controller = new TruckController(service.Object);
            var result = controller.Get(999);

            Assert.Null(result);
        }

        [Fact]
        public void Post_ShouldAddOneTruck()
        {

            var service = new Mock<IService<Truck>>();
            service.Setup(c => c.Post(It.IsAny<Truck>())).Callback<Truck>(trucks.Add).Returns<Truck>(p => p);

            var controller = new TruckController(service.Object);
            var result = controller.Post(new Truck
            {
                Id = 5,
                TruckModelId = 1,
                FabricationYear = 2028,
                ModelYear = 2028
            });

            //Assert.Contains(result, trucks);
        }
    }
}
