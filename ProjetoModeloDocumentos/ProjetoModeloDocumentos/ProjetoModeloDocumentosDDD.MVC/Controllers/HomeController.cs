

using System.Web.Mvc;
using System.Web.Security;
using ProjetoModeloDocumentosDDD.Application.Interface;
using MailKit.Net.Smtp;
using System;
using MimeKit;

namespace ProjetoModeloDocumentosDDD.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsuarioSystemAppService _iUsuarioSystemAppService;
        private readonly IUsuarioAppService _usuarioApp;

        public HomeController(IUsuarioSystemAppService iUsuarioSystemAppService, IUsuarioAppService usuarioApp)
        {
            _iUsuarioSystemAppService = iUsuarioSystemAppService;
            _usuarioApp = usuarioApp;
        }



        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Sobre()
        {
            ViewBag.Message = "Your sobre page.";

            return View();
        }

        //======================Login Admin =======================

        public ActionResult Login()
        {
            if (Session["LogarUserId"] == null && Session["LogarUserIdComun"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string login ,string senha)
        {
            if (ModelState.IsValid)
            {
               


                foreach (var item in _iUsuarioSystemAppService.GetAll())
                {

                    if (item.Login == login && item.senha == senha)
                    {
                     var   u = _iUsuarioSystemAppService.GetById(item.UsuarioSystemId);

                        if (u != null)
                        {
                            Session["LogarUserId"] = u.Login.ToString();
                            Session["IdAdminSystem"] = u.UsuarioSystemId.ToString();
                            Session["NivelUsuarioSystem"] = u.Nivel.ToString();
                            return RedirectToAction("LoginSucess");
                        }
                       
                }
                 
                }
            }

            return View("ErroLogin");
        }

        public ActionResult LoginSucess()
        {
            if (Session["LogarUserId"] != null)
            {
                return View();
               
            }else  
            {
                return RedirectToAction("Index");
            }

            
        }


        public ActionResult LogOut()
        {
            
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");
        }

        //=========================Login Usuarios ================================
        public ActionResult LoginUser()
        {
            if (Session["LogarUserIdComun"] == null && Session["LogarUserId"] == null )
            {
                return View();
            }
            else 
            {
                return RedirectToAction("Bloq");
                }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginUser(string login, string senha)
        {
            




                if (ModelState.IsValid)
                {



                    foreach (var item in _usuarioApp.GetAll())
                    {

                        if (item.Login == login && item.Senha == senha && item.Bloquear == false)
                        {
                            var u = _usuarioApp.GetById(item.UsuarioId);

                            if (u != null)
                            {
                                Session["LogarUserIdComun"] = u.Nome.ToString() + " " + u.SobreNome.ToString();
                                Session["LogarUsuarioId"] = u.UsuarioId.ToString();
                                Session["EmailUser"] = u.Email.ToString();
                                Session["UsuarioNome"] = u.Nome.ToString();
                                Session["Desbloqueado"] = u.Bloquear.ToString();

                                return RedirectToAction("LoginSucessUser");
                            }

                        }
                        else if (item.Login == login && item.Senha == senha && item.Bloquear == true)
                        {
                            var u = _usuarioApp.GetById(item.UsuarioId);

                            if (u != null)
                            {
                                Session["LogarUserIdComun"] = u.Nome.ToString() + " " + u.SobreNome.ToString();
                                Session["LogarUsuarioId"] = u.UsuarioId.ToString();
                                Session["EmailUser"] = u.Email.ToString();
                                Session["UsuarioNome"] = u.Nome.ToString();
                                Session["Bloqueado"] = u.Bloquear.ToString();

                                return RedirectToAction("Bloq");
                            }
                        }

                    }
                }
            
            

            return View("ErroLogin");
        }


        public ActionResult Bloq()
        {
            if (Session["LogarUserIdComun"] != null && Session["Bloqueado"] != null)
            {
                return View();

            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public ActionResult LoginSucessUser()
        {
            if (Session["LogarUserIdComun"] != null )
            {
                return View();

            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public ActionResult ErroLogin()
        {
            return View();
        }


        //==============Email===========================
        public ActionResult Email()
        {
            var msg = new MimeMessage();
            msg.From.Add(new MailboxAddress("Indicacao", "indicacao.certa@gmail.com"));
            msg.To.Add(new MailboxAddress("Deyvison", "debo.deyvison@gmail.com"));
            msg.Subject = "Assunto da Mensagem";

            msg.Body = new TextPart("html")
            {
                Text = @"
    CORPO DA MENSAGEM
        "

            };

            var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 465, true);
            smtp.Authenticate("indicacao.certa@gmail.com", "icemailsenha");

            smtp.Send(msg);
            smtp.Disconnect(true);

            return View();    
        }


      
        
    }
}