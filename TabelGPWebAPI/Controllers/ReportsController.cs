using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TabelGPWebAPI.DTOs;
using TabelGPWebAPI.Extensions;
using TabelGPWebAPI.interfaces;

namespace TabelGPWebAPI.Controllers
{
    [Authorize]
    public class ReportsController : BaseApiController
    {
        private readonly IReportsRepository _reportsRepository;

        public ReportsController(IReportsRepository reportsRepository)
        {
            _reportsRepository = reportsRepository;
        }

        [HttpPost]
        public async Task<ActionResult> SaveReports(ICollection<ReportDto> reportDtos)
        {
            var username = User.GetUsername();
            return Ok(await _reportsRepository.SaveReportsAsync(reportDtos, username));
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ReportDto>>> GetReports()
        {
            return Ok(await _reportsRepository.GetReportsByUsername(User.GetUsername()));
        }
    }
}