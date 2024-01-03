using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjGerenciadorTarefas.Models
{
    public static class CpfValidatorExtension
    {
        public static bool IsValid(this string cpf)
        {
            string cleanCpf = new string(cpf.Where(char.IsDigit).ToArray());

            if(cleanCpf.Length != 11)
            {
                return false;
            }
            if(cleanCpf.Distinct().Count() == 1)
            {
                return false;
            }
            return true;
        }
    }
}