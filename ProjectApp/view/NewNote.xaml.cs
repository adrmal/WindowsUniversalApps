using ProjectApp.model;
using ProjectApp.rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ProjectApp
{
    public sealed partial class NewNote : Page
    {
        public NewNote()
        {
            InitializeComponent();
        }

        private async void NewNote_Click(object sender, RoutedEventArgs e)
        {
            if(Title.Text == "")
            {
                await new MessageDialog("Tytuł notatki jest pusty.").ShowAsync();
            }
            else if(Description.Text == "")
            {
                await new MessageDialog("Opis notatki jest pusty.").ShowAsync();
            }
            else if(!Date.Date.HasValue)
            {
                await new MessageDialog("Dzień zakończenia notatki nie został ustawiony.").ShowAsync();
            }
            else
            {
                DateTime date = new DateTime(Date.Date.Value.DateTime.Year, Date.Date.Value.DateTime.Month, Date.Date.Value.DateTime.Day, Time.Time.Hours, Time.Time.Minutes, 0);

                try
                {
                    List<Note> notes = await RestAPI.GetAllNotes();
                    int maxId = -1;
                    if(notes.Count != 0)
                    {
                        maxId = notes.Max(note => note.Id);
                    }

                    await RestAPI.PostNote(new Note(maxId+1, Title.Text, Description.Text, date));
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
