using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.Entidades;
using Service.Servicios;

namespace WebTarea.Pages.Tareas
{
    [Authorize]
    public class EditarModel : PageModel
    {
        private readonly ITareaServicio _tareaServicio;
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        [BindProperty(SupportsGet = true)]
        public Tarea Tarea { get; set; }
        public EditarModel(ITareaServicio tareaServicio)
        {
            _tareaServicio = tareaServicio;
        }
        public IActionResult OnGet()
        {
            Tarea = _tareaServicio.BuscarTareaId(Id);
            return Page();
        }

        public IActionResult OnPostEditar(Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                _tareaServicio.ActualizarTarea(tarea);
                return new JsonResult(new { succcess = true });

            }
            return BadRequest(ModelState);
        }
    }
}
