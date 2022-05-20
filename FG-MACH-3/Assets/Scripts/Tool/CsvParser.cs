using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using Models;

namespace Tool
{
    internal static class CsvParser
    {
        public static List<StringPoint> StartParser()
        {
            List<StringPoint> stringPoints = new List<StringPoint>();
            using (TextFieldParser tfp = new TextFieldParser("Assets/Resources/RecordsTable/RecordsTable.csv"))
            {
                tfp.TextFieldType = FieldType.Delimited;
                tfp.SetDelimiters(",");
                while (!tfp.EndOfData)
                {
                    string[] fields = tfp.ReadFields();
                    stringPoints.Add(new StringPoint(fields[0], fields[1], fields[2]));
                }
            }

            return stringPoints;
        }
    }
    
}
