using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUDWithIssues.Models
{
    public static class StudentDB
    {
        public static List<Student> GetStudents(StudentContext db)
        {
            return db.Students.ToList();
        }

        public static Student GetStudent(StudentContext db, int studentID)
        {
            return db.Students.Find(studentID);
        }

        public static void AddStudent(StudentContext db, Student stu)
        {
            //db.Entry(stu).State = EntityState.Modified;
            db.Students.Add(stu);
            db.SaveChanges();
        }

        public static void UpdateStudent(StudentContext db, Student stu)
        {
            db.Entry(stu).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void DeleteStudent(StudentContext db, Student stu)
        {
            
            db.Entry(stu).State = EntityState.Deleted;
            db.SaveChanges();
        }
    }
}