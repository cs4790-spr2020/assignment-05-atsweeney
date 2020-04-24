using System;
using System.Collections;
using BlabberApp.DataStore.Adapters;
using BlabberApp.Domain.Entities;

namespace BlabberApp.Services
{
    public class BlabService : IBlabService
    {
        //Attributes
        private readonly BlabAdapter adapter;


        //Constructor
        public BlabService(BlabAdapter adapter)
        {
            this.adapter = adapter;
        }


        //Methods
        public void AddBlab(string message, string email)
        {
            this.adapter.Add(CreateBlab(message, email));
        }

        public void AddBlab(Blab blab)
        {
            this.adapter.Add(blab);
        }

        public IEnumerable GetAll()
        {
            return this.adapter.GetAll();
        }

        public IEnumerable FindUserBlabs(string email)
        {
            throw new NotImplementedException("FindUserBlabs");
        }

        public Blab CreateBlab(string msg, string email)
        {
            User usr = new User(email);
            return new Blab(msg, usr);
        }

        public Blab CreateBlab(string msg, User user)
        {
            return new Blab(msg, user);
        }
    }
}
