

using System.Collections.Generic;
using System.Net.Mail;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDocumentosDDD.Application.Interface;
using ProjetoModeloDocumentosDDD.Domain.Entites;

using ProjetoModeloDocumentosDDD.MVC.ViewModels;
using System.Web.Security;


namespace ProjetoModeloDocumentosDDD.MVC.Controllers
{
    public class UsuariosController : Controller
    {
        // private readonly UsuarioRepository _usuarioRepository = new UsuarioRepository();

        private readonly IUsuarioAppService _usuarioApp;

        public UsuariosController(IUsuarioAppService usuarioApp)
        {
            _usuarioApp = usuarioApp;
        }

        // GET: Usuarios
        public ActionResult Index()
        {
            if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] !=null)
            {

            var usuarioViewModel = Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_usuarioApp.GetAll());


            return View(usuarioViewModel);

            }
            else
            {
                return RedirectToAction("Bloq", "Home");
            }
           
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
             if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] !=null)
            {

            var usuario = _usuarioApp.GetById(id);
            var usuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(usuario);

            return View(usuarioViewModel);

            }
             else
             {
                 return RedirectToAction("Bloq", "Home");
             }
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
             if (Session["LogarUserIdComun"] == null )
            {

            return View();

            }
             else
             {
                 return RedirectToAction("Index", "Home");
             }
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel usuario)
        {
            if (Session["LogarUserIdComun"] == null )
            {

            if (ModelState.IsValid)
            {
                var usuarioDomain = Mapper.Map<UsuarioViewModel, Usuario>(usuario);

                _usuarioApp.Add((usuarioDomain));

                return RedirectToAction("CadatroSucessUsuarios");
            }

            return View(usuario);

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult CadatroSucessUsuarios()
        {
             if (Session["LogarUserIdComun"] == null )
            {
            return View();

            }
             else
             {
                 return RedirectToAction("Index", "Home");
             }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] !=null)
            {

            var usuario = _usuarioApp.GetById(id);
            var usuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(usuario);

            return View(usuarioViewModel);

            }
            else
            {
                return RedirectToAction("Bloq", "Home");
            }

        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioViewModel usuario)
        {
            if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] !=null)
            {

            if (ModelState.IsValid)
            {
                var usuarioDomain = Mapper.Map<UsuarioViewModel, Usuario>(usuario);
                _usuarioApp.Update(usuarioDomain);

                return RedirectToAction("Index");
            }

            return View(usuario);

            }
            else
            {
                return RedirectToAction("Bloq", "Home");
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] !=null)
            {

            var usuario = _usuarioApp.GetById(id);
            var usuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(usuario);

            return View(usuarioViewModel);

            }
            else
            {
                return RedirectToAction("Bloq", "Home");
            }
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
             if (Session["LogarUserIdComun"] != null && Session["Desbloqueado"] !=null)
            {

            var usuario = _usuarioApp.GetById(id);

            _usuarioApp.Remove(usuario);

            return RedirectToAction("Index");

            }
             else
             {
                 return RedirectToAction("Bloq", "Home");
             }
        }



    }
}
