using System;
using MyApp.Data.Models;

namespace MyApp.Data.Interfaces
{
	public class IAuthModel
	{
        private List<Client> users;

        IEnumerable<Client> getUser;
        void addUser(Client x)
        {

            this.users.Add(x);
        }
    }
}

