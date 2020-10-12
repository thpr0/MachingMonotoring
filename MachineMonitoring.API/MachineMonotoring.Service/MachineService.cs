using MachineMonotoring.Service.Interfaces;
using MachineProduction.Repository.Interfaces;
using MachineProduction.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineMonotoring.Service
{
    public class MachineService : IMachineService
    {

        private readonly IMachineRepository _machineRepository;

        public MachineService(IMachineRepository machineRepository)
        {
            _machineRepository = machineRepository;
        }

        public int DeleteMachine(int id)
        {
            return _machineRepository.DeleteMachine(id);
        }

        public IList<Machine> GetAll()
        {
            return _machineRepository.GetAll();
        }

        public Machine GetMachine(int id)
        {
            return _machineRepository.GetMachine(id);
        }

        public int GetTotalProduction(int id)
        {
            return _machineRepository.GetTotalProduction(id);
        }
    }
}
