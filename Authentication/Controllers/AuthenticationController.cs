using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using System.IdentityModel.Tokens.Jwt;
using System.Text;



namespace Authentication.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly Data.DataContext db;
        TokenController TC = new TokenController();
        public AuthenticationController(DataContext db)
        {
            this.db = db;
        }

        [Route("/[controller]/login")]
        [HttpPost]
        public string login([FromHeader] string Authorization, [FromBody] User u)
        {
            string validToken;

            //check if exists
            var user = from User in db.Users
                       where User.email == u.email && User.password == u.password
                       select User;

            string json = JsonConvert.SerializeObject(user);

            if (json == "[]")
            {
                return "Niet gevonden";
            }
            else
            {
                //wel gevonden valideren 
                // goed gevalideerd, auto login dus geen token terug gegeven
                if (Authorization == "null" || Authorization == null)
                {
                    validToken = loginNoToken(u.email, u.password);
                }
                else
                {
                    validToken = TC.isExpired(Authorization);
                }
                return validToken;
            }
        }

        public string loginNoToken(string email, string password)
        {
            string validToken = TC.nonExistentToken(email);

            return validToken;
        }

        [Route("/[controller]/register")]
        [HttpPost]
        public string register([FromBody] User u)
        {
            if (u.email == "" || u.name == "" || u.password == "")
            {
                return "400";
            }
            else
            {
                //ToDo: check if inserted data already exitst in database
                var user = from User in db.Users
                           where User.email == u.email && User.password == u.password
                           select User;

                string json = JsonConvert.SerializeObject(user);

                if (json == "[]")
                {
                    var x = TC.CreateToken(u.email);
                    System.Reflection.PropertyInfo pi = x.GetType().GetProperty("Value");
                    string token = (String)pi.GetValue(x, null);
                    if (token != null)
                    {
                        db.Users.Add(u);
                        db.SaveChanges();
                        return token;
                    }
                    return "400";
                }
                else
                {
                    return "Gebruiker bestaat al";
                }
            }

        }

        [Authorize]
        [HttpGet]
        [Route("/[controller]/getUser")]
        public User getUser([FromHeader] string Authorization)
        {
            var x = TC.readOut(Authorization);
            User user = db.Users.Where(x => x.email.Equals(x.email)).FirstOrDefault();
            return user;
        }

        [Authorize]
        [HttpGet]
        [Route("/[controller]/auth")]
        public string authorize()
        {
            return "Succes";
        }

        [Authorize]
        [HttpDelete]
        [Route("/[controller]/delete")]
       public string DeleteUserbyID(int userid)
       {
            User user = db.Users.Where(x => x.userId == userid).Single<User>();
            db.Users.Remove(user);
            db.SaveChanges();
            return "User has successfully been Deleted";
       }

        [Authorize]
        [HttpPut]
        [Route("/[controller]/changeaccount")]
        public string updateName(User mode)
        {
            //DataContext dataContext = new DataContext();
            User user = db.Users.Where(c => c.userId == mode.userId).Single<User>();
            user.userId = mode.userId;
            user.name = mode.name;
            user.email = mode.email;
            user.password = mode.password;
            db.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return "Database is geupdate";
            
        }

        [Route("/[controller]/getUserbyid{id}")]
        [HttpGet]
        public string GetProductByID(int id)
        {
            var byId = from User in db.Users
                       where User.userId == id
                       select User;
            return JsonConvert.SerializeObject(byId);
        }



    }
}
