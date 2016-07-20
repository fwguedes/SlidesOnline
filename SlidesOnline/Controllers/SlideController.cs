using SlidesOnline.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SlidesOnline.Controllers
{
    public class SlideController : Controller
    {
        // GET: Slide
        public ActionResult Index()
        {
            return View();
        }

        public string Deletar()
        {
            SlideDAO dao = new SlideDAO();
            dao.Deletar();
            return "ok";

        }

        public string Atualizar()
        {

            SlideDAO dao = new SlideDAO();
            dao.Atualizar();

            return "OK";
        }

        public string Listar()
        {

            SlideDAO dao = new SlideDAO();
            string retorno = dao.Listar();

            return retorno;
        }

        public ActionResult Form()
        {

            SlideDAO dao = new SlideDAO();
            dao.Inserir();            

            return RedirectToAction("Index","Home");
        }
    }
}