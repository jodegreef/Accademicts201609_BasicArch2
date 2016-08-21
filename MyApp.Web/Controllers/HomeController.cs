using MyApp.ApplicationServices;
using MyApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private LegoSetApplicationService _legoSetApplicationService;
        private DraftLegoSetApplicationService _draftLegoSetApplicationService;

        public HomeController(
            LegoSetApplicationService legoSetApplicationService,
            DraftLegoSetApplicationService draftLegoSetApplicationService
            )
        {
            _legoSetApplicationService = legoSetApplicationService;
            _draftLegoSetApplicationService = draftLegoSetApplicationService;
        }

        public ActionResult Index()
        {
            var overview = _legoSetApplicationService.GetOverview();

            return View(overview);
        }

        public ActionResult NewDraft(Guid? id)
        {
            Guid draftId;

            if (id == null)
                draftId = _draftLegoSetApplicationService.CreateNewDraft();
            else
                draftId = _draftLegoSetApplicationService.CreateNewDraftForExistingSet(id.Value);

            return RedirectToAction("DraftDetail", new { id= draftId });
        }

        public ActionResult DraftDetail(Guid id)
        {
            var draft = _draftLegoSetApplicationService.GetDraft(id);

            return View(draft);
        }

        [HttpPost]
        public ActionResult Save(DraftLegoSet draft)
        {
            _draftLegoSetApplicationService.SaveDraft(draft);

            return RedirectToAction("Index");
        }

        public ActionResult Publish(Guid id)
        {
            _draftLegoSetApplicationService.Publish(id);

            return RedirectToAction("Index");
        }
    }
}