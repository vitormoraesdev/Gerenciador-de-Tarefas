using System.Data.Common;
using ProjGerenciadorTarefas.Models;
using Newtonsoft.Json;

DateTime dateNow = DateTime.Now;
bool verificador = true;

TaskList taskList = new TaskList();
taskList.PersonalTasksList = new List<PersonalTasks>();
taskList.ProfessionalTasksList = new List<ProfessionalTasks>();

while(verificador)
{
    Console.Clear();


    Console.WriteLine();

    Console.WriteLine("Digite 1 caso queira adicionar uma tarefa pessoal.");
    Console.WriteLine("Digite 2 caso queira adicionar uma tarefa profissional.");
    Console.WriteLine("Digite 3 caso queira remover uma tarefa pessoal.");
    Console.WriteLine("Digite 4 caso queira remover uma tarefa profissional.");
    Console.WriteLine("Digite 5 caso queira concluir uma tarefa pessoal.");
    Console.WriteLine("Digite 6 caso queira concluir uma tarefa profissional.");
    Console.WriteLine("Digite 7 caso queira ver a(s) tarefa(s) pessoal.");
    Console.WriteLine("Digite 8 caso queira ver a(s) tarefa(s) profissional.");
    Console.WriteLine("Digite 9 caso queira encerrar o programa");
    Console.WriteLine("Digite 10 caso queira acessar a area do Desenvolvedor");
    Console.WriteLine();

    int digito = Convert.ToInt32(Console.ReadLine());

    switch (digito)
    {
        case 1:
            bool creatingTask = true;

            while(creatingTask)
            {
                Console.WriteLine("Digite 1 caso queira adicionar uma nova tarefa.");
                Console.WriteLine("Digite 2 caso não queira mais adicionar tarefas.");
                int choiceUser = Convert.ToInt32(Console.ReadLine());
                switch(choiceUser)
                {
                    case 1:
                        PersonalTasks newPersonalTask = new PersonalTasks();
                        newPersonalTask.AssociatedProfile = new Profile();
                        Console.WriteLine($"Id da tarefa: {newPersonalTask.Id}");
                        Console.WriteLine("Digite as descrição da tarefa...");
                        newPersonalTask.Description = Console.ReadLine();
                        Console.WriteLine($"Data de criação da tarefa{dateNow.FormatDateString()}");
                        DateTime.TryParse(dateNow.FormatDateString(), out DateTime result);
                        newPersonalTask.CreationDate = result;
                        Console.WriteLine("Digite a data de conclusão da tarefa (dd/mm/aaaa hh:mm). OBS: caso não tenha concluido, pressione Enter.");
                        string dateInput = Console.ReadLine();

                        if(!string.IsNullOrWhiteSpace(dateInput))
                        {
                            if(dateInput != null)
                            {
                                DateTime.TryParse(dateInput, out DateTime result1);
                                newPersonalTask.CompletionDate = result1;
                            }
                            else
                            {
                                Console.WriteLine("Formato inválido!");
                                newPersonalTask.CompletionDate = null;
                            }
                        }
                        else
                        {
                            newPersonalTask.CompletionDate = null;
                        }
                        Console.WriteLine();
                        Console.WriteLine("Digite seu cpf para o seu perfil...");
                        string cpfInput = Console.ReadLine();
                        if(cpfInput.IsValid())
                        {
                            newPersonalTask.AssociatedProfile.Cpf = cpfInput;
                        }
                        else
                        {
                            Console.WriteLine("CPF inválido. O perfil não foi atualizado.");
                        }
                        Console.WriteLine("Digite seu nome...");
                        newPersonalTask.AssociatedProfile.Name = Console.ReadLine();
                        Console.WriteLine("Digite seu sobrenome...");
                        newPersonalTask.AssociatedProfile.Surname = Console.ReadLine();
                        taskList.AddPersonalTask(newPersonalTask);
                        break;
                    case 2:
                        creatingTask = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Pressione a tecla correta.");
                        break;
                }
            }
            break;
        case 2:
            creatingTask = true;

            while(creatingTask)
            {
                Console.WriteLine("Digite 1 caso queira adicionar uma nova tarefa.");
                Console.WriteLine("Digite 2 caso não queira mais adicionar tarefas.");
                int choiceUser = Convert.ToInt32(Console.ReadLine());
                switch(choiceUser)
                {
                    case 1:
                        ProfessionalTasks newProfessionalTask = new ProfessionalTasks();
                        newProfessionalTask.AssociatedProfile = new Profile();
                        Console.WriteLine($"Id da tarefa: {newProfessionalTask.Id}");
                        Console.WriteLine("Digite as descrição da tarefa...");
                        newProfessionalTask.Description = Console.ReadLine();
                        Console.WriteLine($"Data de criação da tarefa{dateNow.FormatDateString()}");
                        DateTime.TryParse(dateNow.FormatDateString(), out DateTime result);
                        newProfessionalTask.CreationDate = result;
                        Console.WriteLine("Digite a data de conclusão da tarefa (dd/mm/aaaa hh:mm). OBS: caso não tenha concluido, pressione Enter.");
                        string dateInput = Console.ReadLine();

                        if(!string.IsNullOrWhiteSpace(dateInput))
                        {
                            if(dateInput != null)
                            {
                                DateTime.TryParse(dateInput, out DateTime result1);
                                newProfessionalTask.CompletionDate = result1;
                            }
                            else
                            {
                                Console.WriteLine("Formato inválido!");
                                newProfessionalTask.CompletionDate = null;
                            }
                        }
                        else
                        {
                            newProfessionalTask.CompletionDate = null;
                        }
                        Console.WriteLine();
                        Console.WriteLine("Digite seu cpf para o seu perfil...");
                        string cpfInput = Console.ReadLine();
                        if(cpfInput.IsValid())
                        {
                            newProfessionalTask.AssociatedProfile.Cpf = cpfInput;
                        }
                        else
                        {
                            Console.WriteLine("CPF inválido. O perfil não foi atualizado.");
                        }
                        Console.WriteLine("Digite seu nome...");
                        newProfessionalTask.AssociatedProfile.Name = Console.ReadLine();
                        Console.WriteLine("Digite seu sobrenome...");
                        newProfessionalTask.AssociatedProfile.Surname = Console.ReadLine();
                        taskList.AddProfessionalTask(newProfessionalTask);
                        break;
                    case 2:
                        creatingTask = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Pressione a tecla correta.");
                        break;
                }
            }
            break;
        case 3:
            Console.WriteLine("Digite o Id da tarefa pessoal a ser removida:");
            int taskIdToRemove = Convert.ToInt32(Console.ReadLine());

            // Encontrar e remover a tarefa com base no Id
            PersonalTasks taskToRemove = taskList.PersonalTasksList.FirstOrDefault(task => task.Id == taskIdToRemove);

            if (taskToRemove != null)
            {
                taskList.RemovePersonalTask(taskToRemove);
                Console.WriteLine("Tarefa pessoal removida com sucesso!");
            }
            else
            {
                Console.WriteLine("Tarefa pessoal com o Id especificado não encontrada!");
            }
            break;
        case 4:
            Console.WriteLine("Digite o Id da tarefa professional a ser removida:");
            taskIdToRemove = Convert.ToInt32(Console.ReadLine());

            // Encontrar e remover a tarefa com base no Id
            ProfessionalTasks taskToRemove1 = taskList.ProfessionalTasksList.FirstOrDefault(task => task.Id == taskIdToRemove);

            if (taskToRemove1 != null)
            {
                taskList.RemoveProfessionalTask(taskToRemove1);
                Console.WriteLine("Tarefa profissional removida com sucesso!");
            }
            else
            {
                Console.WriteLine("Tarefa profissional com o Id especificado não encontrada!");
            }
            break;
        case 5:
            Console.WriteLine("Digite o Id da tarefa que deseja concluir:");
            int taskIdConcluded = Convert.ToInt32(Console.ReadLine());
            PersonalTasks taskToConcluded = taskList.PersonalTasksList.FirstOrDefault(task => task.Id == taskIdConcluded);
            if(taskToConcluded != null)
            {
                taskList.CompletePesonalTask(taskToConcluded);
                Console.WriteLine("Tarefa concluida. Parabens!!!");
            }
            else
            {
                Console.WriteLine("Tarefa pessoal com o Id especificado não encontrada!");
            }
            break;
        case 6:
            Console.WriteLine("Digite o Id da tarefa que deseja concluir:");
            int taskIdConcluded1 = Convert.ToInt32(Console.ReadLine());
            ProfessionalTasks taskToConcluded1 = taskList.ProfessionalTasksList.FirstOrDefault(task => task.Id == taskIdConcluded1);
            if(taskToConcluded1 != null)
            {
                taskList.CompleteProfessionalTask(taskToConcluded1);
                Console.WriteLine("Tarefa concluida. Parabens!!!");
            }
            else
            {
                Console.WriteLine("Tarefa pessoal com o Id especificado não encontrada!");
            }
            break;
        case 7:
            taskList.DisplayPersonalTasks();
            Console.WriteLine("aperte enter");
            Console.ReadLine();
            break;
        case 8:
            taskList.DisplayProfessionalTasks();
            Console.WriteLine("aperte enter");
            Console.ReadLine();
            break;
        case 9:
            verificador = false;
            break;

        case 10:
            Console.WriteLine("Pressione: (1)Serealizar ou (2)Desserealizar");
            int option = Convert.ToInt32(Console.ReadLine());
            switch(option)
            {
                case 1:
                    try
                    {
                        Console.WriteLine("LISTA PESSOAL");
                        Console.WriteLine("Digite o caminho da pasta que deseja salvar...(Ex: caminho/outroCaminho)");
                        string filePathPersonal = Console.ReadLine();
                        string serealizandoPersonal = JsonConvert.SerializeObject(taskList.PersonalTasksList, Formatting.Indented);
                        File.WriteAllText(filePathPersonal, serealizandoPersonal);

                        Console.WriteLine("_____________________________________________");

                        Console.WriteLine("LISTA PROFESSIONAL");
                        Console.WriteLine("Digite o caminho da pasta que deseja salvar...(Ex:caminho/outroCaminho)");
                        string filePathProfessional = Console.ReadLine();
                        string serealizandoProfessional = JsonConvert.SerializeObject(taskList.PersonalTasksList, Formatting.Indented);
                        File.WriteAllText(filePathProfessional, serealizandoProfessional);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Error: {ex}");
                    }
                    break;
                case 2:
                    try
                    {
                        Console.Title = "Lista Pessoal";
                        Console.WriteLine("Digite o caminho da pasta que deseja Desserealizar...(Ex: caminho/outroCaminho)");
                        string filePersonal = Console.ReadLine();
                        string fileContentPersonal = File.ReadAllText(filePersonal);
                        List<PersonalTasks> PersonalTasksList = JsonConvert.DeserializeObject<List<PersonalTasks>>(fileContentPersonal);

                        Console.Title = "Lista Profissional";
                        Console.WriteLine("Digite o caminho da pasta que deseja Desserealizar...(Ex: caminho/outroCaminho)");
                        string fileProfessional = Console.ReadLine();
                        string fileContentProfessional = File.ReadAllText(fileProfessional);
                        List<ProfessionalTasks> ProfessionalTasksList = JsonConvert.DeserializeObject<List<ProfessionalTasks>>
                        (fileContentProfessional);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Error: {ex}");
                    }
                    break;
                default:
                    Console.WriteLine("opção inválida!! tente novamente.");
                    break;
            }         
            break;
        default:
            Console.WriteLine("Opção inválida!! Aperte um tecla válida");
            break;     
    }
        
}
