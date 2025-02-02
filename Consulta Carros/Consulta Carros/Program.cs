using System;
using MySql.Data.MySqlClient;

namespace ConsultarCarros
{
    class Program
    {
        static void Main(string[] args)
        {

            string connectionString = "server = localhost; user = root; database = carros; port = 3306; password = 30831751";
            MySqlConnection connection = new MySqlConnection(connectionString);


            try
            {
                Console.WriteLine("Conectando ao banco de dados...");
                connection.Open();

                Console.WriteLine("Digite o ID do veículo que deseja consultar:");
                int idVeiculo = int.Parse(Console.ReadLine());

                string sql = "SELECT * FROM carros WHERE id = @id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idVeiculo);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Console.WriteLine($"{reader["marca"]} {reader["modelo"]} - {reader["potencia"]} HP - {reader["ano_fabricacao"]}");
                }
                else
                {
                    Console.WriteLine("Veículo não encontrado.");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                connection.Close();
            }

            Console.WriteLine("Conexão fechada.");
        }
    }
}

