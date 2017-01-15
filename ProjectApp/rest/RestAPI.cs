using Newtonsoft.Json;
using ProjectApp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApp.rest
{
    class RestAPI
    {
        private static Uri uri = new Uri("http://windowsuniversalapp.azurewebsites.net/contacts/");

        public static async Task<Note> GetNote(string noteId)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(uri + noteId);
                Contact contact = JsonConvert.DeserializeObject<Contact>(json);
                Note note = RestAPIConverter.convertToNote(contact);
                return note;
            }
        }

        public static async Task<List<Note>> GetAllNotes()
        {
            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(uri);
                List<Contact> contacts = JsonConvert.DeserializeObject<List<Contact>>(json);
                List<Note> notes = RestAPIConverter.convertToNotesList(contacts);
                return notes;
            }
        }

        public static async void PostNote(Note note)
        {
            using (HttpClient client = new HttpClient())
            {
                // TODO
                string json = await client.GetStringAsync(uri + note.Id);
                Contact contact = RestAPIConverter.convertFromNote(note);
                note = RestAPIConverter.convertToNote(contact);
                List<Note> obj = JsonConvert.DeserializeObject<List<Note>>(json);

            }
        }

        public async void PutNote(Note note)
        {
            // TOOD
        }

        public async void DeleteNote(string noteId)
        {
            // TODO
        }
    }
}
