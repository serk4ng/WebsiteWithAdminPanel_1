using Strasbourg.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.UnitOfWork
{
    public class STUnitOfWork : IDisposable
    {
        private readonly ApplicationContext _context;

        public STUnitOfWork()
        {
            _context = new ApplicationContext();
        }

        public ApplicationContext GetContext()
        {
            return _context;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
