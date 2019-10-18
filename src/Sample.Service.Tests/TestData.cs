using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;

namespace Sample.Service.Test
{
    public class TestData
    {
        public static IEnumerable<T> GetDataFromCsv<T>(string filename)
        {
            // arrange
            using (var sr = new StreamReader($"TestData\\{filename}"))
            using (var reader = new CsvReader(sr))
            {
                var records = reader.GetRecords<T>();
                var aa = records.ToList();
                return records;
            }
        }
    }
}