using System;
using System.Linq;
using TabelGPWebAPI.interfaces;

namespace TabelGPWebAPI.Data
{
    public class MachinesRepository : IMachinesRepository
    {
        private readonly ApplicationContext _context;

        public MachinesRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Guid GetMachineIdByMachineName(string machineName)
        {
            var machine = _context.Machines.First(m => m.MachineName == machineName);
            if (machine == null) throw new Exception("machine is not found");
            return machine.Id;
        }
    }
}