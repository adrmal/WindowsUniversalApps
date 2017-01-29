using ProjectApp.model;
using ProjectApp.rest;
using ProjectApp.view;
using ProjectApp.viewmodel;
using System.Collections.Generic;
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
            LoadNotes();
        }

        private async void LoadNotes()
        {
            List<Note> notes = await RestAPI.GetAllNotes();
            (DataContext as NoteListViewModel).NoteList = notes;
        } 

        private void About_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(About));
        }

        private void NewNote_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(NewNote));
        }

        private void Note_ItemClick(object sender, ItemClickEventArgs e)
        {
            Note item = (Note) e.ClickedItem;
            Frame.Navigate(typeof(NoteDetails));
        }
    }
}
