using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskie;
using Taskie.Data;

namespace TaskieCore
{
    public class TaskRepository : ITaskDao
    {
        public List<ToDoTask> tasks = new List<ToDoTask>();
        public void SaveTask(ToDoTask task)
        {
            tasks.Add(task);
        }
        public IEnumerable<ToDoTask> GetAllTasks()
        {
            return tasks;
        }
        public void Delete(ToDoTask taskToDelete)
        {
            tasks.Remove(taskToDelete);
        }
        public void DeleteAll(string name)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].GetName().Equals(name))
                {
                    tasks.RemoveAt(i);
                    i--;
                }
            }
        }
        public void PrintTest()
        {
            foreach (var task in tasks)
            {
                Console.WriteLine($"{task.ToString()}");
            }
        }
    }
}