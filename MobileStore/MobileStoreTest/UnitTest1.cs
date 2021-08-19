using System;
using Xunit;
using MobileStore;

namespace MobileStoreTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestLogin()
        {
            //Given - Arrange
            string sUsername="Admin",passowrd="Admin";
            bool expectedsearch = true;
           // AllFun status=new AllFun();
            //When - Act
            bool actualsearch = Home.Login(sUsername,passowrd);
            //Then - Assert
            Assert.Equal(expectedsearch,actualsearch);
        }

        [Fact]
        public void TestSearchCustomer()
        {
            //Given - Arrange
            string sUsername="kajal",location="mumbai";
            bool expectedsearch = true;
           // AllFun status=new AllFun();
            //When - Act
            bool actualsearch = AllFun.Search_Customer(sUsername,location);
            //Then - Assert
            Assert.Equal(expectedsearch,actualsearch);
        }

        [Fact]
        public void TestAddProduct()
        {
            //Given - Arrange
            string c_name = "Oppo";
            string m_name = "";
            int i = 8;
            int j = 128;
            string color = "Blue";
            string store = "Pune";
            int k = 12000;
            bool expectedadd = false;
           // AllFun status=new AllFun();
            //When - Act
            bool actualadd =  AllFun.Add_Products(c_name,m_name,i,j,color,store,k);
            //Then - Assert
            Assert.Equal(expectedadd,actualadd);
        }

        [Fact]
        public void TestSearchProduct()
        {
            //Given - Arrange
            string c_name = "Oppo";
            bool expectedPS = true;
            bool actualPS =  Book_Order.Search_Product(c_name);
            //Then - Assert
            Assert.Equal(expectedPS,actualPS);
        }
             [Fact]
        public void TestEmptyCart()
        {
            //Given - Arrange
            int c = 0;
            string c_name = "Raj";
            bool expectedC = true;
           // AllFun status=new AllFun();
            //When - Act
            bool actualC =  Book_Order.DeleteCart(c_name);
            //Then - Assert
            Assert.Equal(expectedC,actualC);
        }
    }
}
