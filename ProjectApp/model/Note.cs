﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApp.model
{
    class Note
    {
        public string Id { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public Note(string title, string description, DateTime date)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            Description = description;
            Date = date;
        }
    }
}