using System;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace UserManagement.Services;

public class CSVService : ICSVService
{
    public IEnumerable<T> ReadCSV<T>(Stream stream)
    {
        IEnumerable<T> records;
        var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";",
        };

        using var reader = new StreamReader(stream);
        using var csv = new CsvReader(reader, configuration);
        records = csv.GetRecords<T>().ToList();
        return records;
    }
}

