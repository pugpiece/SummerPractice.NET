using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;

namespace Achievements.DAL
{
    public class UserDaoDB : IUserDao
    {

        private string connectionstring = @"Data Source=.\SQLEXPRESS;Initial Catalog=Achievements;Integrated Security=True";

        public void Add(User value)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "AddUser";

                var parameteLogin = command.CreateParameter();
                parameteLogin.DbType = System.Data.DbType.String;
                parameteLogin.Value = value.login;
                parameteLogin.ParameterName = "@USER_LOGIN";
                command.Parameters.Add(parameteLogin);

                var parameterPassword = command.CreateParameter();
                parameterPassword.DbType = System.Data.DbType.Int32;
                parameterPassword.Value = value.password;
                parameterPassword.ParameterName = "@USER_PASSWORD";
                command.Parameters.Add(parameterPassword);

                connection.Open();

                command.ExecuteScalar();
            }
        }

        public User FindId(int id)
        {
            var result = new User();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand("FindIdUser", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var parameteId = command.CreateParameter();
                parameteId.DbType = System.Data.DbType.Int32;
                parameteId.Value = id;
                parameteId.ParameterName = "@ID";
                command.Parameters.Add(parameteId);

                connection.Open();
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    int index = (int)read["ID"];
                    string user_login = (string)read["USER_LOGIN"];

                    User user = new User(index, user_login);

                    result = user;
                }
            }
            return result;
        }

        public User FindLogin(string login)
        {
            var result = new User();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand("FindLoginUser", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var parameteId = command.CreateParameter();
                parameteId.DbType = System.Data.DbType.String;
                parameteId.Value = login;
                parameteId.ParameterName = "@USER_LOGIN";
                command.Parameters.Add(parameteId);

                connection.Open();
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    int index = (int)read["ID"];
                    string user_login = (string)read["USER_LOGIN"];

                    User user = new User(index, user_login);

                    result = user;
                }
            }
            return result;
        }

        public IEnumerable<User> GetAll()
        {
            var result = new List<User>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand("GetAllUsers", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    int id = (int)read["ID"];
                    string user_login = (string)read["USER_LOGIN"];

                    User user = new User(id, user_login);

                    result.Add(user);
                }
            }
            return result;
        }

        public bool Log(User value)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand("LogUser", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var parameteLogin = command.CreateParameter();
                parameteLogin.DbType = System.Data.DbType.String;
                parameteLogin.Value = value.login;
                parameteLogin.ParameterName = "@USER_LOGIN";
                command.Parameters.Add(parameteLogin);

                var parameterPassword = command.CreateParameter();
                parameterPassword.DbType = System.Data.DbType.Int32;
                parameterPassword.Value = value.password;
                parameterPassword.ParameterName = "@USER_PASSWORD";
                command.Parameters.Add(parameterPassword);

                connection.Open();

                var resultCommand = command.ExecuteScalar();

                return (int)resultCommand > 0;

            }
        }

        public void Remove(int index)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand("RemoveUser", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", index);
                connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Удалить пользователя нельзя, так как у него есть некоторые достижения");
                }
            }
        }
    }
}
