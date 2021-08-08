using System.Collections.Generic;
using System.Threading.Tasks;
using TabelGPWebAPI.DTOs;

namespace TabelGPWebAPI.interfaces
{
    public interface IReportsRepository
    {
        Task<ICollection<ReportDto>> GetReportsByUsername(string username);
        Task<int> SaveReportsAsync(ICollection<ReportDto> reportDtos, string username);
    }
}