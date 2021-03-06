﻿using System.Collections.Generic;
using System.Linq;
using Humanizer;
using ViewFactoryExample.Entities;
using ViewFactoryExample.Others;
using ViewFactoryExample.ViewModels;

namespace ViewFactoryExample.Factory
{
    public class StudentsViewModelFactory : ViewModelFactory<IEnumerable<StudentViewModel>>
    {
        public override IEnumerable<StudentViewModel> CreateView()
        {
            var client = new StudentClient();
            var students = client.GetStudents();
            
            return students.Select(student => new StudentViewModel
            {
                Id = student.Id,
                Name = $"{student.LastName}, {student.FirstName}",
                Gender = student.Gender.Abbreviation(),
                Grade = $"{student.GradeLevel.Ordinalize()} grade",
                School = student.SchoolName
            });
        }
    }

    public class StudentByIdViewModelFactory : ViewModelFactory<StudentViewModel, Student>
    {
        public override StudentViewModel CreateView(Student student)
        {
            return new StudentViewModel
            {
                Id = student.Id,
                Name = $"{student.LastName}, {student.FirstName}",
                Gender = student.Gender.Abbreviation(),
                Grade = $"{student.GradeLevel.Ordinalize()} grade",
                School = student.SchoolName
            };
        }
    }
}