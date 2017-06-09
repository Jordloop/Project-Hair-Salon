using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace HairSalon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      //root -> index.cshtml
      Get["/"] = _ => {
        return View["index.cshtml"];
      };

      Get["/stylist/all"] = _ => {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["all-stylist.cshtml", allStylists];
      };

      Get["/stylist/add"] = _ => {

        return View["add-stylist.cshtml", allStylists];
      };

    }
  }
}
