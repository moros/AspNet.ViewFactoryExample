using System.Collections.Generic;
using System.Linq;
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

            string DescriptionGender(Gender gender)
            {
                switch (gender)
                {
                    case Gender.Male:
                        return "M";
                    case Gender.Female:
                        return "F";
                    default:
                        return string.Empty;
                }
            }

            return students.Select(student => new StudentViewModel
            {
                Id = student.Id,
                Name = $"{student.LastName}, {student.FirstName}",
                Gender = DescriptionGender(student.Gender),
                Grade = student.GradeLevel.ToString(),
                School = student.SchoolName
            });
        }
    }

    public class StudentByIdViewModelFactory : ViewModelFactory<StudentViewModel, int>
    {
        public override StudentViewModel CreateView(int input)
        {
            var client = new StudentClient();
            var student = client.GetStudent(input);

            string DescriptionGender(Gender gender)
            {
                switch (gender)
                {
                    case Gender.Male:
                        return "M";
                    case Gender.Female:
                        return "F";
                    default:
                        return string.Empty;
                }
            }

            return new StudentViewModel
            {
                Id = student.Id,
                Name = $"{student.LastName}, {student.FirstName}",
                Gender = DescriptionGender(student.Gender),
                Grade = student.GradeLevel.ToString(),
                School = student.SchoolName
            };
        }
    }
}