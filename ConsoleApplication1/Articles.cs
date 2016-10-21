using System;
using System.Collections.Generic;
using System.Configuration;

using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace ConsoleApplication1
{
    public class Articles
    {
        public static readonly string ConnectionString = ConfigurationManager.AppSettings["MyConnection"];

        public bool AddArticle(ArticlesModel model)
        {
            bool result = false;
            string strInsert = @"INSERT INTO Articles(Title,Essay,Author,Date) VALUES(@Title,@Essay,@Author,@Date)";
            using (IDbConnection conn = OpenConnection())
            {
                if (conn.Execute(strInsert, model) > 0)
                    return true;
            }
            return result;
        }

        public IEnumerable<ArticlesModel> GetArticles()
        {
            using (IDbConnection connection = OpenConnection())
            {
                const string query = "SELECT * FROM Articles";
                return connection.Query<ArticlesModel>(query);
            }
        }

        public ArticlesModel GetArticleDetail(int id)
        {
            using (IDbConnection connection = OpenConnection())
            {
                const string query = "SELECT * FROM Articles WHERE Id = @Id";
                return connection.Query<ArticlesModel>(query, new { Id = id }).SingleOrDefault();
            }
        }

        public int GetArticlesCount()
        {
            using (IDbConnection connection = OpenConnection())
            {
                const string query = "SELECT * FROM Articles";
                return connection.Query<ArticlesModel>(query).Count();
            }
        }

        public SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }
    }

    public class ArticlesModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Essay { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
    }
}
