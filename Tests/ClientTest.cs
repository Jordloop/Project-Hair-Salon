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
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

//DATABASE EMPTY

//NAMES ARE THE SAME

//SAVE TO DATABASE

//ASSIGN ID TO OBJECT

//OBJECT FOUND IN DATABASE

//DISPOSE
    public void Dispose()
    {
      Console.WriteLine("Dispose");

      Stylist.DeleteAll();
    }


    //END--------------------
  }
}
