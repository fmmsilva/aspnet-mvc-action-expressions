aspnet-mvc-action-expressions
=============================

ASP.Net MVC Library for calling Controller Actions with expressions from razor views.


Usage
======

public class HomeController : Controller {
    
    public ActionResult Index(int id) 
    {
        return View();
    }

}

@(Url.Action&lt;HomeController&gt;(c=>c.Index(1))) becomes /Home/Index/1
