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
    public class CoursesRepository : ICourseRepository, IDisposable
    {
        private InterfacesContext context;

        public CoursesRepository(InterfacesContext context)
        {
            this.context = context;
        }

        public IEnumerable<Courses> GetAllCourses()
        {
            return context.Courses.ToList();
        }

        public IQueryable<Courses> SearchCourses(Expression<Func<Courses, bool>> query)
        {
            return context.Courses.Where(query);
        }

        public IQueryable<Courses> CheckIfCourseExists(string courseValue)
        {
            return context.Courses.checkIfCourseExists(courseValue);
        }

        public IQueryable<Courses> GetCourseRange(int val_1, int val_2)
        {
            return context.Courses.courseRange(val_1, val_2);
        }

        public void AddCourse(Courses course)
        {
            context.Courses.Add(course);
        }

        public void EditCourse(Courses course)
        {
            context.Entry(course).State = EntityState.Modified;
        }

        public void DeleteCourse(int id = 0)
        {
            Courses course = context.Courses.Find(id);
            context.Courses.Remove(course);
        }

        public Courses GetByCourseNumber(int id = 0)
        {
            Courses course = context.Courses.Find(id);
            return course;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
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