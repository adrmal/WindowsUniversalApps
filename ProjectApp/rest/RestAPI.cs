using Newtonsoft.Json;
using ProjectApp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace ProjectApp.rest
{
    class RestAPI
    {
        private static Uri uri = new Uri("http://windowsuniversalapp.azurewebsites.net/contacts");

        public static Task getTask(string taskId)
        {
            return null;
        }

        public static List<Task> getAllTasks()
        {
            return null;
        }

        public static async void postTask(Task task)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(uri);
                List<Task> obj = JsonConvert.DeserializeObject<List<Task>>(json);

            }
        }

        public void putTask(Task task)
        {

        }

        public void deleteTask(string taskId)
        {

        }
    }
}
