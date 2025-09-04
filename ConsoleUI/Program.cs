using System;
using System.Collections.Generic;
using System.Linq;
using TaskieCore;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTest1();
        }
        static void RunTest1()
        {
            TaskRepository repository = new TaskRepository();
            ToDoTask newTask = new ToDoTask();
            ToDoTask newTask2 = new ToDoTask("OOP", 2);
            DeadlineTask newDeadlineTask = new DeadlineTask("Kolokvij", 3, new DateTime(2025, 2, 1));
            Console.WriteLine($"Task 1: {newTask.ToString()}");
            Console.WriteLine($"Task 2: {newTask2.ToString()}");
            Console.WriteLine($"Task 3: {newDeadlineTask.ToString()}");
            Console.WriteLine("Now testing repo:");
            repository.SaveTask(newTask);
            repository.SaveTask(newTask2);
            repository.SaveTask(newDeadlineTask);
            repository.PrintTest();
            Console.WriteLine("__________________");
            repository.Delete(newTask);
            repository.PrintTest();
            Console.WriteLine("__________________");
            repository.SaveTask(newTask);
            repository.SaveTask(newTask);
            repository.PrintTest();
            Console.WriteLine("__________________");
            repository.DeleteAll("Task");
            repository.PrintTest();
            Console.WriteLine("__________________");
            List<ToDoTask> TestTasks = new List<ToDoTask>();
            TestTasks = repository.GetAllTasks().ToList();
            foreach (var task in TestTasks)
            {
                Console.WriteLine($"{task.ToString()}");
            }

        }
    }
}