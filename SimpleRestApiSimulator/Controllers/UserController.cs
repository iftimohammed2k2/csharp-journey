using System;
using System.Collections.Generic;
using Models;

namespace Controllers
{
    public class UserController
    {
        private List<User> users = new List<User>();
        private int nextId = 1;

        public List<User> GetAllUsers()
        {
            return users;
        }

        public User GetUserById(int id)
        {
            return users.Find(u => u.Id == id);
        }

        public User CreateUser(string name, string email)
        {
            User newUser = new User(nextId++, name, email);
            users.Add(newUser);
            return newUser;
        }
    }
}
