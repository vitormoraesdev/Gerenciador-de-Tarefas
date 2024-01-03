using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjGerenciadorTarefas.Models
{
    public class PersonalTasks : Task<Profile>
    {
        private static int idNext = 1;
        public PersonalTasks()
        {
            Id = idNext++;
        }
        public PersonalTasks(Profile associatedProfile)
        {
            AssociatedProfile = associatedProfile;
        }

        public Profile AssociatedProfile { get; set;}

        public override bool Equals(object obj)
        {
            if (obj is PersonalTasks otherTask)
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