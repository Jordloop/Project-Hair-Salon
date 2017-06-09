using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  [Collection("HairSalon")]
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Hair_Stylist_test;Integrated Security=SSPI;";
    }

    

    public void Dispose()
    {
      Cuisine.DeleteAll();
    }

  }
}
