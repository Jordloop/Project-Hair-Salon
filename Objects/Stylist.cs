using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSalon
{
  public class Stylist
  {
    private int _id;
    private string _name;
    // private int _clientId;

    public Stylist(string Name, int Id = 0)
    {
      _id = Id;
      _name = Name;
    }
//----GETTERS
    public string GetName()
    {
      return _name;
    }

    public int GetId()
    {
      return _id;
    }
//----SETTERS
    public void SetName(string newName)
    {
      _name = newName;
    }
//----CALSS METHODS
//GetAll
    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM stylists;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while (rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string stylistName = rdr.GetString(1);

        Stylist newStylist = new Stylist( stylistName, stylistId);
        allStylists.Add(newStylist);
      }

      if (rdr != null)
        {
          rdr.Close();
        }
        if (conn != null)
        {
          conn.Close();
        }

        return allStylists;
    }

//DeleteAll




// End -----------------------------------------------
  }
}