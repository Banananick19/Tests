using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AKCENT.Domain
{
    public class Post
    {
        public Post(string name, int id)
        {
            Name = name;
            Id = id;
        }

        private Post()
        {
            Persons = new List<Person>();
        }

        public virtual ICollection<Person> Persons { get; set; }


        public string Name { get; set; }
        [Key]
        public int Id { get; set; }
    }
}