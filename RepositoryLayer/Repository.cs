using BookStoreEntity;
using BookStoreInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepository
{
    public class Repository : IRepository
    {


        public int AddBook(BookEntity bookEntity)
        {
            int count = 0;
            string query = "select * from Books where Title='" + bookEntity.Title + "'";
            SqlConnection connection = new SqlConnection("data source=.;database=BookStore;integrated security=True");
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader sdr = command.ExecuteReader();
            while (sdr.Read())
            {
                count++;
            }
            sdr.Close();
            //connection.Close();
            if (count == 0)
            {
                SqlConnection connection1 = new SqlConnection("data source=.;database=BookStore;integrated security=True");

                SqlCommand cmd = new SqlCommand("AddBook", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", bookEntity.Title);
                cmd.Parameters.AddWithValue("@Author", bookEntity.Author);
                cmd.Parameters.AddWithValue("@Location", bookEntity.Location);
                cmd.Parameters.AddWithValue("@Category", bookEntity.Category);
                cmd.Parameters.AddWithValue("@Pages", bookEntity.Pages);
                cmd.Parameters.AddWithValue("@Tags", bookEntity.Tags);
                //connection1.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            return count;
        }
        public BookEntity ShowBooks(BookEntity bookEntity1)
        {
            List<BookEntity> list = new List<BookEntity>();
            SqlConnection connection = new SqlConnection("data source=.;database=BookStore;integrated security=True");
            SqlCommand command = new SqlCommand("select * from Books", connection);
            connection.Open();
            SqlDataReader sdr = command.ExecuteReader();
            while (sdr.Read())
            {
                BookEntity bookEntity = new BookEntity();
                bookEntity.Title = Convert.ToString(sdr["Title"]);
                bookEntity.Author = Convert.ToString(sdr["Author"]);
                bookEntity.Location = Convert.ToString(sdr["Location"]);
                bookEntity.Category = Convert.ToString(sdr["Category"]);
                bookEntity.Pages = Convert.ToInt32(sdr["Pages"]);
                bookEntity.Tags = Convert.ToString(sdr["Tags"]);
                list.Add(bookEntity);
            }
            connection.Close();
            bookEntity1.BookList = list;
            List<BookEntity> list1 = new List<BookEntity>();
            SqlCommand command1 = new SqlCommand("select * from FavBooks", connection);
            connection.Open();
            SqlDataReader sdr1 = command1.ExecuteReader();
            while (sdr1.Read())
            {
                BookEntity bookEntity = new BookEntity();
                bookEntity.Title = Convert.ToString(sdr1["Title"]);
                bookEntity.Author = Convert.ToString(sdr1["Author"]);
                list1.Add(bookEntity);
            }
            bookEntity1.List = list1;
            connection.Close();
            return bookEntity1;
        }
        public void AddFav(string title, string author)
        {
            SqlConnection connection = new SqlConnection("data source=.;database=BookStore;integrated security=True");

            SqlCommand cmd = new SqlCommand("AddFavBook", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Author", author);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            SqlCommand cmd1 = new SqlCommand("UpdateBooks", connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@Title", title);
            connection.Open();
            cmd1.ExecuteNonQuery();
            connection.Close();

        }
    }
}
