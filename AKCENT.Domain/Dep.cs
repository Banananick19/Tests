using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AKCENT.Domain
{
    public class Dep
    {
        private Dep()
        {
            Name = "";
            Id = 0;
            Persons = new List<Person>();
        }

        public Dep(int id, string name)
        {
            Id = id;
            Name = name;
        }
        [Key]
        public int Id { get; set; }

        public virtual ICollection<Person> Persons { get; set; }


        public string Name { get; private set; }

        public void SetName(string name)
        {
            Name = name;
        }
    }
}