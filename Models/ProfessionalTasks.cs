using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjGerenciadorTarefas.Models
{
    public class ProfessionalTasks : Task<Profile>
    {
        private static int idNext = 1;
        public ProfessionalTasks()
        {
            Id = idNext++;
        }
        public ProfessionalTasks(Profile associatedProfile)
        {
            AssociatedProfile = associatedProfile;
        }

        public Profile AssociatedProfile { get; set; }

        public override bool Equals(object obj)
        {
            if(obj is ProfessionalTasks otherTask)
            {
                return Id == otherTask.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}