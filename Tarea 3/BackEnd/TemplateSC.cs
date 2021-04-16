using System;
using System.Linq;

namespace Tarea_3.BackEnd
{
    class TemplateSC<T, U>
    {

        public IQueryable<T> GetAllInstances(Func<IQueryable<T>> getFunction)
        {
            return getFunction();
        }

        /*
        public T GetInstanceById()
        {
            return GetAllInstances()
        }
        */
    }
}