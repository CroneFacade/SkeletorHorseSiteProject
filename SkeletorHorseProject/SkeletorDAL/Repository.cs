using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkeletorDAL.Model;
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
        public static AboutReadOnlyModel AboutReadOnly()
        {
            using (var contex = new HorseContext())
            {

                return (from a in contex.Abouts
                        select new AboutReadOnlyModel()
                        {
                            Header1 = a.Header1,
                            Header2 = a.Header2,
                            Textfield1 = a.Textfield1,
                            Textfield2 = a.Textfield2
                        }).LastOrDefault();

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

