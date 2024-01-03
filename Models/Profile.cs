using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjGerenciadorTarefas.Models
{
    public class Profile
    {
        public Profile()
        {
            
        }

        private string cpf;
        private string name;
        private string surname;

        public string Cpf { get => cpf; set{cpf = value;} }
        public string Name { get => name; set{name = value;} }
        public string Surname { get => surname; set{surname = value;} }
        public string FullName => $"{Name} {Surname}".ToUpper();
    }
}