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

        public void AddAchievement(int achievementID, int userID)
        {
            throw new NotImplementedException();
        }

        public void AddUser(User value)
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

                var parameterAge = command.CreateParameter();
                parameterAge.DbType = System.Data.DbType.Int32;
                parameterAge.Value = value.password;
                parameterAge.ParameterName = "@USER_PASSWORD";
                command.Parameters.Add(parameterAge);

                connection.Open();

                command.ExecuteScalar();
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            var result = new List<User>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetAllUsers", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
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

        public void RemoveUser(int index)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("RemoveUser", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", index);
                connection.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Удалить пользователя нельзя, так как у него есть некоторые достижения");
                }
            }
        }
    }
}
