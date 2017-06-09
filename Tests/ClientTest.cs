using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  [Collection("HairSalon")]
  public class ClientTest : IDisposable
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
      Console.WriteLine("Client Test: Saves To Database");
      //ARRANGE
      Client testClient = new Client("Jordan Loop", 1);
      //ACT
      testClient.Save();
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};
      //ASSERT
      Assert.Equal(testList, result);
    }

//ASSIGN ID TO OBJECT
    [Fact]
    public void Test_AssignsIdToObject_True()
    {
      Console.WriteLine("Client Test: Assign Id");
      //Arrange
      Client testClient = new Client("Jordan Loop", 1);

      //Act
      testClient.Save();
      Client savedClient = Client.GetAll()[0];

      int result = savedClient.GetId();
      int testId = testClient.GetId();

      //Assert
      Assert.Equal(testId, result);
    }

//OBJECT FOUND IN DATABASE
    [Fact]
    public void Test_ObjectFoundInDatabase_True()
    {
      Console.WriteLine("Client Test: Object Found In db");
      //Arrange
      Client testClient = new Client("Jordan Loop", 1);
      testClient.Save();

      //Act
      Client foundClient = Client.Find(testClient.GetId());

      //Assert
      Assert.Equal(testClient, foundClient);
    }

//DISPOSE
    public void Dispose()
    {
      Console.WriteLine("Dispose");

      Client.DeleteAll();
    }


    //END--------------------
  }
}
