using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Achievements.DAL
{
    public class AchievementDaoDB : IAchievementDao
    {
        private string connectionstring = @"Data Source=.\SQLEXPRESS;Initial Catalog=Achievements;Integrated Security=True";

        public void Add(Achievement value)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "AddAchievement";

                var parameteName = command.CreateParameter();
                parameteName.DbType = System.Data.DbType.String;
                parameteName.Value = value.name;
                parameteName.ParameterName = "@ACHIEVEMENT_NAME";
                command.Parameters.Add(parameteName);

                var parameteDescription = command.CreateParameter();
                parameteDescription.DbType = System.Data.DbType.String;
                parameteDescription.Value = value.description;
                parameteDescription.ParameterName = "@ACHIEVEMENT_DESCRIPTION";
                command.Parameters.Add(parameteDescription);

                connection.Open();

                command.ExecuteScalar();
            }
        }

        public Achievement FindId(int index)
        {
            var result = new Achievement();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand("FindIdAchievement", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var parameteId = command.CreateParameter();
                parameteId.DbType = System.Data.DbType.Int32;
                parameteId.Value = index;
                parameteId.ParameterName = "@ID";
                command.Parameters.Add(parameteId);

                connection.Open();
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    int id = (int)read["ID"];
                    string achievement_name = (string)read["ACHIEVEMENT_NAME"];
                    string achievement_description = (string)read["ACHIEVEMENT_DESCRIPTION"];

                    Achievement achievement = new Achievement(id, achievement_name, achievement_description);

                    result = achievement;
                }
            }
            return result;
        }

        public Achievement FindName(string index)
        {
            var result = new Achievement();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand("FindNameAchievement", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var parameteName = command.CreateParameter();
                parameteName.DbType = System.Data.DbType.String;
                parameteName.Value = index;
                parameteName.ParameterName = "@ACHIEVEMENT_NAME";
                command.Parameters.Add(parameteName);

                connection.Open();
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    int id = (int)read["ID"];
                    string achievement_name = (string)read["ACHIEVEMENT_NAME"];
                    string achievement_description = (string)read["ACHIEVEMENT_DESCRIPTION"];

                    Achievement achievement = new Achievement(id, achievement_name, achievement_description);

                    result = achievement;
                }
            }
            return result;
        }

        public IEnumerable<Achievement> GetAll()
        {
            var result = new List<Achievement>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("GetAllAchievements", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    int id = (int)read["ID"];
                    string name = (string)read["ACHIEVEMENT_NAME"];
                    string description = (string)read["ACHIEVEMENT_DESCRIPTION"];

                    Achievement achievement = new Achievement(id, name, description);

                    result.Add(achievement);
                }
            }
            return result;
        }

        public IEnumerable<Achievement> GetAllUsers(int index)
        {
            var result = new List<Achievement>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand("GetAllUserAchievements", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var parameteId = command.CreateParameter();
                parameteId.DbType = System.Data.DbType.Int32;
                parameteId.Value = index;
                parameteId.ParameterName = "@ID_USER";
                command.Parameters.Add(parameteId);

                connection.Open();
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    string name = (string)read["ACHIEVEMENT_NAME"];

                    Achievement achievement = new Achievement(name);

                    result.Add(achievement);
                }
            }
            return result;
        }

        public void Remove(int index)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("RemoveAchievement", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", index);
                connection.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Удалить достижение нельзя, так как оно есть у каких-то пользователей");
                }
            }
        }
    }
}
