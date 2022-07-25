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
    public class TreinosController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public TreinosController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select id, objetivo, data_inicio, duracao, observacoes, matricula, codigo_professor
                            from 
                            treinos
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
        public JsonResult Post(Treinos tr)
        {
            string query = @"
                        insert into treinos
                        (objetivo, data_inicio, duracao, observacoes, matricula, codigo_professor)
                        values (@objetivo, @data_inicio, @duracao, @observacoes, @matricula, @codigo_professor)
                        ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("conexaoMySQL");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@objetivo", tr.objetivo);
                    myCommand.Parameters.AddWithValue("@data_inicio", tr.data_inicio);
                    myCommand.Parameters.AddWithValue("@duracao", tr.duracao);
                    myCommand.Parameters.AddWithValue("@observacoes", tr.observacoes);
                    myCommand.Parameters.AddWithValue("@matricula", tr.matricula);
                    myCommand.Parameters.AddWithValue("@codigo_professor", tr.codigo_professor);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Inserido com sucesso!");

        }
        [HttpPut]
        public JsonResult Put(Treinos tr)
        {
            string query = @"
                        update treinos
                        set objetivo = @objetivo,
                        data_inicio = @data_inicio,
                        duracao = @duracao,
                        observacoes = @observacoes,
                        matricula = @matricula,
                        codigo_professor = @codigo_professor
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
                    myCommand.Parameters.AddWithValue("@id", tr.id);
                    myCommand.Parameters.AddWithValue("@objetivo", tr.objetivo);
                    myCommand.Parameters.AddWithValue("@data_inicio", tr.data_inicio);
                    myCommand.Parameters.AddWithValue("@duracao", tr.duracao);
                    myCommand.Parameters.AddWithValue("@observacoes", tr.observacoes);
                    myCommand.Parameters.AddWithValue("@matricula", tr.matricula);
                    myCommand.Parameters.AddWithValue("@codigo_professor", tr.codigo_professor);
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
                        delete from treinos
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

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {
                return new JsonResult("anonymous.png");
            }
        }
    }
}
