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
    public class AtividadesUnidadesController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public AtividadesUnidadesController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select id, id_atividade, codigo_unidade
                            from 
                            atividades_unidades
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
        public JsonResult Post(AtividadesUnidades atiuni)
        {
            string query = @"
                        insert into atividades_unidades
                        (id_atividade, codigo_unidade)
                        values (@id_atividade, @codigo_unidade)
                        ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("conexaoMySQL");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id_atividade", atiuni.id_atividade);
                    myCommand.Parameters.AddWithValue("@codigo_unidade", atiuni.codigo_unidade);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Inserido com sucesso!");

        }
        [HttpPut]
        public JsonResult Put(AtividadesUnidades atiuni)
        {
            string query = @"
                        update atividades_unidades
                        set id_atividade = @id_atividade,
                        codigo_unidade = @codigo_unidade
                        where id = @id
                        ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("conexaoMySQL");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", atiuni.id);
                    myCommand.Parameters.AddWithValue("@id_atividade", atiuni.id_atividade);
                    myCommand.Parameters.AddWithValue("@codigo_unidade", atiuni.codigo_unidade);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Atualizado com sucesso!");

        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                        delete from atividades_unidades
                        where id = @id
                        ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("conexaoMySQL");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", id);
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
