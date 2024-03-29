﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TabelGPWebAPI.DTOs;
using TabelGPWebAPI.Entities;
using TabelGPWebAPI.interfaces;

namespace TabelGPWebAPI.Data
{
    public class NormsRepository : INormsRepository
    {
        private readonly ApplicationContext _context;

        public NormsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Dictionary<string, List<NormsDto>>> GetNormsByUsernameAsync(string username)
        {
            var machines = await _context.Machines.ToListAsync();
            Dictionary<string, List<NormsDto>> normsDict = new Dictionary<string, List<NormsDto>>();
            AppUser user = _context.Users.First(u => u.UserName == username);
            if (user == null) return null;

            foreach (var machine in machines)
            {
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

        public async Task<int> SaveNormsAsync(Dictionary<string, List<NormsDto>> dictNorms, string userName)
        {
            var user = await _context.Users.FirstAsync(u => u.UserName == userName);
            var normsByUser = _context.Norms.Where(n => n.UserId == user.Id);
            foreach (var normaForDelete in normsByUser)
            {
                _context.Norms.Remove(normaForDelete);
            }

            foreach (var machineName in dictNorms.Keys)
            {
                var machine = await _context.Machines.FirstOrDefaultAsync(m => m.MachineName == machineName);
                if (machine == null)
                {
                    var newMachine = new Machine
                    {
                        MachineName = machineName
                    };
                    await _context.Machines.AddAsync(newMachine);
                    await _context.SaveChangesAsync();
                    machine = newMachine;
                }

                foreach (var normsDto in dictNorms[machineName])
                {
                    var machineId = machine.Id;

                    await _context.Norms.AddAsync(new Norma
                    {
                        GroupDiff = normsDto.GrpDiff,
                        UserId = user.Id,
                        User = user,
                        Amount = normsDto.Norma,
                        MachineId = machineId,
                        Machine = machine
                    });
                    //
                    //
                    // await _context.SaveChangesAsync();
                }
            }


            return await _context.SaveChangesAsync() > 0 ? 1 : 0;
        }
    }
}