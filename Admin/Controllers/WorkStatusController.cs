using System;
using System.Web.Mvc;
using Domain.ModelView;
using Servico.Service;

namespace Admin.Controllers
{
    public class WorkStatusController : Controller
    {
        [HttpPost]
        public ActionResult JobStatus(JobStatusModelView model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            if (ModelState.IsValid)
            {
                model.user = User.Identity.Name;
                model.status = 1;
                if (model.jobstatusid != 0) //update
                {
                    ServiceJobStatus.UpdateJobStatus(model);
                }
                else //insert
                {
                    ServiceJobStatus.InsertJobStatus(model);
                }
                return Redirect(Domain.Util.config.UrlSite + "WorkStatus/JobStatus/" + model.menuid + "/" + model.menusubid);

            }
            model.JobStatus = ServiceJobStatus.getJobStatus();

            return View(model);
        }

        [HttpGet]
        public ActionResult JobStatus(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            var model = new JobStatusModelView();

            ViewBag.PageTopInformation = "Job Status Form";
            ViewBag.Acao = "Job Status Add";

            if (id3 != 0)
            {
                //busca as informações para edição
                model = ServiceJobStatus.GetJobStatusId(id3);
                ViewBag.Acao = "Job Status Edit";
            }

            model.JobStatus = ServiceJobStatus.getJobStatus();
            model.menuid = id;
            model.menusubid = id2;
            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;
            return View(model);
        }


        public ActionResult JobStatusDelete(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            if (id3 != 0)
            {
                //exclui registro
                ServiceJobStatus.DeleteJobStatusId(id3); 
            }

            return Redirect(Domain.Util.config.UrlSite + "WorkStatus/JobStatus/" + id + "/" + id2);
        }
    }
}
