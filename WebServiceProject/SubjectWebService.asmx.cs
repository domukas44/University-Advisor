﻿using System;
using System.Collections.Generic;
using System.Web.Services;
using University_advisor.Entity;

namespace WebService
{
    /// <summary>
    /// Summary description for SubjectWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SubjectWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public List<Subject> ReadData()
        {
            var list = new List<Subject>();
            string[] lines = System.IO.File.ReadAllLines(@"C:\Resources\Data.txt");

            Subject.ResetIdNr();
            foreach (string line in lines)
            {
                string[] linesSplit = line.Split('\t');
                list.Add(new Subject(linesSplit[0], Convert.ToDouble(linesSplit[1]), Convert.ToInt32(linesSplit[2])));
            }
            return list;
        }

        [WebMethod]
        public double AddRating(int rating, string name)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Resources\Data.txt");
            int ratingsCount = 0;
            double totalRatings = 0;
            double newRating = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] linesSplit = lines[i].Split('\t');
                if (linesSplit[0] == name)
                {
                    double currentRating = Convert.ToDouble(linesSplit[1]);
                    ratingsCount = Convert.ToInt32(linesSplit[2]);
                    totalRatings = currentRating * ratingsCount;
                    totalRatings += rating;
                    ratingsCount++;
                    newRating = totalRatings / ratingsCount;
                    linesSplit[1] = newRating.ToString("0.##");
                    linesSplit[2] = (ratingsCount).ToString();
                    lines[i] = linesSplit[0] + "\t" + linesSplit[1] + "\t" + linesSplit[2];
                    break;
                }
            }
            System.IO.File.WriteAllLines(@"C:\Resources\Data.txt", lines);
            return newRating;
        }

       /* [WebMethod]
        public double AddRating(Subject s, int newRating)
        {
            *//*s.TotalRatings += newRating;
            s.Rating = s.TotalRatings / s.RatingsCount;*//*
            UpdateData(s.Rating, s.Name);
            return s.Rating;
        }    */   
    }
}
