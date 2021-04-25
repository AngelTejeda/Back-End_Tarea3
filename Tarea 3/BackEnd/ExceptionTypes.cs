using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_3.BackEnd
{
    public static class ExceptionTypes
    {
        public static bool IsSqlException(Exception ex)
        {
            return ex is DbUpdateException
                && ex.InnerException != null
                && ex.InnerException is SqlException;
        }

        public static bool IsDbException(Exception ex)
        {
            return ex is DbUpdateConcurrencyException
                || ex is DbUpdateException;
        }
    }
}
