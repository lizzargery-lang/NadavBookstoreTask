using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace targil
{
    public interface IBookExporter
    {
        void Export(IEnumerable<Book> books);
    }

    // מימוש עבור CSV
    public class CsvExporter : IBookExporter
    {
        public void Export(IEnumerable<Book> books)
        {
            var csvPath = Path.Combine(Environment.CurrentDirectory, "processed_books.csv");
            var lines = new List<string> { "ID,Title,Author,Price,PublishDate" };

            lines.AddRange(books.Select(b =>
                $"{b.Id},{b.Title.Replace(",", "")},{b.Author.Replace(",", "")},{b.Price},{b.PublishDate:yyyy-MM-dd}"));

            File.WriteAllLines(csvPath, lines);
            Console.WriteLine($"[CSV] הקובץ נשמר בכתובת: {csvPath}");
        }
    }

    // מימוש עבור Elastic (כרגע כתיבה לקונסול כהכנה)
    public class ElasticExporter : IBookExporter
    {
        public void Export(IEnumerable<Book> books)
        {
            Console.WriteLine($"[Elastic] מדמה שליחה של {books.Count()} ספרים למאגר...");
            // כאן יבוא בעתיד הקוד של HttpClient
        }
    }
}