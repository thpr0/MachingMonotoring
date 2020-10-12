using System;
using System.Collections.Generic;

namespace MachineProduction.Repository.Models
{
    public partial class Machine
    {
        public Machine()
        {
            MachineProduction = new HashSet<MachineProduction>();
        }

        public int MachineId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<MachineProduction> MachineProduction { get; set; }
    }
}
