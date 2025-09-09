using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AKCENT.Domain
{
    [Table("persons")]
    public class Person
    {
        public Person(int id, string firstName, string secondName, string lastName, DateTime? dateEmploy,
            DateTime? dateUemploy, Status status, Dep dep, Post post)
        {
            Id = id;
            first_name = firstName;
            second_name = secondName;
            last_name = lastName;
            date_employ = dateEmploy;
            date_uneploy = dateUemploy;
            Status = status;
            Dep = dep;
            Post = post;
        }

        private Person()
        {
        }
        [Key]
        public int Id { get; set; }

        [Column("first_name")] public string first_name { get; set; }

        [Column("second_name")] public string second_name { get;  set; }

        [Column("last_name")] public string last_name { get;  set; }

        [Column("date_employ")] public DateTime? date_employ { get;  set; }

        [Column("date_uneploy")] public DateTime? date_uneploy { get;  set; }

        public virtual Status Status { get; set; }

        [Column("status")] public int StatusId { get; set; }

        public virtual Dep Dep { get; set; }

        [Column("id_dep")] public int DepId { get; set; }

        public virtual Post Post { get; set; }

        [Column("id_post")] public int PostId { get; set; }

        public string GetFullName()
        {
            return $"{first_name} {last_name.FirstOrDefault()}.{second_name.FirstOrDefault()}.";
        }
    }
}