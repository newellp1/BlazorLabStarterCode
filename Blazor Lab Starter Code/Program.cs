namespace Blazor_Lab_Starter_Code
{
    class Program
    {
        internal static List<Book> books = new List<Book>();
        internal static List<User> users = new List<User>();
        internal static Dictionary<User, List<Book>> borrowedBooks = new Dictionary<User, List<Book>>();

        internal static void Main()
        {
            ReadBooks();
            ReadUsers();

            string? option;

            do
            {
                Console.WriteLine("Library Management System");
                Console.WriteLine("1. Manage Books");
                Console.WriteLine("2. Manage Users");
                Console.WriteLine("3. Borrow Book");
                Console.WriteLine("4. Return Book");
                Console.WriteLine("5. List Borrowed Books");
                Console.WriteLine("6. Exit");

                Console.Write("Choose an option: ");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ManageBooks();
                        break;
                    case "2":
                        ManageUsers();
                        break;
                    case "3":
                        BorrowBook();
                        break;
                    case "4":
                        ReturnBook();
                        break;
                    case "5":
                        ListBorrowedBooks();
                        break;
                }
            } while (option != "6");
        }

        internal static void AddUser()
        {
            Console.Write("\nEnter User Name: ");
            string? name = Console.ReadLine();

            Console.Write("Enter Email: ");
            string? email = Console.ReadLine();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
            {
                Console.WriteLine("Invalid input! Name and Email are required.");
                return;
            }

            int id = users.Any() ? users.Max(u => u.Id) + 1 : 1;
            users.Add(new User { Id = id, Name = name, Email = email });
            Console.WriteLine("User added successfully!\n");
        }

        internal static void EditUser()
        {
            ListUsers();
            Console.Write("\nEnter User ID to Edit: ");

            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || !int.TryParse(input, out int userId))
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            User? user = users.FirstOrDefault(u => u.Id == userId);

            if (user != null)
            {
                Console.Write("Enter new Name (leave blank to keep current): ");
                string? name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)) user.Name = name;

                Console.Write("Enter new Email (leave blank to keep current): ");
                string? email = Console.ReadLine();
                if (!string.IsNullOrEmpty(email)) user.Email = email;

                Console.WriteLine("User updated successfully!\n");
            }
            else
            {
                Console.WriteLine("User not found!\n");
            }
        }

        internal static void DeleteUser()
        {
            ListUsers();
            Console.Write("\nEnter User ID to Delete: ");

            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || !int.TryParse(input, out int userId))
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            User? user = users.FirstOrDefault(u => u.Id == userId);

            if (user != null)
            {
                users.Remove(user);
                Console.WriteLine("User deleted successfully!\n");
            }
            else
            {
                Console.WriteLine("User not found!\n");
            }
        }

        internal static void ReadBooks(string filePath = "./Data/Books.csv")
        {
            try
            {
                foreach (var line in File.ReadLines(filePath))
                {
                    var fields = line.Split(',');

                    if (fields.Length >= 4)
                    {
                        var book = new Book
                        {
                            Id = int.Parse(fields[0].Trim()),
                            Title = fields[1].Trim(),
                            Author = fields[2].Trim(),
                            ISBN = fields[3].Trim()
                        };

                        books.Add(book);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        internal static void ManageUsers()
        {
            string? option;

            do
            {
                Console.WriteLine("\nManage Users");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Edit User");
                Console.WriteLine("3. Delete User");
                Console.WriteLine("4. List Users");
                Console.WriteLine("5. Back");

                Console.Write("Choose an option: ");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddUser();
                        break;
                    case "2":
                        EditUser();
                        break;
                    case "3":
                        DeleteUser();
                        break;
                    case "4":
                        ListUsers();
                        break;
                }
            } while (option != "5");
        }
        internal static void ReadUsers()
        {
            try
            {
                foreach (var line in File.ReadLines("./Data/Users.csv"))
                {
                    var fields = line.Split(',');

                    if (fields.Length >= 3)
                    {
                        var user = new User
                        {
                            Id = int.Parse(fields[0].Trim()),
                            Name = fields[1].Trim(),
                            Email = fields[2].Trim()
                        };

                        users.Add(user);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        internal static void AddBook()
        {
            Console.Write("\nEnter Book Title: ");
            string? title = Console.ReadLine();

            Console.Write("Enter Author: ");
            string? author = Console.ReadLine();

            Console.Write("Enter ISBN: ");
            string? isbn = Console.ReadLine();

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author) || string.IsNullOrEmpty(isbn))
            {
                Console.WriteLine("Invalid input! All fields are required.");
                return;
            }

            int id = books.Any() ? books.Max(b => b.Id) + 1 : 1;
            books.Add(new Book { Id = id, Title = title, Author = author, ISBN = isbn });
            Console.WriteLine("Book added successfully!\n");
        }

        internal static void EditBook()
        {
            ListBooks();
            Console.Write("\nEnter Book ID to Edit: ");

            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || !int.TryParse(input, out int bookId))
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            Book? book = books.FirstOrDefault(b => b.Id == bookId);

            if (book != null)
            {
                Console.Write("Enter new Title (leave blank to keep current): ");
                string? title = Console.ReadLine();
                if (!string.IsNullOrEmpty(title)) book.Title = title;

                Console.Write("Enter new Author (leave blank to keep current): ");
                string? author = Console.ReadLine();
                if (!string.IsNullOrEmpty(author)) book.Author = author;

                Console.Write("Enter new ISBN (leave blank to keep current): ");
                string? isbn = Console.ReadLine();
                if (!string.IsNullOrEmpty(isbn)) book.ISBN = isbn;

                Console.WriteLine("Book updated successfully!\n");
            }
            else
            {
                Console.WriteLine("Book not found!\n");
            }
        }
        internal static void ManageBooks()
        {
            string? option;

            do
            {
                Console.WriteLine("\nManage Books");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Edit Book");
                Console.WriteLine("3. Delete Book");
                Console.WriteLine("4. List Books");
                Console.WriteLine("5. Back");

                Console.Write("Choose an option: ");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        EditBook();
                        break;
                    case "3":
                        DeleteBook();
                        break;
                    case "4":
                        ListBooks();
                        break;
                }
            } while (option != "5");
        }

        internal static void DeleteBook()
        {
            ListBooks();
            Console.Write("\nEnter Book ID to Delete: ");

            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || !int.TryParse(input, out int bookId))
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            Book? book = books.FirstOrDefault(b => b.Id == bookId);

            if (book != null)
            {
                books.Remove(book);
                Console.WriteLine("Book deleted successfully!\n");
            }
            else
            {
                Console.WriteLine("Book not found!\n");
            }
        }
        internal static void BorrowBook()
        {
            ListBooks();
            Console.Write("\nEnter Book ID to Borrow: ");

            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || !int.TryParse(input, out int bookId))
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            Book? book = books.FirstOrDefault(b => b.Id == bookId);
            if (book == null)
            {
                Console.WriteLine("Book not found or no available copies!");
                return;
            }

            ListUsers();
            Console.Write("\nEnter User ID who is borrowing the book: ");

            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || !int.TryParse(input, out int userId))
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            User? user = users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                Console.WriteLine("User not found!");
                return;
            }

            if (!borrowedBooks.ContainsKey(user))
            {
                borrowedBooks[user] = new List<Book>();
            }

            borrowedBooks[user].Add(book);
            books.Remove(book);
            Console.WriteLine("Book borrowed successfully!\n");
        }


        internal static void ReturnBook()
        {
            ListBorrowedBooks();
            Console.Write("\nEnter User ID to return a book for: ");

            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || !int.TryParse(input, out int userId))
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            User? user = users.FirstOrDefault(u => u.Id == userId);
            if (user == null || !borrowedBooks.ContainsKey(user) || borrowedBooks[user].Count == 0)
            {
                Console.WriteLine("User not found or no borrowed books!");
                return;
            }

            Console.WriteLine("Borrowed Books:");
            for (int i = 0; i < borrowedBooks[user].Count; i++)
            {
                Console.WriteLine($"{i + 1}. {borrowedBooks[user][i].Title} by {borrowedBooks[user][i].Author} (ISBN: {borrowedBooks[user][i].ISBN})");
            }

            Console.Write("\nEnter the number of the book to return: ");
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || !int.TryParse(input, out int bookNumber) || bookNumber < 1 || bookNumber > borrowedBooks[user].Count)
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            Book bookToReturn = borrowedBooks[user][bookNumber - 1];
            borrowedBooks[user].RemoveAt(bookNumber - 1);
            books.Add(bookToReturn);

            Console.WriteLine("Book returned successfully!\n");
        }

        internal static void ListBooks()
        {
            Console.WriteLine("\nAvailable Books:");
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Id}. {book.Title} by {book.Author} (ISBN: {book.ISBN})");
            }
        }

        internal static void ListUsers()
        {
            Console.WriteLine("\nUsers:");
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id}. {user.Name} (Email: {user.Email})");
            }
        }

        internal static void ListBorrowedBooks()
        {
            Console.WriteLine("\nBorrowed Books:");
            foreach (var entry in borrowedBooks)
            {
                Console.WriteLine($"User: {entry.Key.Name}");
                foreach (var book in entry.Value)
                {
                    Console.WriteLine($"{book.Title} by {book.Author} (ISBN: {book.ISBN})");
                }
            }
        }
    }
}