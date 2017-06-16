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
        return View["confirmed.cshtml"];
      };

      Get["/stylist/view/{id}"] = param => {
        Dictionary<string, object> model = new Dictionary <string, object>();
        Stylist selectedStylist = Stylist.Find(param.id);
        List<Client> stylistClients = selectedStylist.GetClient();

        model.Add("Stylist", selectedStylist);
        model.Add("Clients", stylistClients);
        return View["view-stylist.cshtml", model];
      };


      Get["/client/add"] = _ => {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["add-client.cshtml", allStylists];
      };

      Post["/client/add"] = _ => {
        Client newClient = new Client(Request.Form["client-name"], Request.Form["stylist-id"]);
        newClient.Save();
        List<Client> allClients = Client.GetAll();
        return View["all-client.cshtml", allClients];
      };

      Delete["/client/delete/{id}"] = param => {
        Client selectedClient = Client.Find(param.id);
        selectedClient.Delete();
        return View["confirmed.cshtml"];
      };

      Get["/client/edit/{id}"] = param => {
        Client selectedClient = Client.Find(param.id);
        return View["edit-client.cshtml", selectedClient];
      };

      Patch["client/edit/{id}"] = param => {
        Client SelectedClient = Client.Find(param.id);
        SelectedClient.Update(Request.Form["edit-client"]);
        return View["confirmed.cshtml"];
      };
    }
  }
}
