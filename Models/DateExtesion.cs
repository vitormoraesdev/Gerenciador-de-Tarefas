using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjGerenciadorTarefas.Models;

namespace ProjGerenciadorTarefas.Models
{
    public static class DateExtesion
    {
        public static string FormatDateString(this DateTime dateTime, string format="dd/MM/yyyy HH:mm")
        {
            return dateTime.ToString(format);
        }        
    }
}