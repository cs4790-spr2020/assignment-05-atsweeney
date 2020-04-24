using System;
using System.Collections;
using BlabberApp.DataStore.Exceptions;
using BlabberApp.DataStore.Interfaces;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStore.Adapters
{
    public class UserAdapter
    {
        //Attributes
        private readonly IUserPlugin plugin;


        //Constructor
        public UserAdapter(IUserPlugin plugin)
        {
            this.plugin = plugin;
        }


        //Methods
        public void Add(User user)
        {
            try
            {
                GetByEmail(user.Email.ToString());
            }
            catch (UserAdapterNotFoundException)
            {
                try
                {
                    this.plugin.Create(user);
                    return;
                }
                catch (Exception ex)
                {
                    throw new UserAdapterException(ex.ToString());
                }
            }
            throw new UserAdapterDuplicateException("Email already exists.");
        }

        public void Remove(User user)
        {
            try
            {
                this.plugin.Delete(user);
            }
            catch (Exception ex)
            {
                throw new UserAdapterException(ex.ToString());
            }
        }

        public void RemoveAll()
        {
            this.plugin.DeleteAll();
        }

        public void Update(User user)
        {
            try
            {
                this.plugin.Update(user);
            }
            catch (Exception ex)
            {
                throw new UserAdapterException(ex.ToString());
            }
        }

        public IEnumerable GetAll()
        {
            try
            {
                return this.plugin.ReadAll();
            }
            catch (Exception ex)
            {
                throw new UserAdapterException(ex.ToString());
            }
        }

        public User GetById(Guid Id)
        {
            try
            {
                User user = (User)this.plugin.ReadById(Id);
                return user;
            }
            catch (Exception ex)
            {
                throw new UserAdapterNotFoundException(ex.ToString());
            }
        }

        public User GetByEmail(string email)
        {
            try
            {
                User user = (User)this.plugin.ReadByUserEmail(email);
                return user;
            }
            catch (Exception)
            {
                throw new UserAdapterNotFoundException("User not registered!");
            }
        }
    }
}