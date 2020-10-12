using MachineProduction.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineProduction.Repository.Interfaces
{
    public interface IMachineRepository
    {

        IList<Machine> GetAll();

        Machine GetMachine(int id);

        int GetTotalProduction(int id);

        int DeleteMachine(int id);

    }
}
