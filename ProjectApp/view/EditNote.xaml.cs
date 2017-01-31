using ProjectApp.model;
using ProjectApp.viewmodel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System;
using Windows.UI.Popups;
using System.Net.Http;

namespace ProjectApp.view
{
    public sealed partial class EditNote : Page
    {
        private Note note;

        public EditNote()
        {
            InitializeComponent();
            DataContext = new NoteViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            note = (Note) e.Parameter;

            (DataContext as NoteViewModel).Title = note.Title;
            (DataContext as NoteViewModel).Description = note.Description;
            (DataContext as NoteViewModel).Date = note.Date;
        }

        private async void EditNote_Click(object sender, RoutedEventArgs e)
        {
            if (Title.Text == "")
            {
                await new MessageDialog("Tytuł notatki jest pusty.").ShowAsync();
            }
            else if (Description.Text == "")
            {
                await new MessageDialog("Opis notatki jest pusty.").ShowAsync();
            }
            else if (!Date.Date.HasValue)
            {
                await new MessageDialog("Dzień zakończenia notatki nie został ustawiony.").ShowAsync();
            }
            else
            {
                DateTime date = new DateTime(Date.Date.Value.DateTime.Year, Date.Date.Value.DateTime.Month, Date.Date.Value.DateTime.Day, Time.Time.Hours, Time.Time.Minutes, 0);

                try
                {
                    //await RestAPI.PutNote(new Note(Title.Text, Description.Text, date));
                    Frame.Navigate(typeof(MainPage));
                }
                catch(HttpRequestException)
                {
                    await new MessageDialog("Brak połączenia z Internetem.").ShowAsync();
                }
            }
        }
    }
}
