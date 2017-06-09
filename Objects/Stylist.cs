using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Bestaurants
{
  [Collection("HairSalon")]
  public class CuisineTest : IDisposable
  {
    public CuisineTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Hair_Stylist_test;Integrated Security=SSPI;";
    }


    public void Dispose()
    {
      Cuisine.DeleteAll();
    }

  }
}
