using A.Week2.GestioneEsami.Core.Entities;
using A.Week2.GestioneEsami.Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A.Week2.AdoRepository
{

    public class RepositoryEsami : IRepositoryEsami
    {

        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                                   "Initial Catalog = A.Week2.GestioneEsami;" +
                                   "Integrated Security = true";

        public bool Add(Esame esameDaSostenere)
        {
            throw new NotImplementedException();
        }

        public List<Esame> Fetch()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select * from dbo.Esame";

                    SqlDataReader reader = command.ExecuteReader();

                    List<Esame> esame = new List<Esame>();

                    while (reader.Read())
                    {
                        Esame e = new Esame();
                        e.IdStudente = (int)reader["IdStudente"];
                        e.Nome = (string)reader["Nome"];
                        e.Passato = (bool)reader["Passato"];

                        esame.Add(e);
                    }

                    return esame;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(Esame e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "insert into dbo.Esame values(@nome, @passato, @idstudente)";
                    command.Parameters.AddWithValue("@idstudente", e.IdStudente);
                    command.Parameters.AddWithValue("@nome", e.Nome);
                    command.Parameters.AddWithValue("@passato", e.Passato);
 
                    command.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
