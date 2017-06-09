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
      Console.WriteLine("Test: Database Empty");
      // ARRANGE/ACT

      int result = Stylist.GetAll().Count;

      // ASSERT
      Assert.Equal(0, result);
    }


//NAMES ARE THE SAME
    [Fact]
    public void Test_NamesAreTheSame_True()
    {
      Console.WriteLine("Test: Names Are the Same");

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
      Console.WriteLine("Test: Saves To Database");
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
      Console.WriteLine("Test: Assign Id");
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
      Console.WriteLine("Test: Object Found In db");
      //Arrange
      Stylist testStylist = new Stylist("Jordan Loop");
      testStylist.Save();

      //Act
      Stylist foundStylist = Stylist.Find(testStylist.GetId());

      //Assert
      Assert.Equal(testStylist, foundStylist);
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
