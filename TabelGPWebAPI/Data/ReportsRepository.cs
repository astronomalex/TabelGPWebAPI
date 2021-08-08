using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TabelGPWebAPI.DTOs;
using TabelGPWebAPI.Entities;
using TabelGPWebAPI.interfaces;

namespace TabelGPWebAPI.Data
{
    public class ReportsRepository : IReportsRepository
    {
        private readonly ApplicationContext _context;

        public ReportsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ICollection<ReportDto>> GetReportsByUsername(string username)
        {
            var user = await GetUser(username);
            var reportsByUser = _context.Reports
                .Include(r => r.Machine)
                .Include(r => r.WorkersOfReport)
                .ThenInclude(w => w.Employee)
                .Include(r => r.WorksOfReport)
                .Where(r => r.AppUser == user);

            ICollection<ReportDto> reportDtos = new List<ReportDto>();

            foreach (var report in reportsByUser)
            {
                ICollection<WorkerReportDto> workerReportDtos = report.WorkersOfReport.Select(workerReport =>
                        new WorkerReportDto
                        {
                            Grade = workerReport.Grade.ToString(),
                            TbNum = workerReport.Employee.TabelNum
                        })
                    .ToList();

                ICollection<WorkReportDto> workReportDtos = report.WorksOfReport.Select(workReport => new WorkReportDto
                    {
                        GroupDifficulty = workReport.GroupDifficulty,
                        NameOrder = workReport.NameOrder,
                        NumOrder = workReport.NumOrder,
                        AmountDonePieces = workReport.AmountPiecesDone,
                        StartWorkTime = workReport.StartWorkTime,
                        EndWorkTime = workReport.EndWorkTime,
                        TypeWork = workReport.TypeWork
                    })
                    .ToList();

                var reportDto = new ReportDto
                {
                    Machine = report.Machine.MachineName,
                    DateReport = report.DateReport.Year + "-" + report.DateReport.Month + "-" + report.DateReport.Day,
                    NumSmenReport = report.NumShiftReport,
                    PercentOfReport = report.PercentOfReport,
                    WorkerListReport = workerReportDtos,
                    WorkListReport = workReportDtos
                };

                reportDtos.Add(reportDto);
            }

            return reportDtos;
        }

        public async Task<int> SaveReportsAsync(ICollection<ReportDto> reportDtos, string username)
        {
            var user = await GetUser(username);
            var reportsByUser = _context.Reports.Where(r => r.AppUserId == user.Id);
            _context.Reports.RemoveRange(reportsByUser);

            foreach (var reportDto in reportDtos)
            {
                var workersReport = new List<WorkerReport>();

                var worksReport = reportDto.WorkListReport.Select(workReportDto => new WorkReport
                    {
                        GroupDifficulty = workReportDto.GroupDifficulty,
                        NameOrder = workReportDto.NameOrder,
                        NumOrder = workReportDto.NumOrder,
                        TypeWork = workReportDto.TypeWork,
                        StartWorkTime = workReportDto.StartWorkTime,
                        EndWorkTime = workReportDto.EndWorkTime,
                        AmountPiecesDone = workReportDto.AmountDonePieces
                    })
                    .ToList();

                foreach (var workerReportDto in reportDto.WorkerListReport)
                {
                    var workerReport = new WorkerReport
                    {
                        Employee = _context.Employees.First(e => e.TabelNum == workerReportDto.TbNum),
                        EmployeeId = _context.Employees.First(e => e.TabelNum == workerReportDto.TbNum).Id,
                        Grade = int.Parse(workerReportDto.Grade)
                    };
                    workersReport.Add(workerReport);
                }

                var machine = _context.Machines.FirstOrDefault(m => m.MachineName == reportDto.Machine);
                if (machine == null)
                {
                    machine = new Machine
                    {
                        MachineName = reportDto.Machine
                    };
                    await _context.Machines.AddAsync(machine);
                }


                var report = new Report
                {
                    AppUser = user,
                    AppUserId = user.Id,
                    DateReport = DateTime.Parse(reportDto.DateReport),
                    Machine = machine,
                    MachineId = machine.Id,
                    NumShiftReport = reportDto.NumSmenReport,
                    PercentOfReport = reportDto.PercentOfReport,
                    WorkersOfReport = workersReport,
                    WorksOfReport = worksReport
                };

                await _context.Reports.AddAsync(report);
            }

            return await _context.SaveChangesAsync();
        }

        private async Task<AppUser> GetUser(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }
    }
}