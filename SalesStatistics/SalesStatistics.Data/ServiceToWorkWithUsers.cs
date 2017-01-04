using System.Data.Entity;
using System.Linq;
using SalesStatistics.Data.Entities;

namespace SalesStatistics.Data
{
    public static class ServiceToWorkWithUsers
    {
        private static StatisticsContext _context = new StatisticsContext();

        public static User GetUser(string lastName, string password)
        {
                return
                    _context.Set<User>()
                        .Select(p => p)
                        .Include(x => x.Role)
                        .FirstOrDefault(u => u.LastName == lastName && u.Password == password);
        }

        public static User GetUserByCookeis(string coockies)
        {
            return
                _context.Set<User>().Select(p => p).Include(x => x.Role).FirstOrDefault(u => u.Cookies == coockies);
        }

        public static void AddUser(User user)
        {
            _context.Set<User>().Add(user);
            _context.SaveChanges();
        }

        public static bool FindUser(string userLastName)
        {
            var coincidence = _context.Set<User>().FirstOrDefault(x => x.LastName == userLastName);

            if (coincidence == null)
            {
                return true;
            }

            return false;
        }

        public static void AddRole(string role)
        {
            Role newRole = new Role(role);

            _context.Set<Role>().Add(newRole);
            _context.SaveChanges();
        }
    }
}
