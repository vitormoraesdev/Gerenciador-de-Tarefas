using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjGerenciadorTarefas.Models
{
    public class Task<T>
    {
        public Task()
        {
            Concluded = false;
        }
        public Task(int id, string description, DateTime creationDate, DateTime completionDate)
        {
            Id = id;
            Description = description;
            CreationDate = creationDate;
            CompletionDate = completionDate;
        }

        private int id;
        private string description;
        private DateTime creationDate;
        private DateTime? completionDate;

        public int Id { get => id; set{id = value;} }
        public string Description { get => description; set{description = value;} }
        public DateTime CreationDate { get => creationDate; set{creationDate = value;} }
        public DateTime? CompletionDate { get => completionDate; set{completionDate = value;} }
        public bool Concluded { get; set;}
    }
}