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
    public class AlunosController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public AlunosController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select matricula, pontos, nome, cpf, datanasc, data_cadastro, email,
                            celular, sexo, cep, rua, numero, bairro, cidade, estado, codigo_unidade,
                            data_contratacao, id_plano, codigo_professor, preco
                            from 
                            alunos
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
        public JsonResult Post(Alunos aluno)
        {
            string query = @"
                        insert into alunos
                        (pontos, nome, cpf, datanasc, data_cadastro, email,
                            celular, sexo, cep, rua, numero, bairro, cidade, estado, codigo_unidade,
                            data_contratacao, id_plano, codigo_professor, preco)
                        values (@pontos, @nome, @cpf, @datanasc, @data_cadastro, @email,
                            @celular, @sexo, @cep, @rua, @numero, @bairro, @cidade, @estado, @codigo_unidade,
                            @data_contratacao, @id_plano, @codigo_professor, @preco)
                        ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("conexaoMySQL");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@pontos", aluno.pontos);
                    myCommand.Parameters.AddWithValue("@nome", aluno.nome);
                    myCommand.Parameters.AddWithValue("@cpf", aluno.cpf);
                    myCommand.Parameters.AddWithValue("@datanasc", aluno.datanasc);
                    myCommand.Parameters.AddWithValue("@data_cadastro", aluno.data_cadastro);
                    myCommand.Parameters.AddWithValue("@email", aluno.email);
                    myCommand.Parameters.AddWithValue("@celular", aluno.celular);
                    myCommand.Parameters.AddWithValue("@sexo", aluno.sexo);
                    myCommand.Parameters.AddWithValue("@cep", aluno.cep);
                    myCommand.Parameters.AddWithValue("@rua", aluno.rua);
                    myCommand.Parameters.AddWithValue("@numero", aluno.numero);
                    myCommand.Parameters.AddWithValue("@bairro", aluno.bairro);
                    myCommand.Parameters.AddWithValue("@cidade", aluno.cidade);
                    myCommand.Parameters.AddWithValue("@estado", aluno.estado);
                    myCommand.Parameters.AddWithValue("@codigo_unidade", aluno.codigo_unidade);
                    myCommand.Parameters.AddWithValue("@data_contratacao", aluno.data_contratacao);
                    myCommand.Parameters.AddWithValue("@id_plano", aluno.id_plano);
                    myCommand.Parameters.AddWithValue("@codigo_professor", aluno.codigo_professor);
                    myCommand.Parameters.AddWithValue("@preco", aluno.preco);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Inserido com sucesso!");

        }
        [HttpPut]
        public JsonResult Put(Alunos aluno)
        {
            string query = @"
                        update alunos
                        set pontos = @pontos,
                        nome = @nome,
                        cpf = @cpf,
                        datanasc = @datanasc,
                        data_cadastro = @data_cadastro,
                        email = @email,                           
                        celular = @celular,
                        sexo = @sexo,
                        cep = @cep,
                        rua = @rua,
                        numero = @numero,
                        bairro = @bairro,
                        cidade = @cidade,
                        estado = @estado,
                        codigo_unidade = @codigo_unidade,
                        data_contratacao = @data_contratacao,
                        id_plano = @id_plano,
                        codigo_professor = @codigo_professor,
                        preco = @preco
                        where matricula = @matricula
                        ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("conexaoMySQL");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@matricula", aluno.Id);
                    myCommand.Parameters.AddWithValue("@pontos", aluno.pontos);
                    myCommand.Parameters.AddWithValue("@nome", aluno.nome);
                    myCommand.Parameters.AddWithValue("@cpf", aluno.cpf);
                    myCommand.Parameters.AddWithValue("@datanasc", aluno.datanasc);
                    myCommand.Parameters.AddWithValue("@data_cadastro", aluno.data_cadastro);
                    myCommand.Parameters.AddWithValue("@email", aluno.email);
                    myCommand.Parameters.AddWithValue("@celular", aluno.celular);
                    myCommand.Parameters.AddWithValue("@sexo", aluno.sexo);
                    myCommand.Parameters.AddWithValue("@cep", aluno.cep);
                    myCommand.Parameters.AddWithValue("@rua", aluno.rua);
                    myCommand.Parameters.AddWithValue("@numero", aluno.rua);
                    myCommand.Parameters.AddWithValue("@bairro", aluno.bairro);
                    myCommand.Parameters.AddWithValue("@cidade", aluno.cidade);
                    myCommand.Parameters.AddWithValue("@estado", aluno.estado);
                    myCommand.Parameters.AddWithValue("@codigo_unidade", aluno.codigo_unidade);
                    myCommand.Parameters.AddWithValue("@data_contratacao", aluno.data_contratacao);
                    myCommand.Parameters.AddWithValue("@id_plano", aluno.id_plano);
                    myCommand.Parameters.AddWithValue("@codigo_professor", aluno.codigo_professor);
                    myCommand.Parameters.AddWithValue("@preco", aluno.preco);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Atualizado com sucesso!");

        }

        [HttpDelete("{matricula}")]
        public JsonResult Delete(int matricula)
        {
            string query = @"
                        delete from alunos
                        where matricula = @matricula
                        ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("conexaoMySQL");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@matricula", matricula);
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
