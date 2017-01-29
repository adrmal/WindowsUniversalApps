using ProjectApp.model;
using ProjectApp.rest;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ProjectApp
{
    public sealed partial class About : Page
    {
        public About()
        {
            InitializeComponent();
        }

        private async void ContactWithMe_Click(object sender, RoutedEventArgs e)
        {
            List<Note> notes = await RestAPI.GetAllNotes();
            foreach (Note note in notes)
            {
                Debug.WriteLine("ID: " + note.Id);
                Debug.WriteLine("TYTUL: " + note.Title);
                Debug.WriteLine("OPIS: " + note.Description);
                Debug.WriteLine("DATA: " + note.Date.ToString());
            }
        }
    }
}
