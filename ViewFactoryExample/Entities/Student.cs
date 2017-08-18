using System;
using System.Runtime.Serialization;

namespace ViewFactoryExample.Entities
{
    public enum Gender
    {
        Male = 0,
        Female
    };

    [Serializable]
    [DataContract]
    public class Student
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }

        [DataMember(Name = "last_name")]
        public string LastName { get; set; }

        [DataMember(Name = "gender")]
        public Gender Gender { get; set; }

        [DataMember(Name = "grade")]
        public int GradeLevel { get; set; }

        [DataMember(Name = "school")]
        public string SchoolName { get; set; }
    }
}