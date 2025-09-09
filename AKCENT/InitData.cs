using System;
using System.Collections.Generic;
using AKCENT.Cor;
using AKCENT.Domain;

namespace AKCENT
{
    public class InitData
    {
        public void Create()
        {
            var context = new AkcentApplicationContext();
            context.Database.CreateIfNotExists();
            var deps = new List<Dep>
            {
                new Dep(0, "It"),
                new Dep(0, "Hr"),
                new Dep(0, "Main")
            };
            var posts = new List<Post>
            {
                new Post("Main", 0),
                new Post("Intern", 0),
                new Post("Worker", 0)
            };
            var statuses = new List<Status>
            {
                new Status("Worker", 0),
                new Status("Unemploy", 0),
                new Status("Interwiewing", 0)
            };
            context.Deps.AddRange(deps);
            context.Status.AddRange(statuses);
            context.Posts.AddRange(posts);
            context.SaveChanges();
            var persons = new List<Person>()
            {
                new Person(1, "John", "A.", "Doe", new DateTime(2020, 1, 15), new DateTime(2021, 1, 15), 
                    statuses[1], deps[2], posts[0]),
                new Person(2, "Jane", "B.", "Smith", new DateTime(2019, 3, 10), new DateTime(2020, 3, 10), 
                    statuses[2], deps[2], posts[2]),
                    new Person(3, "Michael", "C.", "Johnson", new DateTime(2018, 5, 20), new DateTime(2019, 5, 20),
                        statuses[0], deps[0], posts[1]),
                    new Person(4, "Emily", "D.", "Williams", new DateTime(2021, 7, 25), new DateTime(2022, 7, 25), 
                        statuses[0], deps[1], posts[1]),
                    new Person(5, "David", "E.", "Brown", new DateTime(2017, 9, 30), new DateTime(2018, 9, 30), 
                        statuses[2], deps[1], posts[2]),
                    new Person(6, "Sarah", "F.", "Jones", new DateTime(2020, 11, 5), new DateTime(2021, 11, 5), 
                        statuses[2], deps[0], posts[0]),
                    new Person(7, "James", "G.", "Garcia", new DateTime(2016, 2, 14), new DateTime(2017, 2, 14), 
                        statuses[1], deps[2], posts[2]),
                    new Person(8, "Olivia", "H.", "Martinez", new DateTime(2019, 4, 18), new DateTime(2020, 4, 18), 
                        statuses[1], deps[2], posts[2])
            };
            context.Persons.AddRange(persons);
            context.SaveChanges();
        }
    }
}