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
    [Fact]
    public void Test_SavesToDatabase_True()
    {
      Console.WriteLine("Stylist Test: Saves To Database");
      //ARRANGE
      Stylist testStylist = new Stylist("Jordan Loop");
      //ACT
      testStylist.Save();
      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};
      //ASSERT
      Assert.Equal(testList, result);
    }

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
