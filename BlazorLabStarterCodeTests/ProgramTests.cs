using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blazor_Lab_Starter_Code;
using System;
using System.Collections.Generic;
using System.IO;

// This is a test change to trigger the CI workflow. 2

namespace BlazorLabStarterCodeTests
{
    [TestClass]
    public class ProgramTests
    {
        [TestInitialize]
        public void TestSetup()
        {
            Blazor_Lab_Starter_Code.Program.books = new List<Book>();
            Blazor_Lab_Starter_Code.Program.users = new List<User>();
            Blazor_Lab_Starter_Code.Program.borrowedBooks = new Dictionary<User, List<Book>>();
        }

        [TestMethod]
        public void AddUser_ValidInput_UserAdded()
        {
            var input = new StringReader("User1\nuser1@example.com\n");
            Console.SetIn(input);
            Blazor_Lab_Starter_Code.Program.AddUser();

            Assert.AreEqual(1, Blazor_Lab_Starter_Code.Program.users.Count);
            Assert.AreEqual("User1", Blazor_Lab_Starter_Code.Program.users[0].Name);
        }



        [TestMethod]
        public void BorrowBook_ValidBorrow_Success()
        {
            Blazor_Lab_Starter_Code.Program.books.Add(new Book { Id = 1, Title = "Sample Book", Author = "Author A" });
            Blazor_Lab_Starter_Code.Program.users.Add(new User { Id = 1, Name = "User A" });

            var input = new StringReader("1\n1");
            Console.SetIn(input);

            Blazor_Lab_Starter_Code.Program.BorrowBook();

            Assert.AreEqual(0, Blazor_Lab_Starter_Code.Program.books.Count);
            Assert.AreEqual(1, Blazor_Lab_Starter_Code.Program.borrowedBooks[Blazor_Lab_Starter_Code.Program.users[0]].Count);
        }
    }
}
