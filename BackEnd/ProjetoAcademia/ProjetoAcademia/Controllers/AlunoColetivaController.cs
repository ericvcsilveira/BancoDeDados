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
    public class AlunoColetivaController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public AlunoColetivaController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select id, matricula, id_coletiva
                            from 
                            aluno_coletiva
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
        public JsonResult Post(AlunoColetiva ac)
        {
            string query = @"
                        insert into aluno_coletiva
                        (matricula, id_coletiva)
                        values (@matricula, @id_coletiva)
                        ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("conexaoMySQL");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@matricula", ac.matricula);
                    myCommand.Parameters.AddWithValue("@id_coletiva", ac.id_coletiva);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Inserido com sucesso!");

        }
        [HttpPut]
        public JsonResult Put(AlunoColetiva ac)
        {
            string query = @"
                        update aluno_coletiva
                        set matricula = @matricula,
                        id_coletiva = @id_coletiva
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
                    myCommand.Parameters.AddWithValue("@id", ac.id);
                    myCommand.Parameters.AddWithValue("@matricula", ac.matricula);
                    myCommand.Parameters.AddWithValue("@id_coletiva", ac.id_coletiva);
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
                        delete from aluno_coletiva
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
