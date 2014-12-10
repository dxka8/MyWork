using System;
using System.Web.Mvc;
using Admin.Compoent.Tool;
using Admin.Compoent.Tool.Extend;
using Admin.Compoent.Tool.Unity;
using Admin.Demo.ISite;
using Admin.Demo.Site.Models;


namespace Admin.Controllers
{
 
    public class HomeController : Controller
    {

        private static IAccountSiteContract AccountContract { get; set; }
        public HomeController(IAccountSiteContract accountSiteContract)
        {
            AccountContract = accountSiteContract;
        }      
        #region 属性

        #endregion
        // GET: Home
        public ActionResult Login()
        {
            string returnUrl = Request.Params["returnUrl"];
            returnUrl = returnUrl ?? Url.Action("Login", "Home", new { area = "" });
            var model = new LoginModel
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            //try
            //{
                OperationResult result = AccountContract.Login(model);
                
                var msg = result.Message ?? result.ResultType.ToDescription();
                if (result.ResultType == OperationResultType.Success)
                {
                    return Redirect(model.ReturnUrl);
                }
                ModelState.AddModelError("", msg);
                return View(model);
            //}
            //catch (Exception e)
            //{
            //    ModelState.AddModelError("", e.Message);
            //    return View(model);
            //}
        }
       
    }
}