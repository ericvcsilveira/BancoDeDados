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
    public class TreinoIndividualController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public TreinoIndividualController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select id, id_treino, id_individual, treino_letra, series, repeticoes, 
                            duracao, tempo_descanso, observacao
                            from 
                            treino_individual
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
        public JsonResult Post(TreinoIndividual ti)
        {
            string query = @"
                        insert into treino_individual
                        (id_treino, id_individual, treino_letra, series, repeticoes, 
                            duracao, tempo_descanso, observacao)
                        values (@id_treino, @id_individual, @treino_letra, @series, @repeticoes, 
                            @duracao, @tempo_descanso, @observacao)
                        ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("conexaoMySQL");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id_treino", ti.id_treino);
                    myCommand.Parameters.AddWithValue("@id_individual", ti.id_individual);
                    myCommand.Parameters.AddWithValue("@treino_letra", ti.treino_letra);
                    myCommand.Parameters.AddWithValue("@series", ti.series);
                    myCommand.Parameters.AddWithValue("@repeticoes", ti.repeticoes);
                    myCommand.Parameters.AddWithValue("@duracao", ti.duracao);
                    myCommand.Parameters.AddWithValue("@tempo_descanso", ti.tempo_descanso);
                    myCommand.Parameters.AddWithValue("@observacao", ti.observacao);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Inserido com sucesso!");

        }
        [HttpPut]
        public JsonResult Put(TreinoIndividual ti)
        {
            string query = @"
                        update treino_individual
                        set id_treino = @id_treino,
                        id_individual = @id_individual,
                        treino_letra = @treino_letra,
                        series = @series,
                        repeticoes = @repeticoes,
                        duracao = @duracao,
                        tempo_descanso = @tempo_descanso,
                        observacao = @observacao
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
                    myCommand.Parameters.AddWithValue("@id", ti.id);
                    myCommand.Parameters.AddWithValue("@id_treino", ti.id_treino);
                    myCommand.Parameters.AddWithValue("@id_individual", ti.id_individual);
                    myCommand.Parameters.AddWithValue("@treino_letra", ti.treino_letra);
                    myCommand.Parameters.AddWithValue("@series", ti.series);
                    myCommand.Parameters.AddWithValue("@repeticoes", ti.repeticoes);
                    myCommand.Parameters.AddWithValue("@duracao", ti.duracao);
                    myCommand.Parameters.AddWithValue("@tempo_descanso", ti.tempo_descanso);
                    myCommand.Parameters.AddWithValue("@observacao", ti.observacao);
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
                        delete from treino_individual
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
