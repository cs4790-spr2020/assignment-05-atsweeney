using System;
using System.Collections;
using BlabberApp.DataStore.Adapters;
using BlabberApp.Domain.Entities;

namespace BlabberApp.Services
{
    public class UserService : IUserService
    {
        //Attribute
        private readonly UserAdapter adapter;


        //Constructor
        public UserService(UserAdapter adapter)
        {
            this.adapter = adapter;
        }


        //Methods
        public IEnumerable GetAll()
        {
            return this.adapter.GetAll();
        }

        public void AddNewUser(string email)
        {
            try
            {
                this.adapter.Add(CreateUser(email));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public User CreateUser(string email)
        {
            return new User(email);
        }

        public User FindUser(string email)
        {
            return this.adapter.GetByEmail(email);
        }
    }
}
