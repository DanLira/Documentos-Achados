

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDocumentosDDD.Application.Interface;
using ProjetoModeloDocumentosDDD.Domain.Entites;
using ProjetoModeloDocumentosDDD.MVC.ViewModels;
using PagedList;
using MailKit.Net.Smtp;

using MimeKit;
using System.Net;

namespace ProjetoModeloDocumentosDDD.MVC.Controllers
{
    public class RgController : Controller
    {
       // private readonly RgRepository _rgRepository = new RgRepository();

        private readonly IRgAppService _rgAppService;
        private readonly IUsuarioAppService _usuarioApp;

        public RgController(IRgAppService rgAppService, IUsuarioAppService usuarioApp)
        {
            _rgAppService = rgAppService;
            _usuarioApp = usuarioApp;

            
            
        }

        // GET: Rg
        public ActionResult Index()
        {
            if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] !=null)
            {

                var rgViewModel = Mapper.Map<IEnumerable<RgViewModel>>(_rgAppService.GetAll());

                return View(rgViewModel);
            }
            else
            {
                return RedirectToAction("Bloq","Home");
            }
           
        }

       
      
       
        // GET: Rg/Details/5
        public ActionResult Details(int id)
        {
            if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] !=null)
            {

            var rg = _rgAppService.GetById(id);
            
            var rgViewModel = Mapper.Map<Rg, RgViewModel>(rg);

            return View(rgViewModel);

            }
            else
            {
                return RedirectToAction("Bloq", "Home");
            }
           

        }

        // GET: Rg/Create
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

        // POST: Rg/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RgViewModel rg)
        {
            if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] != null)
            {

                if (ModelState.IsValid)
                {
                    if (Session["LogarUsuarioId"] != null)
                    {
                        var rgDomain = Mapper.Map<RgViewModel, Rg>(rg);
                        rgDomain.UsuarioId = Int32.Parse(Session["LogarUsuarioId"].ToString());

                        _rgAppService.Add(rgDomain);

                        return RedirectToAction("Index");
                    }
                }

                return View(rg);

            }
            else
            {
                return RedirectToAction("Bloq", "Home");
            }

        }

        // GET: Rg/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] != null)
            {

            var rg = _rgAppService.GetById(id);
            var rgViewModel = Mapper.Map<Rg, RgViewModel>(rg);
           
            return View(rgViewModel);


            }
            else
            {
                return RedirectToAction("Bloq", "Home");
            }
        }

        // POST: Rg/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RgViewModel rg)
        {
            if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] != null)
            {
            if (ModelState.IsValid)
            {
                if (Session["LogarUsuarioId"] != null)
                {
                    var rgDomain = Mapper.Map<RgViewModel, Rg>(rg);
                    rgDomain.UsuarioId = Int32.Parse(Session["LogarUsuarioId"].ToString());
                    _rgAppService.Update(rgDomain);

                    return RedirectToAction("Index");
                }
            }

            return View(rg);

            }
            else
            {
                return RedirectToAction("Bloq", "Home");
            }

        }

        // GET: Rg/Delete/5
        public ActionResult Delete(int id)
        {
             if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] != null)
            {

            var rg = _rgAppService.GetById(id);
            var rgViewModel = Mapper.Map<Rg, RgViewModel>(rg);

            return View(rgViewModel);

            }
             else
             {
                 return RedirectToAction("Bloq", "Home");
             }

        }

        // POST: Rg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
             if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] != null)
            {

            var rg = _rgAppService.GetById(id);
            _rgAppService.Remove(rg);

            return RedirectToAction("Index");

            }
             else
             {
                 return RedirectToAction("Bloq", "Home");
             }
        }

        public ActionResult Buscar(int? pagina,string n ,string procurar)
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
            return View(rgViewModel.ToPagedList(numeroPagina,tamanhoPagina));
        }



        
     
        public ActionResult Email(int id)
        {
             if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] !=null)
            {

            if (Session["LogarUserIdComun"] != null)
            {
                var rg = _rgAppService.GetById(id);
                var rgViewModel = Mapper.Map<Rg, RgViewModel>(rg);


                var iduser = _usuarioApp.GetById(rgViewModel.UsuarioId);
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
