using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.Entidades;
using Service.Servicios;

namespace WebTarea.Pages.Tareas
{
    [Authorize]
    public class CrearModel : PageModel
    {
        private readonly ITareaServicio _tareaServicio;
        [BindProperty]
        public Tarea Tarea { get; set; }

        public CrearModel(ITareaServicio tareaServicio)
        {
            _tareaServicio = tareaServicio;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostCrear(Tarea tarea) 
        {
            if (ModelState.IsValid)
            {
                tarea.FechaCreacion = DateTime.Now;
                _tareaServicio.AgregarTarea(tarea);
                return new JsonResult(new { succcess = true, redirectUrl = Url.Page("/Tareas") });
              
            }
            return BadRequest(ModelState);
        }
    }
}
