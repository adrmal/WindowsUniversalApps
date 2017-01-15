using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApp.model
{
    class Task
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date;

        public Task(string title, string description, DateTime date)
        {
            Title = title;
            Description = description;
            Date = date;
        }

    }
}
