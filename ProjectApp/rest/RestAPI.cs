using Newtonsoft.Json;
using ProjectApp.model;
using System;
using System.Collections.Generic;
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
            // TODO
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
                HttpResponseMessage response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                List<Contact> contacts = JsonConvert.DeserializeObject<List<Contact>>(json);
                return RestAPIConverter.convertToNotesList(contacts);
            }
        }

        public static async Task PostNote(Note note)
        {
            using (HttpClient client = new HttpClient())
            {
                Contact contact = RestAPIConverter.convertFromNote(note);
                string json = JsonConvert.SerializeObject(contact);

                await client.PostAsync(uri, new StringContent(json, Encoding.UTF8, "application/json"));
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
