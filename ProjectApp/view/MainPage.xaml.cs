using ProjectApp.model;
using ProjectApp.rest;
using ProjectApp.viewmodel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ProjectApp
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            DataContext = new NoteListViewModel();
            (DataContext as NoteListViewModel).NoteList = GetNotes().Result;
        }

        private async Task<List<Note>> GetNotes()
        {
            return await RestAPI.GetAllNotes();
        } 

        private void About_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(About));
        }

        private void NewTask_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(NewNote));
        }
    }
}
