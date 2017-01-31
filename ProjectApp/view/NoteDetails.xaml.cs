using ProjectApp.model;
using ProjectApp.viewmodel;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System;

namespace ProjectApp.view
{
    public sealed partial class NoteDetails : Page
    {
        private Note note;

        public NoteDetails()
        {
            InitializeComponent();
            DataContext = new NoteDetailsViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            note = (Note) e.Parameter;

            (DataContext as NoteDetailsViewModel).Title = note.Title;
            (DataContext as NoteDetailsViewModel).Description = note.Description;
            if(note.Date.Month < 10)
            {
                (DataContext as NoteDetailsViewModel).Date = note.Date.Day + ".0" + note.Date.Month + "." + note.Date.Year;
            }
            else
            {
                (DataContext as NoteDetailsViewModel).Date = note.Date.Day + "." + note.Date.Month + "." + note.Date.Year;
            }
            if(note.Date.Minute < 10)
            {
                (DataContext as NoteDetailsViewModel).Time = note.Date.Hour + ":0" + note.Date.Minute;
            }
            else
            {
                (DataContext as NoteDetailsViewModel).Time = note.Date.Hour + ":" + note.Date.Minute;
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EditNote), note);
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog("Czy na pewno chcesz usunąć tę notatkę?");
            dialog.Commands.Add(new UICommand("Ok"));
            dialog.Commands.Add(new UICommand("Anuluj"));
            var result = await dialog.ShowAsync();

            Frame.Navigate(typeof(MainPage), note);
        }
    }
}
