using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TabelGPWebAPI.DTOs;
using TabelGPWebAPI.Entities;
using TabelGPWebAPI.interfaces;
using Microsoft.AspNetCore.Http;

namespace TabelGPWebAPI.Data
{
    public class NormsRepository : INormsRepository
    {
        private readonly ApplicationContext _context;

        public NormsRepository(ApplicationContext context)
        {
            _context = context;
        }
        
        public async Task<Dictionary<string, List<NormsDto>>> GetNormsByUserAsync(string username)
        {
            var machines = await _context.Machines.ToListAsync();
            Dictionary<string, List<NormsDto>> normsDict = new Dictionary<string, List<NormsDto>>();
            foreach (var machine in machines)
            {
                AppUser user = _context.Users.First(u => u.UserName == username);
                if (user == null) return null;
                var nomrsOfMachine = _context.Norms.Where(norm =>
                    norm.Machine.MachineName == machine.MachineName && norm.UserId == user.Id);
                var normDtos = new List<NormsDto>();
                foreach (var norma in nomrsOfMachine)
                {
                    normDtos.Add(new NormsDto()
                    {
                        GrpDiff = norma.GroupDiff,
                        Norma = norma.Amount
                    });
                }
                normsDict.Add(machine.MachineName, normDtos);
                
            }
            return normsDict;
        }

        public async Task<int> SaveNorms(Dictionary<string, List<NormsDto>> dictNorms, string userName)
        {
            var user = await _context.Users.FirstAsync(u => u.UserName == userName);
            var normsByUser = _context.Norms.Where(n => n.UserId == user.Id);

            foreach (var machineName in dictNorms.Keys)
            {
                var machine = await _context.Machines.FirstOrDefaultAsync(m => m.MachineName == machineName);
                if (machine == null)
                {
                    await _context.Machines.AddAsync(new Machine()
                    {
                        MachineName = machineName
                    });
                    await _context.SaveChangesAsync();
                    machine = await _context.Machines.FirstOrDefaultAsync(m => m.MachineName == machineName);
                }
                
                foreach (var normsDto in dictNorms[machineName])
                {
                    var machineId = machine.Id;
                    var oldNorm = await _context.Norms.FirstOrDefaultAsync(n => 
                        n.GroupDiff == normsDto.GrpDiff && n.Machine.MachineName == machineName);
                    if (oldNorm != null)
                    {
                        oldNorm.Amount = normsDto.Norma;
                    }
                    else
                    {
                        await _context.Norms.AddAsync(new Norma()
                        {
                            GroupDiff = normsDto.GrpDiff,
                            UserId = user.Id,
                            User = user,
                            Amount = normsDto.Norma,
                            MachineId = machineId,
                            Machine = machine
                        });
                    }

                    await _context.SaveChangesAsync();
                }
            }
            

            return await _context.SaveChangesAsync() > 0 ? 1 : 0;
        }
    }
}