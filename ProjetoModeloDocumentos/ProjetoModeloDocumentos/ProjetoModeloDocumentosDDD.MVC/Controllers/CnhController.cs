

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using PagedList;
using ProjetoModeloDocumentosDDD.Application.Interface;
using ProjetoModeloDocumentosDDD.Domain.Entites;
using ProjetoModeloDocumentosDDD.MVC.ViewModels;
using MimeKit;
using MailKit.Net.Smtp;

namespace ProjetoModeloDocumentosDDD.MVC.Controllers
{
    public class CnhController : Controller
    {
       // private readonly CnhRepository _cnhRepository = new CnhRepository();

        private readonly ICnhAppService _cnhAppService;
        private readonly IUsuarioAppService _usuarioApp;

        public CnhController(ICnhAppService cnhAppService, IUsuarioAppService usuarioApp)
        {
            _cnhAppService = cnhAppService;
            _usuarioApp = usuarioApp;
        }

        // GET: Cnh
        public ActionResult Index()
        {
            if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] !=null)
            {

            var cnhViewModel = Mapper.Map<IEnumerable<CnhViewModel>>(_cnhAppService.GetAll());
            return View(cnhViewModel);

            }
            else
            {
                return RedirectToAction("Bloq", "Home");
            }
        }

        // GET: Cnh/Details/5
        public ActionResult Details(int id)
        {
            if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] !=null)
            {

            var cnh = _cnhAppService.GetById(id);
            var cnhViewModel = Mapper.Map<Cnh, CnhViewModel>(cnh);
            return View(cnhViewModel);

            }
            else
            {
                return RedirectToAction("Bloq", "Home");
            }
        }

        // GET: Cnh/Create
        public ActionResult Create()
        {
            if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] !=null)
            {

            return View();

            }
            else
            {
                return RedirectToAction("Bloq", "Home");
            }
        }

        // POST: Cnh/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CnhViewModel cnh)
        {
            if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] !=null)
            {

            if (ModelState.IsValid)
            {
                if (Session["LogarUsuarioId"] != null)
                {
                    var cnhDomain = Mapper.Map<CnhViewModel, Cnh>(cnh);
                   
                    cnhDomain.UsuarioId = Int32.Parse(Session["LogarUsuarioId"].ToString());
                    _cnhAppService.Add(cnhDomain);
                    return RedirectToAction("Index");
                }
            }
            return View(cnh);
            }
            else
            {
                return RedirectToAction("Bloq", "Home");
            }
        }

        // GET: Cnh/Edit/5
        public ActionResult Edit(int id)
        {
             if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] !=null)
            {

            var cnh = _cnhAppService.GetById(id);
            var cnhViewModel = Mapper.Map<Cnh, CnhViewModel>(cnh);
            return View(cnhViewModel);

            }
             else
             {
                 return RedirectToAction("Bloq", "Home");
             }
        }

        // POST: Cnh/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CnhViewModel cnh)
        {
             if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] !=null)
            {

            if (ModelState.IsValid)
            {
                if (Session["LogarUsuarioId"] != null)
                {

                    var cnhDomain = Mapper.Map<CnhViewModel, Cnh>(cnh);
                    cnhDomain.UsuarioId = Int32.Parse(Session["LogarUsuarioId"].ToString());
                    _cnhAppService.Update(cnhDomain);
                    return RedirectToAction("Index");
                }
            }

            return View(cnh);

            }
             else
             {
                 return RedirectToAction("Bloq", "Home");
             }
        }

        // GET: Cnh/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] !=null)
            {

            var cnh = _cnhAppService.GetById(id);
            var cnhViewModel = Mapper.Map<Cnh, CnhViewModel>(cnh);
            return View(cnhViewModel);

            }
            else
            {
                return RedirectToAction("Bloq", "Home");
            }
        }

        // POST: Cnh/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] !=null)
            {

            var cnh = _cnhAppService.GetById(id);
            _cnhAppService.Remove(cnh);

            return RedirectToAction("Index");

            }
            else
            {
                return RedirectToAction("Bloq", "Home");
            }
        }

        public ActionResult Buscar(int? pagina, string n, string procurar)
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

        public ActionResult Email(int id)
        {
             if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] !=null)
            {

            if (Session["LogarUserIdComun"] != null)
            {
                var cnh = _cnhAppService.GetById(id);
                var cnhViewModel = Mapper.Map<Cnh, CnhViewModel>(cnh);


                var iduser = _usuarioApp.GetById(cnhViewModel.UsuarioId);
                var emailuser = iduser.Email;
                var nomeuser = iduser.Nome;
                var telefone = iduser.Telefone;

                //=======Email==========
                var msg = new MimeMessage();
                msg.From.Add(new MailboxAddress("Achei", "achei.expert@gmail.com"));
                msg.To.Add(new MailboxAddress(nomeuser, emailuser));
                msg.Subject = "Site Achei";
                var nomedes = Session["LogarUserIdComun"].ToString();
                var emaildes = Session["EmailUser"].ToString();
                msg.Body = new TextPart("html")
                {
                    Text = @"
   Ola " + nomeuser + " Gostaria de Entrar em contato com Voçê esse documento me pertence ou conheço o dono Meu nome e " + nomedes + " Meu email para contato " + emaildes + " Meu Telefone para entra em contato " + telefone


                };

                var smtp = new SmtpClient();
                smtp.Connect("smtp.gmail.com", 465, true);
                smtp.Authenticate("achei.expert@gmail.com", "expertunibratec");

                smtp.Send(msg);
                smtp.Disconnect(true);

                return View("Email");
            }

            return View("Index");

            }
             else
             {
                 return RedirectToAction("Bloq", "Home");
             }
        }
    }
}
