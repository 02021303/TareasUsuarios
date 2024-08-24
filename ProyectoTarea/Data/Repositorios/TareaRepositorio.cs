using Data.Data;
using Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositorios
{
    public class TareaRepositorio : ITareaRepositorio
    {
        private readonly TareaDbContext _context;

        public TareaRepositorio(TareaDbContext context)
        {
            _context = context;
        }

        public void ActualizarTarea(Tarea task)
        {
            _context.Update(task);
            _context.SaveChanges();
        }

        public void AgregarTarea(Tarea task)
        {
            _context.Add(task);
            _context.SaveChanges();
        }

        public void EliminarTarea(Tarea task)
        {
            _context.Remove(task);
            _context.SaveChanges();
        }

        public IEnumerable<Tarea> ListarTareas()
        {
            return _context.Tareas.OrderBy(x => x.FechaVencimiento).ToList();
        }

        public IEnumerable<Tarea> ListarTareasCompletas()
        {
            return _context.Tareas.Where(t => t.Estado == true).ToList();
        }
        public Tarea buscarTareaId(int id)
        {      
            return _context.Tareas.Find(id);
        }
    }
}
