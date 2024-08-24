using Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorios
{
    public  interface  ITareaRepositorio
    {
        IEnumerable<Tarea> ListarTareas();
        IEnumerable<Tarea> ListarTareasCompletas();
        void AgregarTarea(Tarea task);
        void ActualizarTarea(Tarea task);
        void EliminarTarea(Tarea task);
        Tarea buscarTareaId(int id);

    }
}
