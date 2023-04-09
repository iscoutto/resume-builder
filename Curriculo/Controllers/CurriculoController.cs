using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using N2B1_Curriculo.Models;
using N2B1_Curriculo.DAO;
using Microsoft.AspNetCore.Http;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace N2B1_Curriculo.Controllers
{
    public class CurriculoController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            try
            {
                CurriculoDAO CurriculoDAO = new CurriculoDAO();
                var lista = CurriculoDAO.Listar();
                return View(lista);
                
            }
            catch (Exception erro)
            {
                return View("error",
                    new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Create()
        {
            try
            {
                ViewBag.Operacao = "I";
                CurriculoDAO dao = new CurriculoDAO();
                CurriculoViewModel curriculo = new CurriculoViewModel();
                return View("Form", curriculo);
            }
            catch (Exception erro)
            {
                return View("error",
                    new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Salvar(CurriculoViewModel curriculo,
                                    string Operacao)
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                if (Operacao == "I")
                {

                    dao.Inserir(curriculo);
                }
                else
                    dao.Alterar(curriculo);
                return RedirectToAction("index");
            }
            catch (Exception erro)
            {
                return View("error",
                    new ErrorViewModel(erro.ToString()));
            }
        }


        public IActionResult Edit(string cpf)
        {
            try
            {
                ViewBag.Operacao = "A";
                CurriculoDAO dao = new CurriculoDAO();
                CurriculoViewModel curriculo = dao.Consulta(cpf);
                if (curriculo == null)
                    return RedirectToAction("index");
                else
                    return View("Form", curriculo);
            }
            catch (Exception erro)
            {
                return View("error",
                    new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Delete(string cpf)
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                dao.Excluir(cpf);
                return RedirectToAction("index");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult CurriculoFormatado(string cpf)
        {
            try
            {
                ViewBag.Operacao = "F";
                CurriculoDAO dao = new CurriculoDAO();
                CurriculoViewModel curriculo = dao.Consulta(cpf);
                if (curriculo == null)
                    return RedirectToAction("index");
                else
                    ViewBag.Cpf = curriculo.Cpf;
                    ViewBag.Nome = curriculo.Nome;
                    ViewBag.Data_nascimento = curriculo.Data_nascimento;
                    ViewBag.Endereco = curriculo.Endereco;
                    ViewBag.Email = curriculo.Email;
                    ViewBag.Pret_salarial = curriculo.Pret_salarial;
                    ViewBag.Cargo_pretendido = curriculo.Cargo_pretendido;
                    ViewBag.Curso1 = curriculo.Curso1;
                    ViewBag.Instituicao1 = curriculo.Instituicao1;
                    ViewBag.Conclusao1 = curriculo.Conclusao1;
                    ViewBag.Curso2 = curriculo.Curso2;
                    ViewBag.Instituicao2 = curriculo.Instituicao2;
                    ViewBag.Conclusao2 = curriculo.Conclusao2;
                    ViewBag.Curso3 = curriculo.Curso3;
                    ViewBag.Instituicao3 = curriculo.Instituicao3;
                    ViewBag.Conclusao3 = curriculo.Conclusao3;
                    ViewBag.Curso4 = curriculo.Curso4;
                    ViewBag.Instituicao4 = curriculo.Instituicao4;
                    ViewBag.Conclusao4 = curriculo.Conclusao4;
                    ViewBag.Curso5 = curriculo.Curso5;
                    ViewBag.Instituicao5 = curriculo.Instituicao5;
                    ViewBag.Conclusao5 = curriculo.Conclusao5;
                    ViewBag.Ex_profissional = curriculo.Ex_profissional;
                    ViewBag.Idiomas = curriculo.Idiomas;
                    ViewBag.Linkedin = curriculo.Linkedin;
                    ViewBag.Telefone = curriculo.Telefone;
                    return View("CurriculoFormatado", curriculo);
            }
            catch (Exception erro)
            {
                return View("error",
                    new ErrorViewModel(erro.ToString()));
            }
        }
    }
}
