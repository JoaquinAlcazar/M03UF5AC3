using Npgsql;
using dao.DTOs;
using dao.Persistence;
using dao.Persistence.Utils;
using M03UF5AC4.DAO.persistance.dao;

namespace dao.Persistence.Mapping
{
    public class ConsumDAO : IConsumDAO
    {
        private readonly string connectionString;

        public ConsumDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }


        
        public void AddContact(consumDTO consum)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = "INSERT INTO \"consum\" (\"year\", \"codicomarca\", \"comarca\", \"poblacio\", \"domesticxarxa\", \"activitatseconomiques\", \"total\", \"consumdomestic\") " +
                    "VALUES (@year, @codicomarca, @comarca, @poblacio, @domesticxarxa, @activitatseconomiques, @total, @consumdomestic)";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@year", consum.Any);
                command.Parameters.AddWithValue("@codicomarca", 22);
                command.Parameters.AddWithValue("@comarca", consum.Comarca);
                command.Parameters.AddWithValue("@poblacio", consum.Poblacio);
                command.Parameters.AddWithValue("@domesticxarxa", consum.DomesticXarxa);
                command.Parameters.AddWithValue("@activitatseconomiques", consum.ActivitatsEconomiques);
                command.Parameters.AddWithValue("@total", consum.Total);
                command.Parameters.AddWithValue("@consumdomestic", consum.ConsumDomestic);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

}