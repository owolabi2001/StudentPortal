﻿using Microsoft.AspNetCore.Mvc;
using StudentPortal.Dto;
using StudentPortal.Dto.response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using StudentPortal.Model;

namespace StudentPortal.Service
{
    public class StudentServiceImpl : StudentService
    {

        private readonly ApplicationDbContext db;
        public StudentServiceImpl(ApplicationDbContext db)
        {
            this.db = db;
        }

        public GenericResponse SaveStudent(StudentDto student)
        {
            Student StudentCheck = db.Students
                .Where(student1 => student1.MatricNo == student.MatricNo)
                .SingleOrDefault();

            if (StudentCheck == null)
            {
                Student newStudent = new()
                {
                    Name = student.Name,
                    Programme = student.Programme,
                    MatricNo = student.MatricNo,
                    CreatedDate = DateTime.Now,
                };
                db.Students.Add(newStudent);
                db.SaveChanges();

                
                return new()
                {
                    Code = "00",
                    Message = "Student with the name " + student.Name + "has been added",
                    Data = newStudent,
                    MetaData = null
                };
            }

            
            return new()
            {
                Code = "11",
                Message = "Student already exist",
                Data = student,
                MetaData = null
            };
        }


        public GenericResponse getStudentById(int id)
        {
            var studentCheck = db.Students.Find(id);

            if (studentCheck == null)
            {
                return new()
                {
                    Code = "11",
                    Message = "No student with Id: " + id,
                    Data = null,
                    MetaData = null
                };
            }

            return new GenericResponse()
            {
                Code = "00",
                Message = "Student with Id " + id + " is shown below",
                Data = studentCheck,
                MetaData = null
            };
        }


        public GenericResponse getAllStudent()
        {
            List<Student> students = db.Students.ToList();

            return new()
            {
                Code = "00",
                Message = "The Students available in the database are:",
                Data = students,
                MetaData = null
            };
        }

    }
}
