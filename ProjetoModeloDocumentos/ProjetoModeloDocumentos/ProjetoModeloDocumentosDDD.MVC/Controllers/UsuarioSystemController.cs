
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDocumentosDDD.Application.Interface;
using ProjetoModeloDocumentosDDD.Domain.Entites;
using PagedList;
using ProjetoModeloDocumentosDDD.MVC.ViewModels;
using System;

namespace ProjetoModeloDocumentosDDD.MVC.Controllers
{
    public class UsuarioSystemController : Controller
    {

        // private readonly  UsuarioSystemRepository _usuarioSystemRepository = new UsuarioSystemRepository();

        //================Usuario System========================
        private readonly IUsuarioSystemAppService _iUsuarioSystemAppService;

        //=================Rg==================================
        private readonly IRgAppService _rgAppService;

        //================Cpf===============================
        private readonly ICpfAppService _cpfAppService;

        //================Cnh==============================
        private readonly ICnhAppService _cnhAppService;

        //===============Usuarios========================
        private readonly IUsuarioAppService _usuarioApp;

        public UsuarioSystemController(IUsuarioSystemAppService iUsuarioSystemAppService, IRgAppService rgAppService, ICpfAppService cpfAppService, ICnhAppService cnhAppService, IUsuarioAppService usuarioApp)
        {
            _iUsuarioSystemAppService = iUsuarioSystemAppService;
            _rgAppService = rgAppService;
            _cpfAppService = cpfAppService;
            _cnhAppService = cnhAppService;
            _usuarioApp = usuarioApp;
        }

        // GET: UsuarioSystem
        public ActionResult Index()
        {
            if (Session["LogarUserId"] != null && Session["NivelUsuarioSystem"].ToString() == "1")
            {


                var usuarioSystemViewModel = Mapper.Map<IEnumerable<UsuarioSystemViewModel>>(_iUsuarioSystemAppService.GetAll());
                return View(usuarioSystemViewModel);

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: UsuarioSystem/Details/5
        public ActionResult Details(int id)
        {
            if (Session["LogarUserId"] != null && Session["NivelUsuarioSystem"].ToString() == "1")
            {

            var usuarioSytem = _iUsuarioSystemAppService.GetById(id);
            var usuarioSystemViewModel = Mapper.Map<UsuarioSystem, UsuarioSystemViewModel>(usuarioSytem);

            return View(usuarioSystemViewModel);

            }
             else
             {
                 return RedirectToAction("Index", "Home");
             }
        }

        // GET: UsuarioSystem/Create
        public ActionResult Create()
        {
            if (Session["LogarUserId"] != null && Session["NivelUsuarioSystem"].ToString() == "1")
            {

            return View();


            }
        else
        {
            return RedirectToAction("Index", "Home");
        }

        }

        // POST: UsuarioSystem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioSystemViewModel usuario)
        {

            if (Session["LogarUserId"] != null && Session["NivelUsuarioSystem"].ToString() == "1")
            {


            if (ModelState.IsValid)
            {

                
                var usuarioSystemDomain = Mapper.Map<UsuarioSystemViewModel, UsuarioSystem>(usuario);

                _iUsuarioSystemAppService.Add(usuarioSystemDomain);

                return RedirectToAction("Index");

            }
            return View(usuario);

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        // GET: UsuarioSystem/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["LogarUserId"] != null && Session["NivelUsuarioSystem"].ToString() == "1")
            {

            var usuarioSystem = _iUsuarioSystemAppService.GetById(id);
            var usuarioSystemViewModel = Mapper.Map<UsuarioSystem, UsuarioSystemViewModel>(usuarioSystem);
            return View(usuarioSystemViewModel);


            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: UsuarioSystem/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioSystemViewModel usuarioSystem)
        {
            if (Session["LogarUserId"] != null && Session["NivelUsuarioSystem"].ToString() == "1")
            {

            if (ModelState.IsValid)
            {
                var usuarioSystemDomain = Mapper.Map<UsuarioSystemViewModel, UsuarioSystem>(usuarioSystem);
                _iUsuarioSystemAppService.Update(usuarioSystemDomain);

                return RedirectToAction("Index");
            }

            return View(usuarioSystem);

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: UsuarioSystem/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["LogarUserId"] != null && Session["NivelUsuarioSystem"].ToString() == "1")
            {

            var usuarioSystem = _iUsuarioSystemAppService.GetById(id);
            var usuarioSystemViewModel = Mapper.Map<UsuarioSystem, UsuarioSystemViewModel>(usuarioSystem);
            return View(usuarioSystemViewModel);

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: UsuarioSystem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["LogarUserId"] != null && Session["NivelUsuarioSystem"].ToString() == "1")
            {

            var usuarioSystem = _iUsuarioSystemAppService.GetById(id);
            _iUsuarioSystemAppService.Remove(usuarioSystem);

            return RedirectToAction("Index");

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        //======================Relatorio Documentos==================================

        public ActionResult Relatorio()
        {
            if (Session["LogarUserId"] != null && Session["NivelUsuarioSystem"].ToString() == "1")
            {

            int qtdrgs = 0;

            foreach (var item in _rgAppService.GetAll())
            {
                qtdrgs = qtdrgs + 1;
            }

            ViewBag.QtdRg = qtdrgs;

            int qtdcpf = 0;
            foreach (var item in _cpfAppService.GetAll())
            {
                qtdcpf = qtdcpf + 1;
            }

            ViewBag.QtdCpf = qtdcpf;


            int qtdcnh = 0;
            foreach (var item in _cnhAppService.GetAll())
            {
                qtdcnh = qtdcnh + 1;
            }

            ViewBag.QtdChh = qtdcnh;

            

            return View();

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        //====================Relatorio Usuarios==================================

        public ActionResult RelatorioUser(int? pagina, string n, string procurar)
        {
            if (Session["LogarUserId"] != null && Session["NivelUsuarioSystem"].ToString() == "1")
            {

            int tamanhoPagina = 10;
            int numeroPagina = pagina ?? 1;

            int qtdusuarios = 0;

            foreach(var item in _usuarioApp.GetAll())
            {
                qtdusuarios = qtdusuarios + 1;
            }

            ViewBag.QtdUsuarios = qtdusuarios;

             var usuarioViewModel = Mapper.Map<IEnumerable<UsuarioViewModel>>(_usuarioApp.GetAll());

            if (!String.IsNullOrEmpty(procurar))
            {
                usuarioViewModel = usuarioViewModel.Where(u => u.Nome.ToUpper().Contains(procurar.ToUpper()));
            }
            return View(usuarioViewModel.ToPagedList(numeroPagina,tamanhoPagina));

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        //===================Bloquear Usuario======================================

        public ActionResult BloquearUsuario(int id)
        {
            if (Session["LogarUserId"] != null && Session["NivelUsuarioSystem"].ToString() == "1")
            {

            var usuario = _usuarioApp.GetById(id);
            usuario.Bloquear = true;

            _usuarioApp.Update(usuario);

            return View();

            }
             else
             {
                 return RedirectToAction("Index", "Home");
             }

        }

        //=========================Desbloquear Usuario================================

        public ActionResult DesbloquearUsuario(int id)
        {

            if (Session["LogarUserId"] != null && Session["NivelUsuarioSystem"].ToString() == "1")
            {

                var usuario = _usuarioApp.GetById(id);
                usuario.Bloquear = false;

                _usuarioApp.Update(usuario);

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        //========== Lista De Rg========================

        public ActionResult ListRg(int? pagina, string n, string procurar)
        {
            if (Session["LogarUserId"] != null && Session["NivelUsuarioSystem"].ToString() == "1")
            {

                

            int tamanhoPagina = 10;
            int numeroPagina = pagina ?? 1;
            var rgViewModel = Mapper.Map<IEnumerable<RgViewModel>>(_rgAppService.GetAll());

            ViewBag.NomeParam = String.IsNullOrEmpty(n) ? "Nome_desc" : "";

            if (!String.IsNullOrEmpty(procurar))
            {
                rgViewModel = rgViewModel.Where(r => r.NomeDaPessoCompleto.ToUpper().Contains(procurar.ToUpper()));

            }

            switch (n)
            {
                case "Nome_desc":

                    rgViewModel = rgViewModel.OrderByDescending(r => r.NomeDaPessoCompleto);
                    break;
            }
            return View(rgViewModel.ToPagedList(numeroPagina, tamanhoPagina));

                 }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }



        //=====================List Cpf===================================
        public ActionResult ListCpf(int? pagina, string n, string procurar)
        {
            if (Session["LogarUserId"] != null && Session["NivelUsuarioSystem"].ToString() == "1")
            {

            int tamanhoPagina = 10;
            int numeroPagina = pagina ?? 1;
            var cpfViewModel = Mapper.Map<IEnumerable<CpfViewModel>>(_cpfAppService.GetAll());

            ViewBag.NomeParam = String.IsNullOrEmpty(n) ? "Nome_desc" : "";

            if (!String.IsNullOrEmpty(procurar))
            {
                cpfViewModel = cpfViewModel.Where(c => c.NomeDaPessoaCompleto.ToUpper().Contains(procurar.ToUpper()));
            }

            switch (n)
            {
                case "Nome_desc":

                    cpfViewModel.OrderByDescending(c => c.NomeDaPessoaCompleto);

                    break;
            }

            return View(cpfViewModel.ToPagedList(numeroPagina, tamanhoPagina));

                 }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }




        //==========================List Cnh====================================
        public ActionResult ListCnh(int? pagina, string n, string procurar)
        {
            if (Session["LogarUserId"] != null && Session["NivelUsuarioSystem"].ToString() == "1")
            {

            int tamanhoPagina = 10;
            int numeroPagina = pagina ?? 1;
            var cnhViewModel = Mapper.Map<IEnumerable<CnhViewModel>>(_cnhAppService.GetAll());

            ViewBag.NomeParam = String.IsNullOrEmpty(n) ? "Nome_desc" : "";

            if (!String.IsNullOrEmpty(procurar))
            {
                cnhViewModel = cnhViewModel.Where(cn => cn.NomeDaPessoaCompleto.ToUpper().Contains(procurar.ToUpper()));
            }

            switch (n)
            {
                case "Nome_desc":
                    cnhViewModel = cnhViewModel.OrderByDescending(cn => cn.NomeDaPessoaCompleto);
                    break;
            }
            return View(cnhViewModel.ToPagedList(numeroPagina, tamanhoPagina));

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
