using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Articles article = new Articles();

            ArticlesModel model = new ArticlesModel() { };
            model.Title = "title";
            model.Author = "name";
            model.Essay = "essay";
            model.Date = DateTime.Now;

            //add

            if (article.AddArticle(model))
            {
                //success
            }

            //get
            var list = article.GetArticles();
            foreach (ArticlesModel s in list)
            {
            }

            //get one
            ArticlesModel detail = article.GetArticleDetail(1);

            //get count
            int count = article.GetArticlesCount();
        }
    }
}
