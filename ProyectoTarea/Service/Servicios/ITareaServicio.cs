using Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Servicios
{
   public interface ITareaServicio
    {
        IEnumerable<Tarea> ListarTareas();
        IEnumerable<Tarea> ListarTareasCompletas();
        void AgregarTarea(Tarea task);
        void ActualizarTarea(Tarea task);
        void EliminarTarea(Tarea task);
        Tarea BuscarTareaId(int id);
    }
}
