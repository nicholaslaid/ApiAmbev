﻿using System.Collections.Generic;
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
                    cmd.CommandText = @"INSERT INTO bebidas (nome, marca, tipo, volume, frasco, data_registro) " +
                                          @"VALUES (@nome, @marca, @tipo, @volume, @frasco, @data_registro);";


                    cmd.Parameters.AddWithValue("@nome", products.nome);
                    cmd.Parameters.AddWithValue("@marca", products.marca);
                    cmd.Parameters.AddWithValue("@tipo", products.tipo);
                    cmd.Parameters.AddWithValue("@volume", products.volume);
                    cmd.Parameters.AddWithValue("@frasco", products.frasco);
                    cmd.Parameters.AddWithValue("@data_registro", DateTime.Now);

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
                cmd.CommandText = @"SELECT p.id, p.nome, p.marca, p.tipo, p.volume, p.frasco, p.data_registro " +
                                      @"FROM bebidas p " +
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
            bool result= false;
            DataBaseAccess dba = new DataBaseAccess();

            try
            {
                using(NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"Delete from bebidas " +
                                       @"Where id = @id;";

                    cmd.Parameters.AddWithValue("@id", id);

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
