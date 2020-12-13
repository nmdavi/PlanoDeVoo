using PlanoDeVoo.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using static PlanoDeVoo.Models.PlanoModels;

namespace PlanoDeVoo.Controllers
{
    public class HomeController : Controller
    {
        private readonly EFContext _ctx;

        public HomeController(EFContext ctx)
        {
            _ctx = ctx;
        }

        public ActionResult Index()
        {
            return View(_ctx.Planos.ToList());
        }

        [HttpGet]
        public ActionResult AddEdit(int? id)
        {
            var model = _ctx.Planos.Find(id);

            if (model == null)
            {
                return View(new Plano());
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult AddEdit(Plano model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _ctx.Planos.Add(model);
                }
                else
                {
                    _ctx.Entry(model).State = EntityState.Modified;
                }

                _ctx.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Delete(int? id)
        {
            var model = _ctx.Planos.Find(id);

            _ctx.Planos.Remove(model);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
