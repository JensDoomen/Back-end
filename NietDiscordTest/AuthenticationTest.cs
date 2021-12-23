using System;
using Xunit;
using Authentication.Controllers;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Authentication.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NietDiscordTest
{
    public class AuthenticationTest
    {
        private AuthenticationController Initialize([CallerMemberName] string callerName = "")
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "InMemoryProductDb_" + callerName).Options;
            var context = new DataContext(options);
            SeedProductInMemoryDatabaseWithData(context);
            return new AuthenticationController(context);
        }
        private TokenController InitializeToken([CallerMemberName] string callerName = "")
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "InMemoryProductDb_" + callerName).Options;
            var context = new DataContext(options);
            SeedProductInMemoryDatabaseWithData(context);
            return new TokenController();
        }


        private void SeedProductInMemoryDatabaseWithData(DataContext context)
        {
            var Users = new List<User>
            {
                new User { userId = 1, name = "Henk", email = "Henk@test.nl", password = "SpaRood23" },
                new User { userId = 2, name = "Pieter", email = "Pieter@test.nl", password = "DikkeBeer58"},
                new User { userId = 3, name = "Gertje", email = "Gertje@test.nl", password = "Jonkerd"},
                new User { userId = 4, name = null, password = null, },
            };
            if (!context.Users.Any())
            {
                context.Users.AddRange(Users);
            }
            context.SaveChanges();
        }
       
        [Fact]
        private void LoginUser_shouldloginuseraftertokengen()
        {
           
            var controller = Initialize();
            var controller2 = InitializeToken();
            var usermodel = new User();
            string test = controller2.nonExistentToken("Henk@test.nl");
            var result = controller.login(test, usermodel);
            Assert.IsType<string>(result);

        }

        [Fact]
        private void LoginToken_shouldloginuser()
        {
            var controller = Initialize();
            var usermodel = new User();

            var result = controller.loginNoToken("Henk@test.nl", "SpaRood");
            Assert.IsType<string>(result);
        }

        [Fact]
        private void Register_shouldregisteruser()
        {
            var controller = Initialize();
            var usermodel = new User();

            var result = controller.register(usermodel);
            Assert.IsType<string>(result);
        }

        [Fact]
        private void GetUser_shouldgetuser()
        {
            var controller = Initialize();
            var usermodel = new User();
            var test = controller.loginNoToken("Henk@test.nl", "SpaRood");
            var result = controller.getUser(test);
            Assert.IsType<User>(result);
        }

       
        [Fact]
        private void CreateToken_shouldcreatetoken()
        {
            var controller = InitializeToken();

            var result = controller.CreateToken("Henk");
            Assert.IsType<ObjectResult>(result);
        }

        [Fact]
        private void ReadOut_shouldreadouttoken()
        {
            var controller = InitializeToken();
            string test = controller.nonExistentToken("Henk@test.nl");
            var result = controller.readOut(test).ToString();
            //convert test naar token lees claims uit en assert per item claim.
            
            Assert.IsType<string>(result);
        }

        [Fact]
        private void isExpired_shouldcreatenewtoken()
        {
            var controller = InitializeToken();
            string test = controller.nonExistentToken("Henk@test.nl");
            var result = controller.isExpired(test);
            Assert.IsType <string>(result);
        }

        [Fact]
        private void NonexistentToken_shouldgeneratenewtoken()
        {
            var controller = InitializeToken();
           
            var result = controller.nonExistentToken("Henk@test.nl");
            Assert.IsType<string>(result);
        }


    }
}
