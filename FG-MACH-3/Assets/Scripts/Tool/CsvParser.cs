﻿using System;
using System.Collections.Generic;
using System.IO;
//using Microsoft.VisualBasic.FileIO;
using Models;
using Profile;

namespace Tool
{
    internal static class CsvParser
    {
        private const string RecordsTablePath = "Assets/Resources/RecordsTable/RecordsTable.csv";
        private const string NewStringPointPath = "Assets/Resources/RecordsTable/NewStringPoint.csv";

        public static List<StringPoint> StartParser()
        {
            List<StringPoint> stringPoints = new List<StringPoint>();
            using (StreamReader sr = new StreamReader(RecordsTablePath))
            {
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                    string[] fields = s.Split(',');
                    stringPoints.Add(new StringPoint(int.Parse(fields[0]), fields[1], int.Parse(fields[2])));
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
            var newStringPoint =
                $"{stringPoints[0].Id},{stringPoints[0].Data},{stringPoints[0].Point + Environment.NewLine}";
            File.WriteAllText(RecordsTablePath, newStringPoint);
            for (int i = 1; i < count; i++)
            {
                newStringPoint =
                    $"{stringPoints[i].Id},{stringPoints[i].Data},{stringPoints[i].Point + Environment.NewLine}";
                File.AppendAllText(RecordsTablePath, newStringPoint);
            }
        }

        public static void SetRecord(StoragePoints storagePoints)
        {
            var newStringPoint = $"0,{DateTime.Now.ToShortDateString()},{storagePoints.Points}";
            File.WriteAllText(NewStringPointPath, newStringPoint);
        }

        public static void DeleteRecords()
        {
            File.Delete(NewStringPointPath);
        }

        public static StringPoint GetRecord()
        {
            StringPoint stringPoint = new StringPoint();
            try
            {
                using (StreamReader sr = new StreamReader(NewStringPointPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string s = sr.ReadLine();
                        string[] fields = s.Split(',');
                        stringPoint = new StringPoint(int.Parse(fields[0]), fields[1], int.Parse(fields[2]));
                    }
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
