using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Reflection;
using Interfaces_Extensions.Models;

namespace Interfaces_Extensions.Extensions.IQueryableExtensions
{
    public static class IQueryableFilter
    {
        public static IQueryable<Students> filterByName(this IQueryable<Students> student, string name)
        {
            return student.Where(x => x.Name.Contains(name));
        }

        public static IQueryable<Students> filterByLetter(this IQueryable<Students> student, char letter)
        {
            return student.OrderByDescending(x => x.Name[0] == letter);
        }

        public static IQueryable<Courses> checkIfCourseExists(this IQueryable<Courses> course, string courseName)
        {
            return course.Where(x => x.CourseName.ToUpper().Contains(courseName.ToUpper()));
        }

        public static IQueryable<Courses> courseRange(this IQueryable<Courses> course, int val_a, int val_b)
        {
            return course.Where(x => (x.Id > val_a && x.Id < val_b));
        }
    }
}