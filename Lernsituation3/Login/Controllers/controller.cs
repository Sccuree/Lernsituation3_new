using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Login
{
    public class controller
    {

        #region Eigenschaften
        private Login _login;

        #endregion

        #region Accessoren/Modifier
        public Login Login { get => _login; set => _login = value; }

        #endregion

        #region Konstruktoren
        public controller()
        {
            Login = new Login();
        }
        #endregion

        #region Worker
        public string ueberpruefen(string text1, string text2)
        {
            Login user = new Login(-1,text1,text2,"");
            user.ueberpruefenInAPI();
            string index = user.ueberpruefenInAPI();
            
            return index;
        }

        public void Newsession(string text)
        {
            HttpClient client = new HttpClient();

            string url = "http://localhost:44380/api/Message?user=" + text;
            Task<HttpResponseMessage> response = client.GetAsync(url);
            try
            {
                response.Wait();
            }
            catch (Exception)
            {
                return;
            }
        }
        #endregion

    }
}