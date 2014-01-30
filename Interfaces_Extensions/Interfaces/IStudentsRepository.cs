using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using Interfaces_Extensions.Models;
using Interfaces_Extensions.IE_Context;

namespace Interfaces_Extensions.Interfaces
{
    public interface IStudentsRepository : IDisposable
    {
        IEnumerable<Students> getStudents();
        IQueryable<Students> OrderByName(char letter);
        IQueryable<Students> Filter(string filterParams = "");
    }
}