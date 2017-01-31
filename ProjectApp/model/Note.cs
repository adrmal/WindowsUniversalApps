using System;

namespace ProjectApp.model
{
    class Note
    {
        public int Id { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public Note(int id, string title, string description, DateTime date)
        {
            Id = id;
            Title = title;
            Description = description;
            Date = date;
        }
    }
}
