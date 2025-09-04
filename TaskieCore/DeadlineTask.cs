using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskie
{
    public class DeadlineTask : ToDoTask
    {
        DateTime deadline;
        public DeadlineTask() : base()
        {
            deadline = DateTime.Now;
        }
        public DeadlineTask(string name, int importance, DateTime deadline) : base(name, importance)
        {
            this.deadline = deadline;
        }
        public TimeSpan GetTimeLeft()
        {
            TimeSpan timeLeft = TimeSpan.Zero;
            timeLeft = deadline - DateTime.Now;
            if (timeLeft < TimeSpan.Zero)
            {
                timeLeft = TimeSpan.Zero;
            }
            return timeLeft;
        }
        public override string ToString()
        {
            return base.ToString() + $", time left: {GetTimeLeft().Hours}:{GetTimeLeft().Minutes}:{GetTimeLeft().Seconds}";
        }
    }
}