using FI.AtividadeEntrevista.BLL;
using WebAtividadeEntrevista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FI.AtividadeEntrevista.DML;

namespace WebAtividadeEntrevista.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Incluir()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Incluir(ClienteModel model, List<string> bNome, List<string> bCPF, List<BeneficiarioModel> benModel)
        {
            BoCliente bo = new BoCliente();            
            
            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {

                var hasCPF = bo.VerificarExistencia(model.CPF);
                
                if(hasCPF == true)
                {
                    Response.StatusCode = 400;
                    return Json("CPF ja cadastrado");
                }
                else
                {
                    model.Id = bo.Incluir(new Cliente()
                    {
                        CEP = model.CEP,
                        Cidade = model.Cidade,
                        Email = model.Email,
                        Estado = model.Estado,
                        Logradouro = model.Logradouro,
                        Nacionalidade = model.Nacionalidade,
                        Nome = model.Nome,
                        Sobrenome = model.Sobrenome,
                        Telefone = model.Telefone,
                        CPF = model.CPF
                    });


                    foreach (var i in benModel)
                    {
                        if(i.CPF != null)
                        {
                            BoBeneficiarios boBen = new BoBeneficiarios();
                            Beneficiario modelBen = new Beneficiario();
                            modelBen.CPF = i.CPF;
                            modelBen.Nome = i.Nome;
                            modelBen.IdCliente = model.Id;

                            boBen.Incluir(modelBen);
                        }                        
                    }

                  
                    return Json("Cadastro efetuado com sucesso");
                }                
            }
        }

        [HttpPost]
        public JsonResult Alterar(ClienteModel model, List<BeneficiarioModel> benModel, List<int> ArrIdBeneficiariosExcluir)
        {
            BoCliente bo = new BoCliente();
       
            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                bo.Alterar(new Cliente()
                {
                    Id = model.Id,
                    CEP = model.CEP,
                    Cidade = model.Cidade,
                    Email = model.Email,
                    Estado = model.Estado,
                    Logradouro = model.Logradouro,
                    Nacionalidade = model.Nacionalidade,
                    Nome = model.Nome,
                    Sobrenome = model.Sobrenome,
                    Telefone = model.Telefone,
                    CPF = model.CPF
                });


                foreach (var i in benModel)
                {
                    if (i.CPF != null)
                    {

                        if(i.Id == 0)
                        {
                            BoBeneficiarios boBen = new BoBeneficiarios();
                            Beneficiario modelBen = new Beneficiario();
                            modelBen.CPF = i.CPF;
                            modelBen.Nome = i.Nome;
                            modelBen.IdCliente = model.Id;

                            boBen.Incluir(modelBen);
                        }
                        else
                        {
                            BoBeneficiarios boBen = new BoBeneficiarios();
                            boBen.Alterar(new Beneficiario()
                            {
                                Id = i.Id,
                                CPF = i.CPF,
                                Nome = i.Nome,
                                IdCliente = model.Id

                            });

                        }

                        
                    }
                }

                foreach (var id in ArrIdBeneficiariosExcluir)
                {
                    BoBeneficiarios boBen = new BoBeneficiarios();
                    boBen.Excluir(id);

                }

                return Json("Cadastro alterado com sucesso");
            }
        }

        [HttpGet]
        public ActionResult Alterar(long id)
        {
            BoCliente bo = new BoCliente();
            BoBeneficiarios boBen = new BoBeneficiarios();
            Cliente cliente = bo.Consultar(id);
            Models.ClienteModel model = null;

            if (cliente != null)
            {
                model = new ClienteModel()
                {
                    Id = cliente.Id,
                    CEP = cliente.CEP,
                    Cidade = cliente.Cidade,
                    Email = cliente.Email,
                    Estado = cliente.Estado,
                    Logradouro = cliente.Logradouro,
                    Nacionalidade = cliente.Nacionalidade,
                    Nome = cliente.Nome,
                    Sobrenome = cliente.Sobrenome,
                    Telefone = cliente.Telefone,
                    CPF = cliente.CPF
                };            
            }
            var idCliente = id;
            List<Beneficiario> beneficiario = boBen.Consultar(idCliente);
            model.Beneficiarios = new List<Beneficiario>();
            model.Beneficiarios = beneficiario;

            return View(model);
        }

        [HttpPost]
        public JsonResult ClienteList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                int qtd = 0;
                string campo = string.Empty;
                string crescente = string.Empty;
                string[] array = jtSorting.Split(' ');

                if (array.Length > 0)
                    campo = array[0];

                if (array.Length > 1)
                    crescente = array[1];

                List<Cliente> clientes = new BoCliente().Pesquisa(jtStartIndex, jtPageSize, campo, crescente.Equals("ASC", StringComparison.InvariantCultureIgnoreCase), out qtd);

                //Return result to jTable
                return Json(new { Result = "OK", Records = clientes, TotalRecordCount = qtd });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
    }
}