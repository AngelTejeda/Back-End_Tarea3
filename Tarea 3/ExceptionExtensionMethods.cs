using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_3
{
    public static class ExceptionExtensionMethods
    {
        public static void SetMessage(this Exception exception, string message)
        {
            if (exception == null)
                throw new ArgumentNullException(nameof(exception));

            Type type = typeof(Exception);
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
            FieldInfo fieldInfo = type.GetField("_message", flags);

            fieldInfo.SetValue(exception, message);
        }
    }
}
