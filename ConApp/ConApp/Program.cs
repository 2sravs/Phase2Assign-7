using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp
{
    internal class Program
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataAdapter adapter;
        static DataSet ds;
        static string conStr = "server=SRAVS;database=LibraryDb;trusted_connection=true;";
        
        static void Main(string[] args)
        {
            try
            {


                con = new SqlConnection(conStr);
                cmd = new SqlCommand("select * from Books", con);

                //Retrive data from dataset
                RetriveBookData();

                //Display book inventory
                DisplayAllBook();

                //Add new Book
                AddNewBook();

                //Update Book
                UpdateBook();
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { Console.ReadKey(); }
        }
        public static void RetriveBookData()
        {
            adapter = new SqlDataAdapter(cmd);
            con.Open();
            ds = new DataSet();
            adapter.Fill(ds);
        }
        public static void DisplayAllBook()
        {
            Console.WriteLine("*******************************");
            Console.WriteLine("Books List");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Console.WriteLine("BookId: " + ds.Tables[0].Rows[i]["BId"]);
                Console.WriteLine("Title: " + ds.Tables[0].Rows[i]["BTitle"]);
                Console.WriteLine("Author: " + ds.Tables[0].Rows[i]["BAuthor"]);
                Console.WriteLine("Genre: " + ds.Tables[0].Rows[i]["BGenre"]);
                Console.WriteLine("Quantity: " + ds.Tables[0].Rows[i]["BQty"]);
            }
        }
        public static void AddNewBook()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Adding new Book to List");
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            con.Close();
            Console.WriteLine("Enter Book Id: ");
            dr["BId"] = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Book Title: ");
            dr["BTitle"] = Console.ReadLine();
            Console.WriteLine("Enter Book Author: ");
            dr["BAuthor"] = Console.ReadLine();
            Console.WriteLine("Enter Book Genre: ");
            dr["BGenre"] = Console.ReadLine();
            Console.WriteLine("Enter Book Quantity: ");
            dr["BQty"] = int.Parse(Console.ReadLine());
            dt.Rows.Add(dr);
            ApplyChanges();
            Console.WriteLine("Book Added!!");


        }
        public static void UpdateBook()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("Updating a Book from List");
            DataTable dt = ds.Tables[0];
            con.Close();
            Console.WriteLine("Enter Id to Update Book: ");
            int id = int.Parse(Console.ReadLine());
            DataRow dr = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((int)dt.Rows[i]["BId"] == id)
                {
                    dr = dt.Rows[i];
                    break;
                }
            }
            if (dr != null)
            {
                Console.WriteLine("Enter Title: ");
                dr["BTitle"] = Console.ReadLine();
                Console.WriteLine("Enter Book Author: ");
                dr["BAuthor"] = Console.ReadLine();
                Console.WriteLine("Enter Book Genre: ");
                dr["BGenre"] = Console.ReadLine();
                Console.WriteLine("Enter Book Quantity: ");
                dr["BQty"] = int.Parse(Console.ReadLine());
                ApplyChanges();
                Console.WriteLine("Record Updated!! ");
            }
            else
            {
                Console.WriteLine("No such record exist");
            }

        }
        public static void ApplyChanges()
        {
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Update(ds);
            Console.ReadKey();
        }
       
    } 
}
        
    

