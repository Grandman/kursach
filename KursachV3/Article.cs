using System;
using System.Collections.Generic;
using System.Data;
using NetOffice.DAOApi;
using DataTable = System.Data.DataTable;

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

        /// <summary>
        /// Получение таблицы статей за определенное количество месяцев
        /// </summary>
        /// <param name="filterType">Тип фильтрации(доход,расход,все)</param>
        /// <param name="month">Количество месяцев</param>
        /// <param name="groupby">Если есть группировка</param>
        /// <returns>Таблица со статьями</returns>
        public static DataTable GetArticles(int filterType, int month=0,string groupby="")
        {
            DateTime date = DateTime.Now.AddMonths(-month);
            return GetArticles(date, DateTime.Now, filterType, groupby);
        }

        public static DataTable GetArticles(DateTime from, DateTime to,int filterType,string groupBy)
        {
            if (groupBy == "")
                return
                    Db.Select("id,name,date, case when type = 1 then 'profit' when type = 0 then 'consuption' end", "articles", "date", "asc",
                        "(date>='" + @from.ToString("MM/dd/yyyy") + "') AND (date<='" + to.ToString("MM/dd/yyyy") +
                        "') AND (" + FilterConvert(filterType) + ")");
            if (groupBy == "date")
            {
                return Db.Select("DISTINCT a.date as Дата,p.Доход,c.Расход,-ISNULL(c.Расход,0)+ISNULL(p.Доход,0) as Итого", "articles as a FULL OUTER JOIN (SELECT date,sum(size) as Доход FROM articles WHERE type = 0 AND (date>='" +
                                                                                                        @from.ToString("MM/dd/yyyy") + "') AND (date<='" + to.ToString("MM/dd/yyyy") +
                                                                                                        "') GROUP BY date) as p on a.date = p.date RIGHT OUTER JOIN (SELECT date,sum(size) as Расход FROM articles WHERE type = 1 and (date>='" +
                                                                                                        @from.ToString("MM/dd/yyyy") + "') AND (date<='" + to.ToString("MM/dd/yyyy") +
                                                                                                        "') GROUP BY date) as c on a.date = c.date");
            }
            if (groupBy == "name")
            {
                return Db.Select("DISTINCT a.name as Название,p.Доход,c.Расход,-ISNULL(c.Расход,0)+ISNULL(p.Доход,0) as Итого", "articles as a FULL OUTER JOIN (SELECT name,sum(size) as Доход FROM articles WHERE type = 0 AND (date>='" +
                                                                                                       @from.ToString("MM/dd/yyyy") + "') AND (date<='" + to.ToString("MM/dd/yyyy") +
                                                                                                       "') GROUP BY name) as p on a.name = p.name RIGHT OUTER JOIN (SELECT name,sum(size) as Расход FROM articles WHERE type = 1 and (date>='" +
                                                                                                       @from.ToString("MM/dd/yyyy") + "') AND (date<='" + to.ToString("MM/dd/yyyy") +
                                                                                                       "') GROUP BY name) as c on a.name = c.name");
            }
            return null;
        }


        private static string FilterConvert(int filterType)
        {
            switch (filterType)
            {
                case 1:
                    return "type=0";
                case 2:
                    return "type=1";
                default:
                    return "type=0 OR type=1";
            }
            
        }
    }
}
