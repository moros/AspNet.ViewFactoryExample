using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ViewFactoryExample.Entities;

namespace ViewFactoryExample.Others
{
    public class StudentClient
    {
        public IEnumerable<Student> GetStudents()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var jsonFile = Path.Combine(baseDirectory, "students.json");

            var serializer = new JsonSerializer();
            using (var file = File.OpenText(jsonFile))
            using (var reader = new JsonTextReader(file))
            {
                return serializer.Deserialize<IEnumerable<Student>>(reader);
            }
        }

        public Student GetStudent(int id)
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var jsonFile = Path.Combine(baseDirectory, "students.json");

            var serializer = new JsonSerializer();
            using (var file = File.OpenText(jsonFile))
            using (var reader = new JsonTextReader(file))
            {
                return serializer
                    .Deserialize<IEnumerable<Student>>(reader)
                    .FirstOrDefault(student => student.Id == id);
            }
        }
    }
}