using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Login.Controllers
{
    public class MessageController : ApiController
    {
        // GET: api/Message
        public string Get(string name="",string passwort="")
        {
            MySqlConnection Conn = new MySqlConnection();
            string MyConnectionString = "Server=localhost;Port=3307;Database=loginverwaltung; Uid =user;Password=user";
            string sql = "SELECT COUNT( * )FROM `login` WHERE `Username` = '" + name + "'AND `passwort` = '" + passwort+ "'";
            try
            {
                Conn = new MySqlConnection();
                Conn.ConnectionString = MyConnectionString;
                Conn.Open();
            }
            catch (MySqlException)
            {
                //Datenbank nicht verfügbar

                return "3";
               

            }

            MySqlCommand command = new MySqlCommand(sql, Conn);

            string index = command.ExecuteScalar().ToString();

            return index.ToString();
        }

        // GET: api/Message/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Message
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/Message/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Message/5
        public void Delete(int id)
        {
        }
    }
}
