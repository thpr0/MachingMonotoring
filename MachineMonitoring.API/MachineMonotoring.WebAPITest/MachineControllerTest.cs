using MachineMonotoring.API.Controllers;
using MachineMonotoring.Service.Interfaces;
using MachineProduction.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MachineMonotoring.WebAPITest
{
    public class MachineControllerTest
    {
        [Fact]
        public  void TestGetMachineStatusNotFound()
        {

            var mock = new Mock<IMachineService>();
            mock.Setup(p => p.GetMachine(2)).Returns((Machine)null);
            MachineController home = new MachineController(mock.Object);
            IActionResult result = home.GetMachine(2);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public  void TestGetMachineStatusOk()
        {

            var mock = new Mock<IMachineService>();
            mock.Setup(p => p.GetMachine(1)).Returns(new Machine());
            MachineController home = new MachineController(mock.Object);
            IActionResult result = home.GetMachine(1);
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public void TestGetAllMachinesStatusNoContent()
        {

            var mock = new Mock<IMachineService>();
            mock.Setup(p => p.GetAll()).Returns(new List<Machine>()
            {                     
            });
            MachineController home = new MachineController(mock.Object);
            IActionResult result = home.GetMachines();
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void TestGetAllMachinesStatusOk()
        {

            var mock = new Mock<IMachineService>();
            mock.Setup(p => p.GetAll()).Returns(new List<Machine>()
            {
                new Machine(),new Machine()
            }) ;
            MachineController home = new MachineController(mock.Object);
            IActionResult result = home.GetMachines();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void TestGetMachinesTotalProductionStatusNotFound()
        {

            var mock = new Mock<IMachineService>();
            mock.Setup(p => p.GetMachine(1)).Returns((Machine)null);     
            
            MachineController home = new MachineController(mock.Object);
            IActionResult result = home.GetTotalProduction(1);
            Assert.IsType<NotFoundResult>(result);
        }


        [Fact]
        public void TestGetMachinesTotalProductionStatusOk()
        {

            var mock = new Mock<IMachineService>();
            mock.Setup(p => p.GetMachine(1)).Returns(new Machine());

            MachineController home = new MachineController(mock.Object);
            IActionResult result = home.GetTotalProduction(1);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void TestDeleteMachineStatusOk()
        {

            var mock = new Mock<IMachineService>();
            mock.Setup(p => p.DeleteMachine(1)).Returns(1);

            MachineController home = new MachineController(mock.Object);
            IActionResult result = home.DeleteMachine(1);
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
