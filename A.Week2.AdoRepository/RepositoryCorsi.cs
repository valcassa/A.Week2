using A.Week2.GestioneEsami.Core;
using A.Week2.GestioneEsami.Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A.Week2.AdoRepository
{
    public class RepositoryCorsi : IRepositoryCorsi
    {

        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                                   "Initial Catalog = A.Week2.GestioneEsami;" +
                                   "Integrated Security = true";

        List<Corso> IRepository<Corso>.Fetch()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select * from dbo.Corso";

                    SqlDataReader reader = command.ExecuteReader();

                    List<Corso> corso = new List<Corso>();

                    while (reader.Read())
                    {
                        Corso c = new Corso();
                        c.Id = (int)reader["Id"];
                        c.Nome = (string)reader["Nome"];


                        corso.Add(c);
                    }

                    return corso;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public List<Corso> GetCorsiByCorsoDiLaurea(CorsoDiLaurea cdl)
        {
            throw new NotImplementedException();
        }

        public void Insert(Corso c)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "insert into dbo.Corso values(@id, @nome, @cfu, @idcorso)";
                    command.Parameters.AddWithValue("@id", c.Id);
                    command.Parameters.AddWithValue("@nome", c.Nome);
                    command.Parameters.AddWithValue("@cfu", c.CreditiFormativi);
                    command.Parameters.AddWithValue("@idcorso", c.IdCorsoLaurea);

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
        