using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursachV3
{
    static class Article
    {
        public static bool AddArticle(int size, DateTime date, int type, int kind)
        {
            Dictionary<string,object> vars = ArticleValues(size, date, type, kind);
            return Db.Insert("articles", vars);
        }

        private static Dictionary<string,object> ArticleValues (int size, DateTime date, int type,int kind)
        {
            return new Dictionary<string, object> { { "size", size }, { "date", date }, { "type", type }, { "kind", kind } };
        }
        public static bool UpdateArticle(int size, DateTime date, int type, int kind,int id)
        {
            Dictionary<string, object> vars = ArticleValues(size, date, type, kind);
            return Db.Update("articles", vars, id);
        }
        public static bool DeleteArticle(int id)
        {
            return Db.Delete("articles", id);
        }
        /// <summary>
        /// Получение таблицы статей за определенное количество месяцев
        /// </summary>
        /// <param name="month">Количество месяцев</param>
        /// <returns>Таблица со статьями</returns>
        public static DataTable GetArticles(int month = 0)
        {
            DateTime date = DateTime.Now.AddMonths(-month);
            return month==0 ? Db.Select("*", "articles", "date", "asc") : Db.Select("*", "articles", "date", "asc", "(date>=" + date.ToString("d") + ") AND (date<="+DateTime.Now.ToString("d") + ")");
        }
    }
}
