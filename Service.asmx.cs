using SoapService.Models;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Web.Services;

namespace SoapService
{
    /// <summary>
    /// Summary description for Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    public class Service : System.Web.Services.WebService
    {

        [WebMethod]
        public User SelectUser(int userId)
        {
            using (var db = new MyDbContext())
            {
                return db.Users.Find(userId);
            }
        }

        [WebMethod]
        public string InsertUser(User user)
        {
            using (var db = new MyDbContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }

            return $"The user {user.Name} {user.LastName}, with email {user.Email} was inserted successfully.";
        }

        [WebMethod]
        public string DeleteUser(int user)
        {
            using (var db = new MyDbContext())
            {
                var x = db.Users.Find(user);
                db.Users.Remove(x);
                db.SaveChanges();
            }

            return $"The user was removed successfully.";
        }

        [WebMethod]
        public string UpdateUser(User user)
        {
            using (var db = new MyDbContext())
            {
                var userToUpdate = db.Users.Find(user.Id);
                userToUpdate.Name = user.Name;
                userToUpdate.LastName = user.LastName;
                userToUpdate.Email = user.Email;
                db.SaveChanges();
            }
            return $"The user {user.Name} {user.LastName}, with email {user.Email} was updated successfully.";
        }
    }
}
