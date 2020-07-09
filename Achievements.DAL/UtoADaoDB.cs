using Achievements.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achievements.DAL
{
    public class UtoADaoDB : IUtoADao
    {

        private string connectionstring = @"Data Source=.\SQLEXPRESS;Initial Catalog=Achievements;Integrated Security=True";

        public void Add(int idUser, int idAchievement)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "AddUtoA";

                var parameteUser = command.CreateParameter();
                parameteUser.DbType = System.Data.DbType.Int32;
                parameteUser.Value = idUser;
                parameteUser.ParameterName = "@ID_USER";
                command.Parameters.Add(parameteUser);

                var parameteAchievement = command.CreateParameter();
                parameteAchievement.DbType = System.Data.DbType.Int32;
                parameteAchievement.Value = idAchievement;
                parameteAchievement.ParameterName = "@ID_ACHIEVEMENT";
                command.Parameters.Add(parameteAchievement);

                connection.Open();

                command.ExecuteScalar();
            }
        }

        public void Remove(int idUser, int idAchievement)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand("RemoveUtoA", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID_USER", idUser);
                command.Parameters.AddWithValue("@ID_ACHIEVEMENT", idAchievement);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void RemoveAchievement(int idAchievement)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand("RemoveAchievementUtoA", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID_ACHIEVEMENT", idAchievement);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void RemoveUser(int idUser)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand("RemoveUserUtoA", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID_USER", idUser);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
