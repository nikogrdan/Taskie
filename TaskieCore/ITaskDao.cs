using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskieCore;

namespace Taskie.Data
{
    public interface ITaskDao
    {
        void SaveTask(ToDoTask t);
        IEnumerable<ToDoTask> GetAllTasks();
        void Delete(ToDoTask t);
        void DeleteAll(string name);
    }
}