

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
    public class CpfController : Controller
    {
       // private readonly CpfRepository _cpfRepository = new CpfRepository();

        private readonly ICpfAppService _cpfAppService;
        private readonly IUsuarioAppService _usuarioApp;

        public CpfController(ICpfAppService cpfAppService, IUsuarioAppService usuarioApp)
        {
            _cpfAppService = cpfAppService;
            _usuarioApp = usuarioApp;
        }

        // GET: Cpf
        public ActionResult Index()
        {
            if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] !=null)
            {

            var cpfViewModel = Mapper.Map<IEnumerable<CpfViewModel>>(_cpfAppService.GetAll());
            return View(cpfViewModel);

            }
            else
            {
                return RedirectToAction("Bloq", "Home");
            }
        }

        // GET: Cpf/Details/5
        public ActionResult Details(int id)
        {
            if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] !=null)
            {

            var cpf = _cpfAppService.GetById(id);
            var cfpModel = Mapper.Map<Cpf, CpfViewModel>(cpf);

            return View(cfpModel);

            }
            else
            {
                return RedirectToAction("Bloq", "Home");
            }

        }

        // GET: Cpf/Create
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

        // POST: Cpf/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CpfViewModel cpf)
        {
             if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] !=null)
            {


            if (ModelState.IsValid)
            {
                if (Session["LogarUsuarioId"] != null)
                {
                    var cpfDomain = Mapper.Map<CpfViewModel, Cpf>(cpf);
                    
                    cpfDomain.UsuarioId = Int32.Parse(Session["LogarUsuarioId"].ToString());
                    _cpfAppService.Add(cpfDomain);
                    return RedirectToAction("Index");
                }
            }

            return View(cpf);

            }
             else
             {
                 return RedirectToAction("Bloq", "Home");
             }

        }

        // GET: Cpf/Edit/5
        public ActionResult Edit(int id)
        {
              if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] !=null)
            {

            var cpf = _cpfAppService.GetById(id);
            var cfpModel = Mapper.Map<Cpf, CpfViewModel>(cpf);
            
            return View(cfpModel);

            }
              else
              {
                  return RedirectToAction("Bloq", "Home");
              }
        }

        // POST: Cpf/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CpfViewModel cpf)
        {
               if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] !=null)
                {

            if (ModelState.IsValid)
            {
                if (Session["LogarUsuarioId"] != null)
                {

                    var cpfDomain = Mapper.Map<CpfViewModel, Cpf>(cpf);
                    cpfDomain.UsuarioId = Int32.Parse(Session["LogarUsuarioId"].ToString());
                    _cpfAppService.Update(cpfDomain);

                    return RedirectToAction("Index");
                }

            }
            return View(cpf);


            }
               else
               {
                   return RedirectToAction("Bloq", "Home");
               }
        }

        // GET: Cpf/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] !=null)
                {

            var cpf = _cpfAppService.GetById(id);
            var cfpModel = Mapper.Map<Cpf, CpfViewModel>(cpf);

            return View(cfpModel);


                }
            else
            {
                return RedirectToAction("Bloq", "Home");
            }
        }

        // POST: Cpf/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] !=null)
                {

            var cpf = _cpfAppService.GetById(id);
            _cpfAppService.Remove(cpf);

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

        public ActionResult Email(int id)
        {
            if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] !=null)
                {
            if (Session["LogarUserIdComun"] != null)
            {
                var cpf = _cpfAppService.GetById(id);
                var cpfViewModel = Mapper.Map<Cpf, CpfViewModel>(cpf);


                var iduser = _usuarioApp.GetById(cpfViewModel.UsuarioId);
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
