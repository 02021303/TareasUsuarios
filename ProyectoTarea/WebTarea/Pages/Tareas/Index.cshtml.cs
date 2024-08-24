using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Data.Repositorios;
using Model.Entidades;
using Service.Servicios;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
namespace WebTarea.Pages.Tareas
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ITareaServicio _tareaServicio;

        [BindProperty]
        public IEnumerable<Tarea> Tareas { get; set; }

        public IndexModel(ITareaServicio tareaServicio)
        {
            _tareaServicio = tareaServicio;
        }
       
        public void OnGet()
        {
            Tareas = _tareaServicio.ListarTareas();                             
        }

        public IActionResult OnGetTareas()
        {
            var tareas = _tareaServicio.ListarTareas();
            return new JsonResult(tareas);
        }
        public IActionResult OnGetEliminar(int id)
        {
        
            if (id != 0)
            {
                Tarea tarea = _tareaServicio.BuscarTareaId(id);
                _tareaServicio.EliminarTarea(tarea);
                return new JsonResult(new { success = true });
            }
            return new JsonResult(new { success = false });
        }
        public IActionResult OnGetCompletar(int id)
        {

            if (id != 0)
            {
                Tarea tarea = _tareaServicio.BuscarTareaId(id);
                tarea.Estado = true;
                _tareaServicio.ActualizarTarea(tarea);
                return new JsonResult(new { success = true });
            }
            return new JsonResult(new { success = false });
        }
        public IActionResult OnGetFiltroTarea(string filtro)
        {
            IEnumerable<Tarea> tareas = _tareaServicio.ListarTareas();

            if (filtro != null)
            {
                tareas = _tareaServicio.ListarTareas().Where(x => x.Titulo.Contains(filtro, StringComparison.OrdinalIgnoreCase)).ToList();
          
            }
            return new JsonResult(tareas);
        }

    }
}
