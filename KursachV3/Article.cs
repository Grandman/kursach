using System;
using System.Collections.Generic;
using System.Data;
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
                    row[5] = "Доход";
                else
                    row[5] = "Расход";
                if (Convert.ToInt16(row[4]) == 0)
                    row[6] = "Плановый";
                else
                    row[6] = "Текущий";
            }
            return table;
        }

        /// <summary>
        /// Получение таблицы статей за определенное количество месяцев
        /// </summary>
        /// <param name="filterType">Тип фильтрации(доход,расход,все)</param>
        /// <param name="month">Количество месяцев</param>
        /// <returns>Таблица со статьями</returns>
        public static DataTable GetArticles(int filterType, int month=0)
        {
            DateTime date = DateTime.Now.AddMonths(-month);
            return month == 0 ? ConvertArticleTable(Db.Select("*", "articles", "date", "asc",FilterConvert(filterType)))
                : ConvertArticleTable(Db.Select("*", "articles", "date", "asc", "(date>='" + date.ToString("MM/dd/yyyy") + "') AND (date<='" + DateTime.Now.ToString("MM/dd/yyyy") + "') AND (" +FilterConvert(filterType) + ")"));
        }

        public static DataTable GetArticles(DateTime from, DateTime to,int filterType)
        {
            return ConvertArticleTable(Db.Select("*", "articles", "date", "asc", "(date>='" + from.ToString("MM/dd/yyyy") + "') AND (date<='" + to.ToString("MM/dd/yyyy") + "') AND (" +FilterConvert(filterType) + ")"));
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
