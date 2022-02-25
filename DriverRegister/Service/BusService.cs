using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriverRegister.Database;
using DriverRegister.Entities;
using DriverRegister.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DriverRegister.Service
{
    public class BusService:IBusService
    {
        private readonly AppDbContext _dbContext;
        
        public BusService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<BusEntity> GetById(int id)
        {
            var bus = await _dbContext.Buses.FirstOrDefaultAsync(e => e.IdBus == id);
            return bus;
        }

        public async Task<IEnumerable<BusEntity>> GetAll()
        {
            var buses =await _dbContext.Buses.ToListAsync();
            return buses;
        }

        public async Task Create(BusModel busModel)
        {
            var bus = new BusEntity()
            {
                IdBus = busModel.Id,
                NumerLini = busModel.NumerLini, 
                PhotoURL= busModel.PhotoURL,
            };
            await _dbContext.Buses.AddAsync(bus);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var bus = await _dbContext.Buses.FirstOrDefaultAsync(b => b.IdBus == id);
            _dbContext.Buses.Remove(bus);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(BusModel busModel)
        {
            var bus =  await _dbContext.Buses.FirstOrDefaultAsync(e => e.IdBus == busModel.Id);
            if (bus != null)
            {
                bus.NumerLini = busModel.NumerLini;
                bus.PhotoURL = busModel.PhotoURL;
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}