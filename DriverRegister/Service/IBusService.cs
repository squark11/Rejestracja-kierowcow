using System.Collections.Generic;
using System.Threading.Tasks;
using DriverRegister.Entities;
using DriverRegister.Models;

namespace DriverRegister.Service
{
    public interface IBusService
    {
        Task<BusEntity> GetById(int id);
        Task<IEnumerable<BusEntity>> GetAll();
        Task Create(BusModel busModel);
        Task Remove(int id);
        Task Update(BusModel busModel);
    }
}