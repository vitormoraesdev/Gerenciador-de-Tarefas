using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjGerenciadorTarefas.Models
{
    public class TaskList
    {
        public TaskList()
        {
            PersonalTasksList = new List<PersonalTasks>();
            ProfessionalTasksList = new List<ProfessionalTasks>();
        }

        public List<PersonalTasks> PersonalTasksList { get; set; }
        public List<ProfessionalTasks> ProfessionalTasksList { get; set; }

        public void AddPersonalTask(PersonalTasks personalTask)
        {
            if(!PersonalTasksList.Contains(personalTask))
            {
                PersonalTasksList.Add(personalTask);
            }
            else
            {
                Console.WriteLine("Tarefa existente!!");
            }
        }

        public void AddProfessionalTask(ProfessionalTasks professionalTask)
        {
            if(ProfessionalTasksList.Contains(professionalTask))
            {
                ProfessionalTasksList.Add(professionalTask);
            }
            else
            {
                Console.WriteLine("Tarefa existente!!");
            }
        }

        public void RemovePersonalTask(PersonalTasks personalTask)
        {
            PersonalTasksList.Remove(personalTask);
        }

        public void RemoveProfessionalTask(ProfessionalTasks professionalTask)
        {
            ProfessionalTasksList.Remove(professionalTask);
        }

        public bool CompletePesonalTask(PersonalTasks personalTask)
        {
           bool taskConcluded = personalTask.Concluded = true;
           return taskConcluded;
        }

        public bool CompleteProfessionalTask(ProfessionalTasks professionalTask)
        {
            bool taskConcluded = professionalTask.Concluded = true;
            return taskConcluded;
        }

        public void DisplayPersonalTasks()
        {
            foreach (PersonalTasks task in PersonalTasksList)
            {
                Console.WriteLine("--TAREFA PESSOAL--");
                Console.WriteLine($"ID: {task.Id}");
                Console.WriteLine($"Descrição: {task.Description}");
                Console.WriteLine($"Data de criação: {task.CreationDate}");
                Console.WriteLine($"Data de conclusão: {task.CompletionDate}");
                Console.WriteLine($"Tarefa: {(task.Concluded? "Concluida! uhuuul" : "Em processo...")}");
                Console.WriteLine($"--PERFIL--");
                Console.WriteLine($"CPF: {task.AssociatedProfile?.Cpf ?? "CPF inválido. O perfil não foi atualizado."}");
                Console.WriteLine($"Nome completo: {task.AssociatedProfile?.FullName ?? "perfil não associado a uma tarefa"}");
            }
        }

        public void DisplayProfessionalTasks()
        {
            foreach (ProfessionalTasks task in ProfessionalTasksList)
            {
                Console.WriteLine("--TAREFA PESSOAL--");
                Console.WriteLine($"ID: {task.Id}");
                Console.WriteLine($"Descrição: {task.Description}");
                Console.WriteLine($"Data de criação: {task.CreationDate}");
                Console.WriteLine($"Data de conclusão: {task.CompletionDate}");
                Console.WriteLine($"Tarefa: {task.Concluded}");
                Console.WriteLine($"--PERFIL--");
                Console.WriteLine($"CPF: {task.AssociatedProfile?.Cpf ?? "CPF inválido. O perfil não foi atualizado."}");
                Console.WriteLine($"Nome completo: {task.AssociatedProfile?.FullName ?? "perfil não associado a uma tarefa"}");
            }
        }
    }
}