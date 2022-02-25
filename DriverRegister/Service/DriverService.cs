using System.Collections.Generic;
using System.Threading.Tasks;
using DriverRegister.Database;
using DriverRegister.Entities;
using DriverRegister.Models;
using Microsoft.EntityFrameworkCore;

namespace DriverRegister.Service
{
    public class DriverService:IDriverService
    {
        private readonly AppDbContext _dbContext;
        
        public DriverService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<DriverEntity> GetById(int id)
        {
            var driver = await _dbContext.Drivers.FirstOrDefaultAsync(e => e.IdKierowcy == id);
            return driver;
        }

        public async Task<IEnumerable<DriverEntity>> GetAll()
        {
            var drivers =await _dbContext.Drivers.ToListAsync();
            return drivers;
        }

        public async Task Create(DriverModel driverModel)
        {
            var driver = new DriverEntity()
            {
                Imie = driverModel.Imie,
                Nazwisko = driverModel.Nazwisko,
                Pesel = driverModel.Pesel,
                NumerLini = driverModel.NumerLini
            };
            await _dbContext.Drivers.AddAsync(driver);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var driver = await _dbContext.Drivers.FirstOrDefaultAsync(d => d.IdKierowcy == id);
            _dbContext.Drivers.Remove(driver);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(DriverModel driverModel)
        {
            var driver =  await _dbContext.Drivers.FirstOrDefaultAsync(d => d.IdKierowcy == driverModel.IdKierowcy);
            if (driver != null)
            {
                driver.Imie = driverModel.Imie;
                driver.Nazwisko = driverModel.Nazwisko;
                driver.Pesel = driverModel.Pesel;
                driver.NumerLini = driverModel.NumerLini;
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}