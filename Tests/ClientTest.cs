using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  [Collection("HairSalon")]
  public class ClientTest
  // : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

//DATABASE EMPTY
[Fact]
    public void Test_DatabaseEmpty_True()
    {
      Console.WriteLine("Client Test: db empty");
      //Arrange, Act
      int result = Client.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }
//NAMES ARE THE SAME
    [Fact]
    public void Test_NamesAreTheSame_True()
    {
      Console.WriteLine("Client Test: Names Are the Same");

      // ARRANGE/ACT
      Client firstClient = new Client("Jordan", 1);
      Client secondClient = new Client("Jordan", 1);

      // ASSERT
      Assert.Equal(firstClient, secondClient);
    }
//SAVE TO DATABASE

//ASSIGN ID TO OBJECT

//OBJECT FOUND IN DATABASE

//DISPOSE
    public void Dispose()
    {
      Console.WriteLine("Dispose");

      Client.DeleteAll();
    }


    //END--------------------
  }
}
