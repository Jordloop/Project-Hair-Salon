using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSalon
{
  public class Client
  {
    private int _id;
    private int _clientId;
    private string _name;

    public Client(string Name, int ClientId, int Id = 0)
    {
      _name = Name;
      _clientId = ClientId;
      _id = Id;
    }

//EQUALS OVERRIDE
    public override bool Equals(System.Object otherClient)
    {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = (this.GetId() == newClient.GetId());
        bool nameEquality = (this.GetName() == newClient.GetName());
        bool clientEquality = (this.GetClientId() == newClient.GetClientId());
        return (idEquality && nameEquality && clientEquality);
      }
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

    public int GetClientId()
    {
      return _clientId;
    }
//----SETTERS
    public void SetName(string newName)
    {
      _name = newName;
    }

    public void SetClientId(int newClientId)
    {
      _clientId = newClientId;
    }
//----CALSS METHODS
//GetAll
    public static List<Client> GetAll()
    {
      Console.WriteLine("GetAll");
      List<Client> allClients = new List<Client>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM clients;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while (rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);

        Client newClient = new Client( clientName, clientId);
        allClients.Add(newClient);
      }

      if (rdr != null)
        {
          rdr.Close();
        }
        if (conn != null)
        {
          conn.Close();
        }

        return allClients;
    }

//Save

//Find

//DeleteAll
    public static void DeleteAll()
      {
        Console.WriteLine("DeleteAll");
        SqlConnection conn = DB.Connection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM clients;", conn);

        cmd.ExecuteNonQuery();
        conn.Close();
      }




// End -----------------------------------------------
  }
}
