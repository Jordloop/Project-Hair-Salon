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

      //stylist/all -> all-stylist.cshtml
      Get["/stylist/all"] = _ => {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["all-stylist.cshtml", allStylists];
      };

      //stylist/add -> add-stylist.cshtml
      Get["/stylist/add"] = _ => {
        return View["add-stylist.cshtml"];
      };

      Post["/stylist/add"] = _ => {
        Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
        newStylist.Save();
        List<Stylist> allStylists = Stylist.GetAll();
        return View["all-stylist.cshtml", allStylists];
      };

      //stylist/add -> all-stylist
      Post["/stylist/delete-all"] = _ => {
        Stylist.DeleteAll();
        List<Stylist> allStylists = Stylist.GetAll();
        return View["all-stylist.cshtml", allStylists];
      };

      Get["/stylist/view/{id}"] = param => {
        Dictionary<string, object> model = new Dictionary <string, object>();
        Stylist selectedStylist = Stylist.Find(param.id);
        List<Client> stylistClients = selectedStylist.GetClient();

        model.Add("Stylist", selectedStylist);
        model.Add("Clients", stylistClients);
        return View["view-stylist.cshtml", model];
      };

    }
  }
}
