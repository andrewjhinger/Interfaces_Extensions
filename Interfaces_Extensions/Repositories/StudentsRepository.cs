using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Linq.Expressions;
using Interfaces_Extensions.IE_Context;
using Interfaces_Extensions.Models;
using Interfaces_Extensions.Interfaces;
using Interfaces_Extensions.Extensions.IQueryableExtensions;

namespace Interfaces_Extensions.Repositories
{
    public class StudentsRepository : IStudentsRepository, IDisposable
    {
        private InterfacesContext context;

        public StudentsRepository(InterfacesContext context)
        {
            this.context = context;
        }

        public IEnumerable<Students> getStudents()
        {
            return context.Students.ToList();
        }

        public IQueryable<Students> OrderByName(char letter)
        {

            var list = getStudents().AsQueryable();
            return list.filterByLetter(letter);
        }

        public IQueryable<Students> Filter(string filterParams = "")
        {
            var list = getStudents().AsQueryable();
            return list.filterByName(filterParams);
        }

        private bool ContextDisposed = false;

        protected virtual void Dispose(bool disposal)
        {
            if (!this.ContextDisposed)
            {
                if (disposal)
                {
                    context.Dispose();
                }
            }
            this.ContextDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}