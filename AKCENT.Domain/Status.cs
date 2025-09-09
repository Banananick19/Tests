using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AKCENT.Domain
{
    public class Status
    {
        public Status(string name, int id)
        {
            Name = name;
            Id = id;
        }

        private Status()
        {
            Persons = new List<Person>();
        }

        public virtual ICollection<Person> Persons { get; set; }

        public string Name { get; set; }
        [Key]
        public int Id { get; set; }
    }
}