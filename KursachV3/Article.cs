using System;
using System.Collections.Generic;
using System.Data;
using DataTable = System.Data.DataTable;

namespace KursachV3
{
    static class Article
    {
        public static bool AddArticle(string name,int type,int limit)
        {
            Dictionary<string,object> vars = ArticleValues(name,type,limit);
            return Db.Insert("articles", vars);
        }

        public static bool AddAccounting(int articleId, DateTime date, int size)
        {
            Dictionary<string, object> vars = AccountingValues(articleId, date, size);
            return Db.Insert("accounting", vars);
        }

        public static bool CheckNameArticle(string name)
        {
            DataTable table = Db.Select("name", "articles", "", "", "name = N'" + name + "'");
            return table != null && table.Rows.Count != 0 && table.Rows[0][0] != null &&
                   String.Equals(table.Rows[0][0].ToString(), name, StringComparison.CurrentCultureIgnoreCase);
        }
        private static Dictionary<string, object> AccountingValues(int articleId, DateTime date, int size)
        {
            return new Dictionary<string, object> { { "article_id", articleId }, { "date", date }, { "size", size } };
        }
        private static Dictionary<string, object> ArticleValues(string name, int type, int limit)
        {
            return new Dictionary<string, object> { { "name", name }, { "type", type }, { "limit", limit } };
        }
        public static bool UpdateArticle(string name, int type, int limit, int id)
        {
            Dictionary<string, object> vars = ArticleValues(name, type, limit);
            return Db.Update("articles", vars, id);
        }
        public static bool DeleteArticle(int id)
        {
            return Db.Delete("articles", id);
        }

        private static DataTable ConvertArticleTable(DataTable table)
        {
            table.Columns.Add("Тип");
            table.Columns.Add("Вид");
            table.Columns[1].ColumnName = "Размер";
            table.Columns[2].ColumnName = "Дата";
            foreach (DataRow row in table.Rows)
            {
                if (Convert.ToInt32(row[3]) == 0)
                    row[6] = "Доход";
                else
                    row[6] = "Расход";
                if (Convert.ToInt16(row[4]) == 0)
                    row[7] = "Плановый";
                else
                    row[7] = "Текущий";
            }
            return table;
        }

        public static DataTable GetNamesArticles()
        {
            return Db.Select("id,name", "articles");
        }

        /// <summary>
        /// Получение таблицы статей за определенное количество месяцев
        /// </summary>
        /// <param name="filterType">Тип фильтрации(доход,расход,все)</param>
        /// <param name="month">Количество месяцев</param>
        /// <param name="groupby">Если есть группировка</param>
        /// <returns>Таблица со статьями</returns>
        public static DataTable GetAccounting(int filterType, int month=0,string groupby="")
        {
            DateTime date = DateTime.Now.AddMonths(-month);
            return GetAccounting(date, DateTime.Now, filterType, groupby);
        }

        public static DataTable GetAccounting(DateTime from, DateTime to,int filterType,string groupBy)
        {
            if (groupBy == "")
                return
                    Db.Select(
                        "sum(a.size) as Сумма,b.name as Название,case when b.type = 0 then N'Доход' when b.type = 1 then N'Расход' end as Тип",
                        "accounting as a  INNER JOIN (SELECT id,name,type FROM articles) as b on b.id=a.article_id WHERE a.date>='" +
                         @from.ToString("MM/dd/yyyy") + "' AND a.date<='" + to.ToString("MM/dd/yyyy") + "' AND (" + FilterConvert(filterType) + ") Group By b.name,b.type");
      
            return null;
        }


        private static string FilterConvert(int filterType)
        {
            switch (filterType)
            {
                case 1:
                    return "b.type=0";
                case 2:
                    return "b.type=1";
                default:
                    return "b.type=0 OR b.type=1";
            }
            
        }
    }
}
