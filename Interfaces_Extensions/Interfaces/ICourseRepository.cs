using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using Interfaces_Extensions.Models;
using Interfaces_Extensions.IE_Context;

namespace Interfaces_Extensions.Interfaces
{
    public interface ICourseRepository : IDisposable 
    {
        IEnumerable<Courses> GetAllCourses();
        IQueryable<Courses> SearchCourses(Expression<Func<Courses, bool>> query);
        IQueryable<Courses> CheckIfCourseExists(Expression<Func<Courses, bool>> query, string courseValue);
        IQueryable<Courses> GetCourseRange(int val_1, int val_2);
        void AddCourse(Courses course);
        void EditCourse(Courses course);
        void DeleteCourse(int id);
        Courses GetByCourseNumber(int id);
        void SaveChanges();
    }
}