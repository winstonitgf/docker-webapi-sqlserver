using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using myapi.Models;

namespace myapi.repository
{
    public class UserRepository
    {
        private string connectionString;

        public UserRepository()
        {
            // connectionString = "Data Source=local:1434;Initial Catalog=TestDB;User ID=SA;Password=4Docker02";
            connectionString = "Server=db;Initial Catalog=TestDB;User ID=SA;Password=4Docker02";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public void Add(User people)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO users (Name, email, phonenumber,address)"
                                + "VALUES(@Name, @email, @phonenumber, @address)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, people);
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM users");
            }
        }

        public User GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM users"
                               + " WHERE id = @id";
                dbConnection.Open();
                return dbConnection.Query<User>(sQuery, new { id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM users"
                             + " WHERE id = @id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { id = id });
            }
        }

        public void Update(User prod)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE users SET Name = @Name,"
                               + " email = @email, phonenumber= @phonenumber"
                               + " WHERE id = @id";
                dbConnection.Open();
                dbConnection.Query(sQuery, prod);
            }
        }
    }
}