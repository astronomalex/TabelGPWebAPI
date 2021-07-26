using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TabelGPWebAPI.DTOs;

namespace TabelGPWebAPI.interfaces
{
    public interface INormsRepository
    {
        Task<Dictionary<string, List<NormsDto>>> GetNormsByUsernameAsync(string username);
        Task<int> SaveNormsAsync(Dictionary<string, List<NormsDto>> dictNorms, string userName);
    }
}