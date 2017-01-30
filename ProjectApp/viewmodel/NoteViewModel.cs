using System;

namespace ProjectApp.viewmodel
{
    class NoteViewModel : ViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
