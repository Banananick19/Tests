using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AKCENT.Domain;

namespace AKCENT.Cor
{
    public class AkcentApplicationContext : DbContext
    {
        public AkcentApplicationContext() : base("DbConnection")
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Dep> Deps { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Status> Status { get; set; }
        
        #region GetSortedPersonsMethods

        public List<Person> GetPersonsByName(string name = "", int? post = null, int? dep = null, int? status = null)
        {
            var query =
                $"[dbo].[GetPersonsFiltered] N'{name}', {(post is null ? "NULL" : post.ToString())}, {(dep is null ? "NULL" : dep.ToString())}, {(status is null ? "NULL" : status.ToString())}";
            return Database.SqlQuery<Person>(query).ToList().OrderBy(p => p.GetFullName()).ToList();
        }

        public List<Person> GetPersonsByNameDescending(string name = "", int? post = null, int? dep = null, int? status = null)
        {
            var list = GetPersonsByName(name, post, dep, status);
            list.Reverse();
            return list;
        }
        
        public List<Person> GetPersonsByDep(string name = "", int? post = null, int? dep = null, int? status = null)
        {
            return Persons.SqlQuery("GetPersonsOrderByDep", name, post, dep, status).ToList();
        }

        public List<Person> GetPersonsByDepDescending(string name = "", int? post = null, int? dep = null, int? status = null)
        {
            var list = GetPersonsByDepDescending(name, post, dep, status);
            list.Reverse();
            return list;
        }
        
        public List<Person> GetPersonsByPosts(string name = "", int? post = null, int? dep = null, int? status = null)
        {
            return Persons.SqlQuery("GetPersonsOrderByPosts", name, post, dep, status).ToList();
        }

        public List<Person> GetPersonsByPostsDescending(string name = "", int? post = null, int? dep = null, int? status = null)
        {
            var list = GetPersonsByPosts(name, post, dep, status);
            list.Reverse();
            return list;
        }
        
        public List<Person> GetPersonsByDateEmploy(string name = "", int? post = null, int? dep = null, int? status = null)
        {
            return Persons.SqlQuery("GetPersonsOrderByDateEmploy", name, post, dep, status).ToList();
        }

        public List<Person> GetPersonsByDateEmployDescending(string name = "", int? post = null, int? dep = null, int? status = null)
        {
            var list = GetPersonsByDateEmploy(name, post, dep, status);
            list.Reverse();
            return list;
        }
        
        public List<Person> GetPersonsByDateUnemploy(string name = "", int? post = null, int? dep = null, int? status = null)
        {
            return Persons.SqlQuery("GetPersonsOrderByDateEmploy", name, post, dep, status).ToList();
        }

        public List<Person> GetPersonsByDateUnemployDescending(string name = "", int? post = null, int? dep = null, int? status = null)
        {
            var list = GetPersonsByDateUnemploy(name, post, dep, status);
            list.Reverse();
            return list;
        }
        
        #endregion
    }
}

/*
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE OR ALTER   PROCEDURE [dbo].[GetPersonsFiltered]
    @name nvarchar(50), 
	@post int,
	@dep int,
	@status int
AS
	With CTE As
	(SELECT *, (CONCAT_WS(' ', second_name, CONCAT_WS(
	'.', 
	LEFT(first_name, 1), LEFT(first_name, 1)))) AS full_name  FROM [dbo].People  P )
	SELECT * FROM CTE P 
	WHERE P.full_name LIKE '%' + @name + '%'
		AND (p.status_id = ISNULL(@status, p.status_id)
		AND p.dep_id = ISNULL(@dep, p.dep_id)
		AND p.post_id = ISNULL(@post, p.post_id))
	ORDER BY P.full_name
    
GO
*/