using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SkeletorDAL
{
	public static class Repository
	{
		public static List<Horse> GetAllHorses()
		{
			using (var context = new HorseContext())
			{
				return (from h in context.Horses
						select h).ToList();
			}
		}

	    public static bool AuthenticateAdminLogin(string username, string password)
	    {
	        using (var context = new HorseContext())
	        {
	            return
	                (from a in context.Users
	                    where a.Username == username && a.Password == password
	                    select a).Any();
	        }
	    }
	}
}
