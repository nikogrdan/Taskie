using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskie
{
    public class ToDoTask
    {
        private string name;
        private int importance;

        public ToDoTask()
        {
            name = "Task";
            importance = 1;
        }
        public ToDoTask(string name, int importance)
        {
            this.name = name;
            if (importance < 1)
            {
                this.importance = 1;
            }
            else if (importance > 3)
            {
                this.importance = 3;
            }
            else
            {
                this.importance = importance;
            }
        }
        public string GetName()
        {
            return name;
        }
        private void SetName(string name)
        {
            this.name = name;
        }
        public int GetImportance()
        {
            return importance;
        }
        private void SetImportance(int importance)
        {
            this.importance = importance;
        }
        public override string ToString()
        {
            return $"Name of task: {name}, importance: {importance}";
        }
    }
}