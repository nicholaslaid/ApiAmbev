using System.Collections.Generic;
using System.Net.Http.Headers;
using ApiAmbev.Models;
using Npgsql;

namespace ApiAmbev.DataBase
{
    public class Methods
    {
        
        public bool Add(Products products)
        {
            bool result = false;
            DataBaseAccess dba = new DataBaseAccess();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"INSERT INTO bebidas (nome, marca, tipo, volume, frasco, deleted, data_registro, valor_unitario) " +
                                          @"VALUES (@nome, @marca, @tipo, @volume, @frasco, @deleted, @data_registro, @valor_unitario);";


                    cmd.Parameters.AddWithValue("@nome", products.nome);
                    cmd.Parameters.AddWithValue("@marca", products.marca);
                    cmd.Parameters.AddWithValue("@tipo", products.tipo);
                    cmd.Parameters.AddWithValue("@volume", products.volume);
                    cmd.Parameters.AddWithValue("@frasco", products.frasco);
                    cmd.Parameters.AddWithValue("@data_registro", DateTime.Now);
                    cmd.Parameters.AddWithValue("@deleted", products.deleted = false);
                    cmd.Parameters.AddWithValue("@valor_unitario", products.valor_unitario);
                    using (cmd.Connection = dba.OpenConnection())
                    {
                        cmd.ExecuteNonQuery();
                    }
                    result = true;
                }
            }catch(Exception ex)
            {

            }
          return result;

        }

        public List<Products> GetAll()
        {
            List <Products> productos = new List <Products>();
            DataBaseAccess dba = new DataBaseAccess();

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.CommandText = @"SELECT p.id, p.nome, p.marca, p.tipo, p.volume, p.frasco, p.data_registro, p.valor_unitario " +
                                      @"FROM bebidas p " +
                                      @"WHERE p.deleted = false " + 
                                      @"ORDER BY p.id;";

                using (cmd.Connection = dba.OpenConnection()) {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Products products = new Products();
                            products.id = Convert.ToInt32(reader["id"]);
                            products.nome = reader["nome"].ToString();
                            products.marca = reader["marca"].ToString();
                            products.frasco = reader["frasco"].ToString();
                            products.volume = float.Parse(reader["volume"].ToString());
                            products.tipo = reader["tipo"].ToString();
                            products.data = Convert.ToDateTime(reader["data_registro"].ToString());
                            products.valor_unitario = float.Parse(reader["valor_unitario"].ToString());

                            productos.Add(products);
                        }
                    }
                }
            }
            try
            {

            }catch(Exception ex)
            {

            }
            return productos;
        }

        public bool Delete(int id)
        {
            bool deleted = true;
            bool result= false;
            DataBaseAccess dba = new DataBaseAccess();

            try
            {
                using(NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"UPDATE bebidas " +
                                      @"SET deleted = @deleted " +
                                      @"WHERE id = @id;";

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@deleted", deleted);

                    using(cmd.Connection = dba.OpenConnection())
                    {
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
                }
            }catch (Exception ex)
            {

            }
            return result;
        }
    }
}
