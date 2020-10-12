using MachineProduction.Repository.Interfaces;
using MachineProduction.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineProduction.Repository
{
    public class MachineRepository : IMachineRepository
    {

        private readonly MachineMonitoringContext _context;

        public MachineRepository(MachineMonitoringContext context)
        {
            _context = context;
        }

        public IList<Machine> GetAll()
        {
            return _context.Machine.ToList();
        }

        public Machine GetMachine(int id)
        {
            return _context.Machine.FirstOrDefault(m => m.MachineId == id);
        }

        public int GetTotalProduction(int id)
        {
            return _context.MachineProduction.Where(m => m.MachineId == id).Sum(m => m.TotalProduction);
        }

        public int DeleteMachine(int id)
        {
            var machineToDelete = GetMachine(id);

            if (machineToDelete != null)
            {                
                _context.Machine.Remove(machineToDelete);

                return _context.SaveChanges();
            }

            return 0;
        }
    }
}
