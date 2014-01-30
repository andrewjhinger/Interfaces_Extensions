using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Interfaces_Extensions.Models;
using Interfaces_Extensions.IE_Context;

namespace Interfaces_Extensions.IE_Context
{
    public class InterfacesInitializer : DropCreateDatabaseAlways<InterfacesContext>
    {
        protected override void Seed(InterfacesContext context)
        {
            var _courses = new List<Courses>()
            {
                new Courses { Id = 222, CourseName = "Physics I", Credits = 3, students = new List<Students>() },
                new Courses { Id = 101, CourseName = "Psychology", Credits = 3, students = new List<Students>() },
                new Courses { Id = 144, CourseName = "Business Philosophy", Credits = 3, students = new List<Students>() },
                new Courses { Id = 296, CourseName = "Calculus I", Credits = 4, students = new List<Students>() },
                new Courses { Id = 442, CourseName = "Physics II", Credits = 3, students = new List<Students>() },
                new Courses { Id = 111, CourseName = "English I", Credits = 3, students = new List<Students>() },
                new Courses { Id = 235, CourseName = "Artistic Expression", Credits = 2, students = new List<Students>() },
                new Courses { Id = 599, CourseName = "CSE Ind. Study", Credits = 1, students = new List<Students>() },
                new Courses { Id = 485, CourseName = "Structural Dynamics", Credits = 4, students = new List<Students>() },
                new Courses { Id = 386, CourseName = "Bioinformatics", Credits = 4, students = new List<Students>() },
            };
            _courses.ForEach(x => context.Courses.Add(x));
            context.SaveChanges();

            var _students = new List<Students>()
            {
                new Students { Id = 10025, Name = "Michael Hadsworth", courses = new List<Courses>() },
                new Students { Id = 10435, Name = "Arielle Highsmith", courses = new List<Courses>() },
                new Students { Id = 11324, Name = "Daniel Hartfords", courses = new List<Courses>() },
                new Students { Id = 30982, Name = "Crystal Hingerfield", courses = new List<Courses>() },
                new Students { Id = 29051, Name = "Shawndra Kiljoy", courses = new List<Courses>() },
                new Students { Id = 20058, Name = "Yuri Goferfeldt", courses = new List<Courses>() },
                new Students { Id = 10598, Name = "Andrew Bandelsy", courses = new List<Courses>() },
                new Students { Id = 14568, Name = "Randolph Nomenture", courses = new List<Courses>() },
                new Students { Id = 31258, Name = "Barry Mantilok", courses = new List<Courses>() },
                new Students { Id = 10852, Name = "Gabriel Jones", courses = new List<Courses>() },
                new Students { Id = 30125, Name = "Caesar Juneseth", courses = new List<Courses>() },
                new Students { Id = 31215, Name = "Rebecca Vantry", courses = new List<Courses>() },
            };
            _students.ForEach(x => context.Students.Add(x));
            context.SaveChanges();


            _courses[0].students.Add(_students[0]);
            _courses[3].students.Add(_students[0]);
            _courses[2].students.Add(_students[0]);
            _courses[8].students.Add(_students[0]);

            _courses[9].students.Add(_students[1]);
            _courses[5].students.Add(_students[1]);
            _courses[7].students.Add(_students[1]);
            _courses[4].students.Add(_students[1]);

            _courses[8].students.Add(_students[2]);
            _courses[1].students.Add(_students[2]);
            _courses[6].students.Add(_students[2]);
            _courses[3].students.Add(_students[2]);

            _courses[0].students.Add(_students[3]);
            _courses[9].students.Add(_students[3]);
            _courses[5].students.Add(_students[3]);
            _courses[4].students.Add(_students[3]);

            _courses[8].students.Add(_students[4]);
            _courses[4].students.Add(_students[4]);
            _courses[7].students.Add(_students[4]);
            _courses[2].students.Add(_students[4]);

            _courses[9].students.Add(_students[5]);
            _courses[3].students.Add(_students[5]);
            _courses[1].students.Add(_students[5]);
            _courses[6].students.Add(_students[5]);

            _courses[0].students.Add(_students[6]);
            _courses[2].students.Add(_students[6]);
            _courses[4].students.Add(_students[6]);
            _courses[6].students.Add(_students[6]);

            _courses[8].students.Add(_students[7]);
            _courses[0].students.Add(_students[7]);
            _courses[1].students.Add(_students[7]);
            _courses[3].students.Add(_students[7]);

            _courses[5].students.Add(_students[8]);
            _courses[7].students.Add(_students[8]);
            _courses[9].students.Add(_students[8]);
            _courses[1].students.Add(_students[8]);

            _courses[0].students.Add(_students[9]);
            _courses[2].students.Add(_students[9]);
            _courses[4].students.Add(_students[9]);
            _courses[6].students.Add(_students[9]);

            _courses[8].students.Add(_students[10]);
            _courses[0].students.Add(_students[10]);
            _courses[1].students.Add(_students[10]);
            _courses[3].students.Add(_students[10]);

            _courses[5].students.Add(_students[11]);
            _courses[7].students.Add(_students[11]);
            _courses[9].students.Add(_students[11]);
            _courses[0].students.Add(_students[11]);
            context.SaveChanges();
        }
    }
}