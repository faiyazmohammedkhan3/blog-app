using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using BlogAPI.Models;

namespace BlogAPI.Data
{
    public class BlogRepository
    {
        private readonly string _connectionString;

        public BlogRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Blog> GetAllBlogs()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Blog>("SELECT * FROM Blogs");
            }
        }

        public void AddBlog(Blog blog)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "INSERT INTO Blogs (Title, Content) VALUES (@Title, @Content)";
                connection.Execute(sql, blog);
            }
        }
    }
}
