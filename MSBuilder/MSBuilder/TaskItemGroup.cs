using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MSBuilder
{
    public class TaskItemGroup : IEnumerable<TaskItem>, IItemGroup
    {
        private List<TaskItem> taskes = new List<TaskItem>();

        public void AddTaskItem(TaskItem item)
        {
            taskes.Add(item);
        }

        public IEnumerator<TaskItem> GetEnumerator()
        {
            return taskes.GetEnumerator();
        }

        public TaskItem this[int number]
        {
            get
            {
                return taskes[number];
            }
            set
            {
                taskes[number] = value;
            }
        }

        public string GetXml()
        {
            var result = taskes.Select(x => x.GetXml()).Aggregate((a, b) => a + Environment.NewLine + b);
            return result;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}