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
    public class ProfessoresController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public ProfessoresController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select codigo, salario, nome, cpf, datanasc, data_cadastro, email,
                            celular, sexo, cep, rua, numero, bairro, cidade, estado,
                            instrutor, personal, professor, turno, codigo_unidade
                            from 
                            professores
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
        public JsonResult Post(Professores prof)
        {
            string query = @"
                        insert into professores
                        (salario, nome, cpf, datanasc, data_cadastro, email,
                            celular, sexo, cep, rua, numero, bairro, cidade, estado,
                            instrutor, personal, professor, turno, codigo_unidade)
                        values (@salario, @nome, @cpf, @datanasc, @data_cadastro, @email,
                            @celular, @sexo, @cep, @rua, @numero, @bairro, @cidade, @estado,
                            @instrutor, @personal, @professor, @turno, @codigo_unidade)
                        ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("conexaoMySQL");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@salario", prof.salario);
                    myCommand.Parameters.AddWithValue("@nome", prof.nome);
                    myCommand.Parameters.AddWithValue("@cpf", prof.cpf);
                    myCommand.Parameters.AddWithValue("@datanasc", prof.datanasc);
                    myCommand.Parameters.AddWithValue("@data_cadastro", prof.data_cadastro);
                    myCommand.Parameters.AddWithValue("@email", prof.email);
                    myCommand.Parameters.AddWithValue("@celular", prof.celular);
                    myCommand.Parameters.AddWithValue("@sexo", prof.sexo);
                    myCommand.Parameters.AddWithValue("@cep", prof.cep);
                    myCommand.Parameters.AddWithValue("@rua", prof.rua);
                    myCommand.Parameters.AddWithValue("@numero", prof.numero);
                    myCommand.Parameters.AddWithValue("@bairro", prof.bairro);
                    myCommand.Parameters.AddWithValue("@cidade", prof.cidade);
                    myCommand.Parameters.AddWithValue("@estado", prof.estado);
                    myCommand.Parameters.AddWithValue("@instrutor", prof.instrutor);
                    myCommand.Parameters.AddWithValue("@personal", prof.personal);
                    myCommand.Parameters.AddWithValue("@professor", prof.professor);
                    myCommand.Parameters.AddWithValue("@turno", prof.turno);
                    myCommand.Parameters.AddWithValue("@codigo_unidade", prof.Unidades);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Inserido com sucesso!");

        }
        [HttpPut]
        public JsonResult Put(Professores prof)
        {
            string query = @"
                        update professores
                        set salario = @salario,
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
                        instrutor = @instrutor,
                        personal = @personal,
                        professor = @professor,
                        turno = @turno,
                        codigo_unidade = @codigo_unidade
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
                    myCommand.Parameters.AddWithValue("@codigo", prof.ProfessoresID);
                    myCommand.Parameters.AddWithValue("@salario", prof.salario);
                    myCommand.Parameters.AddWithValue("@nome", prof.nome);
                    myCommand.Parameters.AddWithValue("@cpf", prof.cpf);
                    myCommand.Parameters.AddWithValue("@datanasc", prof.datanasc);
                    myCommand.Parameters.AddWithValue("@data_cadastro", prof.data_cadastro);
                    myCommand.Parameters.AddWithValue("@email", prof.email);
                    myCommand.Parameters.AddWithValue("@celular", prof.celular);
                    myCommand.Parameters.AddWithValue("@sexo", prof.sexo);
                    myCommand.Parameters.AddWithValue("@cep", prof.cep);
                    myCommand.Parameters.AddWithValue("@rua", prof.rua);
                    myCommand.Parameters.AddWithValue("@numero", prof.numero);
                    myCommand.Parameters.AddWithValue("@bairro", prof.bairro);
                    myCommand.Parameters.AddWithValue("@cidade", prof.cidade);
                    myCommand.Parameters.AddWithValue("@estado", prof.estado);
                    myCommand.Parameters.AddWithValue("@instrutor", prof.instrutor);
                    myCommand.Parameters.AddWithValue("@personal", prof.personal);
                    myCommand.Parameters.AddWithValue("@professor", prof.professor);
                    myCommand.Parameters.AddWithValue("@turno", prof.turno);
                    myCommand.Parameters.AddWithValue("@codigo_unidade", prof.Unidades);
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
                        delete from professores
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
