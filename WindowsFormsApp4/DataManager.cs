using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace WindowsFormsApp4
{
    class DataManager ///
    {
        public static List<Book> Books = new List<Book>();
        public static List<User> Users = new List<User>();
        public static List<Manager> Managers = new List<Manager>();

        static DataManager()
        {
            Load();
            Login();
        }
        public static void Load()
        {
            try
            {
                string booksOutput = File.ReadAllText(@"../../data/Books.xml"); 
                XElement booksXElement = XElement.Parse(booksOutput);
                Books = (from item in booksXElement.Descendants("book")
                         select new Book()
                         {
                             Isbn = item.Element("isbn").Value,
                             Name = item.Element("name").Value,
                             Publisher = item.Element("publisher").Value,
                             Page = int.Parse(item.Element("page").Value),
                             BorrowedAt = DateTime.Parse(item.Element("borrowedAt").Value),
                             isBorrowed = item.Element("isBorrowed").Value !="0" ? true:false,
                             UserId = int.Parse(item.Element("userId").Value),
                             UserName = item.Element("userName").Value
                         }).ToList<Book>();
                string usersOutput = File.ReadAllText(@"../../data/Users.xml"); 
                XElement usersXElement = XElement.Parse(usersOutput);
                Users = (from item in usersXElement.Descendants("user")
                         select new User()
                         {
                             Id = int.Parse(item.Element("id").Value),
                             Name = item.Element("name").Value
                         }).ToList<User>();
            }
            catch (FileNotFoundException exception)
            {
                Save();
            }
        }
        public static void Save()
        {
            string booksOutput = "";
            booksOutput += "<books>\n";
            foreach (var item in Books)
            {
                booksOutput += "<book>\n";
                booksOutput += " <isbn>"+item.Isbn+"</isbn>\n";
                booksOutput += " <name>" + item.Name + "</name>\n";
                booksOutput += " <publisher>" + item.Publisher + "</publisher>\n";
                booksOutput += " <page>" + item.Page + "</page>\n";
                booksOutput += " <borrowedAt>" + item.BorrowedAt.ToLongDateString() + "</borrowedAt>\n";
                booksOutput += " <isBorrowed>" + (item.isBorrowed?1:0) + "</isBorrowed>\n";
                booksOutput += " <userId>" + item.UserId + "</userId>\n";
                booksOutput += " <userName>" + item.UserName + "</userName>\n";
                booksOutput += "</book>\n";
            }
            booksOutput += "</books>";

            string usersOutput = "";
            usersOutput += "<users>\n";
            foreach (var item in Users)
            {
                usersOutput += "<user>\n";
                usersOutput += " <id>" + item.Id + "</id>\n";
                usersOutput += " <name>" + item.Name + "</name>\n";
                usersOutput += "</user>\n";
            }
            usersOutput += "</users>";

            string managersOutput = "";
            managersOutput += "<managers>\n";
            foreach (var item in Managers)
            {
                managersOutput += "<manager>\n";
                managersOutput += " <id>" + item.Id + "</id>\n";
                managersOutput += " <password>" + item.Password + "</password>\n";
                managersOutput += "</manager>\n";
            }
            managersOutput += "</managers>";

            File.WriteAllText(@"../../data/Books.xml", booksOutput);
            File.WriteAllText(@"../../data/Users.xml", usersOutput);
            File.WriteAllText(@"../../data/Managers.xml", managersOutput);
        }

        public static void Login()
        {
            try
            {
                string managersOutput = File.ReadAllText(@"../../data/Managers.xml"); 
                XElement managersXElement = XElement.Parse(managersOutput);
                Managers = (from item in managersXElement.Descendants("manager")
                         select new Manager()
                         {
                             Id = item.Element("id").Value,
                             Password = item.Element("password").Value
                         }).ToList<Manager>();
            }
            catch (FileNotFoundException exception)
            {

            }
        }

        public static void ManagerSignUp()
        {
            string signUp = "";
            signUp += "<users>\n";
            foreach (var item in Users)
            {
                signUp += "<users>\n";
                signUp += " <id>" + item.Id + "</id>\n";
                signUp += " <name>" + item.Name + "</name>\n";
                signUp += "</users>\n";
            }
            signUp += "</users>";

            File.WriteAllText(@"../../data/Managers.xml", signUp);
        }
    }
}
