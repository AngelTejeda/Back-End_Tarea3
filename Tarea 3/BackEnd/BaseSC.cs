using System;
using System.Linq;
using Tarea_3.DataAccess;
using Tarea_3.Models;

namespace Tarea_3.BackEnd
{
    public class BaseSC
    {
        protected NorthwindContext dbContext = new();
    }
}