using ProjectApp.model;
using System.Collections.Generic;

namespace ProjectApp.viewmodel
{
    class NoteListViewModel : ViewModel
    {
        private List<Note> noteList = new List<Note>();
        public List<Note> NoteList
        {
            get
            {
                return noteList;
            }
            set
            {
                noteList = value;
                NotifyPropertyChanged();
            }
        }
    }
}
