using System.Collections.Generic;
using System.Threading.Tasks;
using TabelGPWebAPI.DTOs;

namespace TabelGPWebAPI.interfaces
{
    public interface INormsRepository
    {
        Task<Dictionary<string, List<NormsDto>>> GetNormsByUsernameAsync(string username);
        Task<int> SaveNormsAsync(Dictionary<string, List<NormsDto>> dictNorms, string userName);
    }
}