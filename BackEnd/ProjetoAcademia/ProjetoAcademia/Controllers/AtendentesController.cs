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
    public class AtendentesController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public AtendentesController(IConfiguration configuration, IWebHostEnvironment env)
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
                            turno, acesso, codigo_unidade
                            from 
                            atendentes
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
        public JsonResult Post(Atendentes at)
        {
            string query = @"
                        insert into atendentes
                        (salario, nome, cpf, datanasc, data_cadastro, email,
                            celular, sexo, cep, rua, numero, bairro, cidade, estado,
                            turno, acesso, codigo_unidade)
                        values (@salario, @nome, @cpf, @datanasc, @data_cadastro, @email,
                            @celular, @sexo, @cep, @rua, @numero, @bairro, @cidade, @estado,
                            @turno, @acesso, @codigo_unidade)
                        ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("conexaoMySQL");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@salario", at.salario);
                    myCommand.Parameters.AddWithValue("@nome", at.nome);
                    myCommand.Parameters.AddWithValue("@cpf", at.cpf);
                    myCommand.Parameters.AddWithValue("@datanasc", at.datanasc);
                    myCommand.Parameters.AddWithValue("@data_cadastro", at.data_cadastro);
                    myCommand.Parameters.AddWithValue("@email", at.email);
                    myCommand.Parameters.AddWithValue("@celular", at.celular);
                    myCommand.Parameters.AddWithValue("@sexo", at.sexo);
                    myCommand.Parameters.AddWithValue("@cep", at.cep);
                    myCommand.Parameters.AddWithValue("@rua", at.rua);
                    myCommand.Parameters.AddWithValue("@numero", at.numero);
                    myCommand.Parameters.AddWithValue("@bairro", at.bairro);
                    myCommand.Parameters.AddWithValue("@cidade", at.cidade);
                    myCommand.Parameters.AddWithValue("@estado", at.estado);
                    myCommand.Parameters.AddWithValue("@turno", at.turno);
                    myCommand.Parameters.AddWithValue("@acesso", at.acesso);
                    myCommand.Parameters.AddWithValue("@codigo_unidade", at.codigo_unidade);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Inserido com sucesso!");

        }
        [HttpPut]
        public JsonResult Put(Atendentes at)
        {
            string query = @"
                        update atendentes
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
                        turno = @turno,
                        acesso = @acesso,
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
                    myCommand.Parameters.AddWithValue("@codigo", at.codigo);
                    myCommand.Parameters.AddWithValue("@salario", at.salario);
                    myCommand.Parameters.AddWithValue("@nome", at.nome);
                    myCommand.Parameters.AddWithValue("@cpf", at.cpf);
                    myCommand.Parameters.AddWithValue("@datanasc", at.datanasc);
                    myCommand.Parameters.AddWithValue("@data_cadastro", at.data_cadastro);
                    myCommand.Parameters.AddWithValue("@email", at.email);
                    myCommand.Parameters.AddWithValue("@celular", at.celular);
                    myCommand.Parameters.AddWithValue("@sexo", at.sexo);
                    myCommand.Parameters.AddWithValue("@cep", at.cep);
                    myCommand.Parameters.AddWithValue("@rua", at.rua);
                    myCommand.Parameters.AddWithValue("@numero", at.numero);
                    myCommand.Parameters.AddWithValue("@bairro", at.bairro);
                    myCommand.Parameters.AddWithValue("@cidade", at.cidade);
                    myCommand.Parameters.AddWithValue("@estado", at.estado);
                    myCommand.Parameters.AddWithValue("@turno", at.turno);
                    myCommand.Parameters.AddWithValue("@acesso", at.acesso);
                    myCommand.Parameters.AddWithValue("@codigo_unidade", at.codigo_unidade);
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
                        delete from atendentes
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
