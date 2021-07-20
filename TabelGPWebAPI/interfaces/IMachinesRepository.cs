using System;

namespace TabelGPWebAPI.interfaces
{
    public interface IMachinesRepository
    {
        Guid GetMachineIdByMachineName(string machineName);
    }
}