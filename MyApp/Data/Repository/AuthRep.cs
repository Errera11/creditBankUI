using System;
using MyApp.Data.Models;
using MyApp.Data.Interfaces;

namespace MyApp.Data.Repository
{
	public class AuthRep : IAuthModel
	{
		private List<Client> users = new List<Client>();

		public void setData(List<Client> x)
		{
			this.users = x;
        }
        public IEnumerable<Client> getUser
        {
			get { return this.users; }
        }

        public void addUser(Client x) {
			
			this.users.Add(x);
		}
		public AuthRep()
		{
		}
	}
}

