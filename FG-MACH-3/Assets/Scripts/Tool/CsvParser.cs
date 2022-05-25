using System;
using System.Collections.Generic;
using System.IO;
using Models;
using Profile;
using UnityEngine;

namespace Tool
{
    internal static class CsvParser
    {
        private static readonly ResourcePath RecordsTablePath = new ResourcePath("RecordsTable/RecordsTable");
        private const string RecordsTable = "RecordsTable.csv";
        private const string NewStringPoint = "NewStringPoint.csv";

        public static void StartParser()
        {
            if (File.Exists(Application.persistentDataPath + "//" + RecordsTable))
            {
                return;
            }
            List<StringPoint> stringPoints = new List<StringPoint>();
            var text = ResourcesLoader.LoadTextAsset(RecordsTablePath).text;

            string[] fields = text.Split('\n', '\r');
            foreach (var field in fields)
            {
                string[] f = field.Split(',');
                if (f.Length > 2)
                {
                    stringPoints.Add(new StringPoint(int.Parse(f[0]), f[1], int.Parse(f[2])));
                }
            }

            using var filestreem = new StreamWriter(Application.persistentDataPath + "//" + RecordsTable);
            foreach (var stringPoint in stringPoints)
            {
                var newStringPoint = $"{stringPoint.Id},{stringPoint.Data},{stringPoint.Point}";
                filestreem.WriteLine(newStringPoint);
            }
        }

        public static List<StringPoint> GetTableRecord()
        {
            List<StringPoint> stringPoints = new List<StringPoint>();
            using var filestreem = new StreamReader(Application.persistentDataPath + "//" + RecordsTable);
            while (!filestreem.EndOfStream)
            {
                var text = filestreem.ReadLine();
                string[] f = text.Split(',');
                if (f.Length > 2)
                {
                    stringPoints.Add(new StringPoint(int.Parse(f[0]), f[1], int.Parse(f[2])));
                }

            }
            return stringPoints;
        }

        public static void SetTableRecord(List<StringPoint> stringPoints)
        {
            if (stringPoints.Count > 10)
            {
                SetTableRecord(stringPoints, 10);
            }
            else
            {
                SetTableRecord(stringPoints, stringPoints.Count);
            }
        }

        private static void SetTableRecord(List<StringPoint> stringPoints, int count)
        {
            using var filestreem = new StreamWriter(Application.persistentDataPath + "//" + RecordsTable);
            for (int i = 0; i < count; i++)
            {
                var newStringPoint = $"{stringPoints[i].Id},{stringPoints[i].Data},{stringPoints[i].Point}";
                filestreem.WriteLine(newStringPoint);
            }
        }

        public static void SetRecord(StoragePoints storagePoints)
        {
            var newStringPoint = $"0,{DateTime.Now.ToShortDateString()},{storagePoints.Points}";
            using var filestreem = new StreamWriter(Application.persistentDataPath + "//" + NewStringPoint);
            filestreem.Write(newStringPoint);
        }

        public static void DeleteRecords()
        {
            File.Delete(Application.persistentDataPath + "//" + NewStringPoint);
        }

        public static StringPoint GetRecord()
        {
            StringPoint stringPoint = new StringPoint();
            try
            {
                using var filestreem = new StreamReader(Application.persistentDataPath + "//" + NewStringPoint);
                var text = filestreem.ReadLine();
                string[] fields = text.Split('\n', '\r');
                foreach (var field in fields)
                {
                    string[] f = field.Split(',');
                    stringPoint = new StringPoint(int.Parse(f[0]), f[1], int.Parse(f[2]));
                }
            }
            catch (Exception)
            {
                return null;
            }

            return stringPoint;
        }
    }

}
