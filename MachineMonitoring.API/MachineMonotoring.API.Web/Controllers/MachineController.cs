using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MachineMonotoring.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MachineMonotoring.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class MachineController : ControllerBase
    {

        /*
         * I Did Not use  automapper and DTOs because the return of each action is very simple
         * and no need to use them
         */
        private IMachineService _service;

        public MachineController(IMachineService service)
        {
            _service = service;
        }

        [HttpGet("Machines")]
        public IActionResult GetMachines()
        {

            var Machines = _service.GetAll();

            if (Machines.Count == 0)
            {
                return NoContent();
            }

            return Ok(
                 Machines.Select(m => new
                 {
                     m.MachineId,
                     m.Name,
                     TotalProduction = _service.GetTotalProduction(m.MachineId)
                 })
            );
        }

        [HttpGet("Machine/{id}")]
        public IActionResult GetMachine(int id)
        {

            var Machine = _service.GetMachine(id);

            if (Machine == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                Machine.MachineId,
                Machine.Name,
                Machine.Description,
            }
            );
        }

        [HttpGet("Machine/Totalproduction/{id}")]
        public IActionResult GetTotalProduction(int id)
        {

            var Machine = _service.GetMachine(id);

            if (Machine == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                totalProduction = _service.GetTotalProduction(id)
            }
            );
        }

        [HttpDelete("Machine/{id}")]
        public IActionResult DeleteMachine(int id)
        {
            var DeletedRows = _service.DeleteMachine(id);    
            return Ok(DeletedRows);
        }
    }
}