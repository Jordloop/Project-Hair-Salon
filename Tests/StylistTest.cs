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
    [Fact]
    public void Test_DatabaseEmptyAtFirst_True()
    {
      Console.WriteLine("Stylist Test: Database Empty");
      // ARRANGE/ACT

      int result = Stylist.GetAll().Count;

      // ASSERT
      Assert.Equal(0, result);
    }


//NAMES ARE THE SAME
    [Fact]
    public void Test_NamesAreTheSame_True()
    {
      Console.WriteLine("Stylist Test: Names Are the Same");

      // ARRANGE/ACT
      Stylist firstStylist = new Stylist("Jordan");
      Stylist secondStylist = new Stylist("Jordan");

      // ASSERT
      Assert.Equal(firstStylist, secondStylist);
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
    [Fact]
    public void Test_AssignsIdToObject_True()
    {
      Console.WriteLine("Stylist Test: Assign Id");
      //Arrange
      Stylist testStylist = new Stylist("Jordan Loop");

      //Act
      testStylist.Save();
      Stylist savedStylist = Stylist.GetAll()[0];

      int result = savedStylist.GetId();
      int testId = testStylist.GetId();

      //Assert
      Assert.Equal(testId, result);
    }

//OBJECT FOUND IN DATABASE
    [Fact]
    public void Test_ObjectFoundInDatabase_True()
    {
      Console.WriteLine("Stylist Test: Object Found In db");
      //Arrange
      Stylist testStylist = new Stylist("Jordan Loop");
      testStylist.Save();

      //Act
      Stylist foundStylist = Stylist.Find(testStylist.GetId());

      //Assert
      Assert.Equal(testStylist, foundStylist);
    }

//FIND ALL CLIENTS WITHIN STYLIST
    [Fact]
    public void Test_RetrievedAllClientsWithinStylist_True()
    {
      Stylist testStylist = new Stylist("Jordan Loop");
      testStylist.Save();

      Client firstClient = new Client("Donald Duck", testStylist.GetId());
      Client secondClient = new Client("Happy Tree", testStylist.GetId());

      firstClient.Save();
      secondClient.Save();

      List<Client> testClient = new List<Client>{firstClient, secondClient};
      List<Client> resultClientList = testStylist.GetClient();
    }

    [Fact]
    public void Test_UpdatesStylistInDatabase()
    {
      string name = "Jordan Loop";
      Stylist testStylist = new Stylist(name);
      testStylist.Save();
      string newName = "Nadroj Pool";

      testStylist.Update(newName);

      string result = testStylist.GetName();

      Assert.Equal(newName, result);
    }


    [Fact]
    public void Test_DeletesStylistFromDatabase_True()
    {
      //Arrange
      string stylistName1 = "Jordan Loop";
      Stylist testStylist1 = new Stylist(stylistName1);
      testStylist1.Save();

      string stylistName2 = "Donald Duck";
      Stylist testStylist2 = new Stylist(stylistName2);
      testStylist2.Save();

      Client testClient1 = new Client("Anne McCaffery", testStylist1.GetId());
      testClient1.Save();
      Client testClient2 = new Client("Neil Armstrong", testStylist2.GetId());
      testClient2.Save();

      //Act
      testStylist1.Delete();

      List<Stylist> resultStylistList = Stylist.GetAll();
      List<Stylist> testStylistList = new List<Stylist>{testStylist2};

      List<Client> resultClientList = Client.GetAll();
      List<Client> testClientList = new List<Client>{testClient2};
      //Assert
      Assert.Equal(testStylistList, resultStylistList);
      Assert.Equal(testClientList, resultClientList);
    }
//DISPOSE
    public void Dispose()
    {
      Console.WriteLine("Dispose");

      Stylist.DeleteAll();
    }


    //END--------------------
  }
}
