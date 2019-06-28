using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTask.Services;
using ProjectTask.ViewModels;
using ProjectTask.WebUI.Controllers.Abstract;

namespace ProjectTask.WebUI.Controllers
{
    public class DoctorTypeController : ServicedController<DoctorTypeService>
    {
        public DoctorTypeController(DoctorTypeService service) : base(service)
        {
        }

        public IActionResult Index()
        {
            var dto = Service.GetDTOs();
            ViewData["Title"] = "Список специальностей";
            return View(dto);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Title"] = "Создать специальность";

            return PartialView(nameof(Create), new DoctorTypeViewModel());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dto = Service.GetDTO(id);

            ViewData["Title"] = "Изменить специальность";

            return PartialView(nameof(Create), dto);
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> EditPostAsync(DoctorTypeViewModel dto)
        {
            if (ModelState.IsValid)
            {
                await Service.SaveAsync(dto);
            }

            return PartialView(nameof(Create), dto);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewData["Title"] = "Удалить из списка специльностей";

            var dto = Service.GetDTO(id);

            return PartialView(nameof(Delete), dto);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int id)
        {
            ViewData["Title"] = "Удалить из списка";

            await Service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}