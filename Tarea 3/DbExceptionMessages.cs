using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_3
{
    public static class DbExceptionMessages
    {
        public static string FieldIsRequired(string field)
        {
            return $"El campo \"{field}\" es obligatorio.";
        }

        public static string InstanceNotFound(string instanceName, string id)
        {
            return $"No se encontró un {instanceName} con el id {id}.";
        }

        public static string InstanceNotFound(string instanceName, int id)
        {
            return InstanceNotFound(instanceName, id.ToString());
        }

        public static string FailedToAdd(string instanceName)
        {
            return $"Ha ocurrido un error al insertar al {instanceName}.";
        }

        public static string FailedToUpdate(string instanceName)
        {
            return $"Ha ocurrido un error al modificar la información del {instanceName}.";
        }

        public static string FailedToDelete(string instanceName, object id)
        {
            return $"Ha ocurrido un error al eliminar al {instanceName} con id {id}.";
        }
    }
}
