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

        public void AddAchievement(Achievement value)
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
                parameteDescription.DbType = System.Data.DbType.Int32;
                parameteDescription.Value = value.description;
                parameteDescription.ParameterName = "@ACHIEVEMENT_DESCRIPTION";
                command.Parameters.Add(parameteDescription);

                connection.Open();

                command.ExecuteScalar();
            }
        }

        public IEnumerable<Achievement> GetAllAchievements()
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

        public void RemoveAchievement(int index)
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
