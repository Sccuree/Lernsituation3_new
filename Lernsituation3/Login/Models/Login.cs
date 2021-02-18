using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Login
{
    public class Login
    {
        #region Eigenschaften
        private int _id;
        private string _Username;
        private string _passwort;
        private string _status;

        #endregion

        #region Accessoren/Modifier
        public int Id { get => _id; set => _id = value; }
        public string Username { get => _Username; set => _Username = value; }

        

        public string Passwort { get => _passwort; set => _passwort = value; }
        public string Status { get => _status; set => _status = value; }

        #endregion

        #region Konstruktoren
        public Login()
        {
            Id = 0;
            Username = "";
            Passwort = "";
            Status = "";
        }
        public Login(int id, string user, string passw, string stat)
        {
            Id = id;
            Username = user;
            Passwort = passw;
            Status = stat;
        }
        #endregion

        #region Worker
        public string ueberpruefenInAPI()
        {
            HttpClient client = new HttpClient();

            string url = "http://localhost:44354/api/Message?name="+Username+"&passwort="+Passwort;
            Task<HttpResponseMessage> response = client.GetAsync(url);
            try
            {
                response.Wait();
            }
            catch (Exception)
            {
                return "";
            }

            HttpResponseMessage result = response.Result;
            Task<string> content = result.Content.ReadAsStringAsync();
            content.Wait();

            string empfang = content.Result;

            string index = "";
            index = JsonConvert.DeserializeObject(empfang).ToString();
            return index;
        }
        #endregion
    }
}