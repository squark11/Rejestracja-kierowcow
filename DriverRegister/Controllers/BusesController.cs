using System.Threading.Tasks;
using DriverRegister.Models;
using DriverRegister.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DriverRegister.Controllers
{
    [Authorize]
    public class BusesController : Controller
    {
        private readonly IBusService _service;

        public BusesController(IBusService service)
        {
            _service = service;
        }
        
        
        public async Task<IActionResult> Index()
        {
            var buses = await _service.GetAll();
            return View(buses);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BusModel busModel)
        {
            if (!ModelState.IsValid) return View(busModel);
            await _service.Create(busModel);
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Update(int id)
        {
            var bus = await _service.GetById(id);
            if (bus == null) return View("Error");
            var entity = new BusModel()
            {
                Id = bus.IdBus,
                NumerLini= bus.NumerLini,
                PhotoURL = bus.PhotoURL,
            };
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, BusModel busModel)
        {
            if (id != busModel.Id) return View("Error");
            if (!ModelState.IsValid) return View(busModel);
            await _service.Update(busModel);
            return RedirectToAction("Index");
        }
        

        public async Task<IActionResult> Delete(int id)
        {
            var bus = await _service.GetById(id);
            if (bus == null) return View("Error");
            await _service.Remove(id);
            return RedirectToAction(nameof(Index));

        }
    }
}