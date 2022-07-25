using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using ProjetoAcademia.Models;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace ProjetoAcademia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadesController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public UnidadesController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select codigo, nome, site, telefone, email,
                            cep, rua, numero, bairro, cidade, estado
                            from 
                            unidades
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("conexaoMySQL");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult(table);

        }
        [HttpPost]
        public JsonResult Post(Unidades uni)
        {
            string query = @"
                        insert into unidades
                        (nome, site, telefone, email,
                            cep, rua, numero, bairro, cidade, estado)
                        values (@nome, @site, @telefone, @email,
                            @cep, @rua, @numero, @bairro, @cidade, @estado)
                        ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("conexaoMySQL");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@nome", uni.nome);
                    myCommand.Parameters.AddWithValue("@site", uni.site);
                    myCommand.Parameters.AddWithValue("@telefone", uni.telefone);
                    myCommand.Parameters.AddWithValue("@email", uni.email);
                    myCommand.Parameters.AddWithValue("@cep", uni.cep);
                    myCommand.Parameters.AddWithValue("@rua", uni.rua);
                    myCommand.Parameters.AddWithValue("@numero", uni.numero);
                    myCommand.Parameters.AddWithValue("@bairro", uni.bairro);
                    myCommand.Parameters.AddWithValue("@cidade", uni.cidade);
                    myCommand.Parameters.AddWithValue("@estado", uni.estado);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Inserido com sucesso!");

        }
        [HttpPut]
        public JsonResult Put(Unidades uni)
        {
            string query = @"
                        update unidades
                        set nome = @nome,
                        site = @site,
                        telefone = @telefone,
                        email = @email,                           
                        cep = @cep,
                        rua = @rua,
                        numero = @numero,
                        bairro = @bairro,
                        cidade = @cidade,
                        estado = @estado
                        where codigo = @codigo
                        ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("conexaoMySQL");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@codigo", uni.UnidadesID);
                    myCommand.Parameters.AddWithValue("@nome", uni.nome);
                    myCommand.Parameters.AddWithValue("@site", uni.site);
                    myCommand.Parameters.AddWithValue("@telefone", uni.telefone);
                    myCommand.Parameters.AddWithValue("@email", uni.email);
                    myCommand.Parameters.AddWithValue("@cep", uni.cep);
                    myCommand.Parameters.AddWithValue("@rua", uni.rua);
                    myCommand.Parameters.AddWithValue("@numero", uni.numero);
                    myCommand.Parameters.AddWithValue("@bairro", uni.bairro);
                    myCommand.Parameters.AddWithValue("@cidade", uni.cidade);
                    myCommand.Parameters.AddWithValue("@estado", uni.estado);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Atualizado com sucesso!");

        }

        [HttpDelete("{codigo}")]
        public JsonResult Delete(int codigo)
        {
            string query = @"
                        delete from unidades
                        where codigo = @codigo
                        ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("conexaoMySQL");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@codigo", codigo);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Deletado com sucesso!");

        }

    }
}
