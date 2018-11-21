using System;
using System.Linq;
using BattleNetClient.Testing.Data.Models;

namespace BattleNetClient.Testing.Data
{
    public interface IRepository<T> where T : class
    {
        T InsertRecord(T record);
        T GetRecord(Func<T, bool> whereStatement);
    }

    public class AuthRepository<T> : IRepository<T> where T : class
    {
        private readonly AuthenticationDbContext _context;

        public AuthRepository(AuthenticationDbContext context)
        {
            _context = context;
        }

        public T InsertRecord(T record)
        {
            try
            {
                _context.Set<T>().Add(record);
                _context.SaveChanges();
                return record;
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public T GetRecord(Func<T, bool> whereStatement)
        {
            return _context.Set<T>().First(whereStatement);
        }
    }
}