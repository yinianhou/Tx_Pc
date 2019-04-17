using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using Tx.Bussiness.Interface;
using Tx.EF.Model;
using Tx.Framework.Log;
using TxMvc.Common.Pager;

namespace TxMvc.Controllers
{
    public class HomeController : BaseController
    {

        #region Identity
        private int pageSize = 10;
        private Logger logger = Logger.CreateLogger(typeof(HomeController));
        //private IStudentService _stuService;
        //public HomeController(IStudentService stuService)
        //{
        //    this._stuService = stuService;
        //}
        #endregion
        public ActionResult Index(int pageIndex=1, int pageSize=1)
        {
            logger.Info("测试8888");
            //var result = _stuService.QueryPage<student, bool>(null, pageSize, pageIndex, c => c.stuid != "0");
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
    }
}