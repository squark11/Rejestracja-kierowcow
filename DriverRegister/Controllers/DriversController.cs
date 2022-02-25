using System.Threading.Tasks;
using DriverRegister.Entities;
using DriverRegister.Models;
using DriverRegister.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DriverRegister.Controllers
{
    [Authorize]
    public class DriversController : Controller
    {
        private readonly IDriverService _service;

        public DriversController(IDriverService service)
        {
            _service = service;
        }
        
        public async Task<IActionResult> Index()
        {
            var drivers = await _service.GetAll();
            return View(drivers);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DriverModel driverModel)
        {
            if (!ModelState.IsValid) return View(driverModel);
            await _service.Create(driverModel);
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Update(int id)
        {
            var driver = await _service.GetById(id);
            if (driver == null) return View("Error");
            var entity = new DriverModel()
            {
                IdKierowcy = driver.IdKierowcy,
                Imie= driver.Imie,
                Nazwisko = driver.Nazwisko,
                Pesel =driver.Pesel,
                NumerLini = driver.NumerLini,
            };
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, DriverModel driverModel)
        {
            if (id != driverModel.IdKierowcy) return View("Error");
            if (!ModelState.IsValid) return View(driverModel);
            await _service.Update(driverModel);
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            var driver = await _service.GetById(id);
            if (driver == null) return View("Error");
            await _service.Remove(id);
            return RedirectToAction(nameof(Index));

        }
    }
}