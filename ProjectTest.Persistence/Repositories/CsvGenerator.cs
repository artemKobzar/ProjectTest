using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ProjectTest.Application.DTOs.UserDto.Attributes;

namespace ProjectTest.Persistence.Repositories
{
    public class CsvGenerator<T> where T : class
    {
        private IEnumerable<T> _data;
        private Type _type;
        private string _fileName;

        public CsvGenerator(IEnumerable<T> data, string fileName)
        {
            _data = data;
            _type = typeof(T);
            _fileName = fileName;
        }
        public void Generate()
        {
            var rows = new List<string>();

            rows.Add(CreateHeader());
            foreach (var item in  _data) 
            {
                rows.Add(CreateRow(item));
            }
            File.WriteAllLines($"{_fileName}.csv", rows, Encoding.UTF8 );
        }
        private string CreateHeader()
        {
            var properties = _type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var headers = new StringBuilder();
            foreach (var property in properties)
            {
                var attr = property.GetCustomAttribute<CsvGeneratorAttribute>();
                headers.Append(attr.Heading ?? property.Name).Append(",");
            }
            return headers.ToString()[..^1];
        }
        private string CreateRow(T item) 
        {
            var properties = _type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var rows = new StringBuilder();
            foreach (var property in properties) 
            {
                rows.Append(property.GetValue(item)).Append(",");
            }
            return rows.ToString()[..^1];
        }
    }
}
