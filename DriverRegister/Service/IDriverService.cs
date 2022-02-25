using DriverRegister.Entities;
using DriverRegister.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DriverRegister.Service
{
    public interface IDriverService
    {
        Task<DriverEntity> GetById(int id);
        Task<IEnumerable<DriverEntity>> GetAll();
        Task Create(DriverModel driverModel);
        Task Remove(int id);
        Task Update(DriverModel driverModel);
    }
}