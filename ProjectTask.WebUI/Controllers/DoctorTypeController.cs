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

            return View(new DoctorTypeViewModel());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dto = Service.GetDTO(id);

            ViewData["Title"] = "Изменить специальность";

            return View(nameof(Create), dto);
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> EditPostAsync(DoctorTypeViewModel dto)
        {
            if (ModelState.IsValid)
            {
                await Service.SaveAsync(dto);
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewData["Title"] = "Удалить из списка специльностей";

            var dto = Service.GetDTO(id);

            return View(dto);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(DoctorTypeViewModel dto)
        {
            await Service.DeleteAsync(dto.Id);

            return RedirectToAction(nameof(Index));
        }
    }
}