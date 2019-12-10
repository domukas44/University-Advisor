using Devart.Data.SQLite;
using SQLite;
using System;
using System.Data;
using System.IO;

namespace UniversityAdvisor.Models
{
    public class SubjectDataTable
    {
        private static DataTable table;
        private static SQLiteDataAdapter adapter;
        private static readonly string _dbPath = "DataSource=" + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "uniAdv.db3");
        public static DataTable GetTable()
        {
            if (table == null)
            {
                // Add connection to the DB
                table = new DataTable("Subject");
                var db = new Devart.Data.SQLite.SQLiteConnection(_dbPath);
                adapter = new SQLiteDataAdapter("SELECT Id, Name, Rating, ReviewCount FROM Subjects", db);  // ?? koks lentelės pavadinimas?
                adapter.Fill(table);

                // Add the columns to a new DataTable.
                DataColumn column = new DataColumn("Id")
                {
                    DataType = Type.GetType("System.Int32"),
                    AutoIncrement = true,
                    AutoIncrementSeed = 1,
                    AutoIncrementStep = 1,
                    ReadOnly = true
                };
                table.Columns.Add(column);
                table.Columns.Add("Name", typeof(string));
                table.Columns.Add("Rating", typeof(decimal));
                table.Columns.Add(new DataColumn("ReviewCount")
                {
                    DataType = Type.GetType("System.Int32"),
                    DefaultValue = 0
                });

                // Add data
                table.Rows.Add(null, "Buhalterinė apskaita", 0);
                table.Rows.Add(null, "Informatikos teisė", 0);
                table.Rows.Add(null, "Vadybos pagrindai", 0);
                table.Rows.Add(null, "Elektronikos fizikiniai pagrindai", 0);
                table.Rows.Add(null, "Fizika informatikams", 0);
                table.Rows.Add(null, "Bioinformatika", 0);
                table.Rows.Add(null, "Blokų grandinių technologijos", 0);
                table.Rows.Add(null, "Dirbtinis intelektas", 0);
                table.Rows.Add(null, "Elektroninės komercijos technologijų pagrindai", 0);
                table.Rows.Add(null, "Finansinis intelektas", 0);
                table.Rows.Add(null, "Funkcinis programavimas", 0);
                table.Rows.Add(null, "Informacinių technologijų veiklos valdymas organizacijoje", 0);
                table.Rows.Add(null, "Įvadas į verslo procesų vadybą", 0);
                table.Rows.Add(null, "Judrusis programavimas Ruby", 0);
                table.Rows.Add(null, "Kompiuterinė grafika", 0);
                table.Rows.Add(null, "Kompiuterinių žaidimų projektavimas ir kūrimas", 0);
                table.Rows.Add(null, "Kompiuterių tinklai II", 0);
                table.Rows.Add(null, "Kompiuterių tinklai profesionalams II", 0);
                table.Rows.Add(null, "Lygiagretusis programavimas", 0);
                table.Rows.Add(null, "Loginis programavimas", 0);
                table.Rows.Add(null, "Oracle PL/SQL programavimas", 0);
                table.Rows.Add(null, "Programavimas Windows API", 0);
                table.Rows.Add(null, "Taikomųjų programų kūrimas mobiliesiems įrenginiams ir autonominėms sistemoms", 0);
                table.Rows.Add(null, "Transliavimo metodai", 0);
                table.Rows.Add(null, "Žinių vaizdavimas", 0);
                table.Rows.Add(null, "Diferencialinės lygtys", 0);
                table.Rows.Add(null, "Kodavimo teorija", 0);
                table.Rows.Add(null, "Kombinatorika ir grafų teorija", 0);
                table.Rows.Add(null, "Matematinė analizė", 0);
                table.Rows.Add(null, "Optimizavimo metodai", 0);
                table.Rows.Add(null, "Skaitiniai metodai", 0);
                table.Rows.Add(null, "Statistinė duomenų analizė", 0);
                table.Rows.Add(null, "Duomenų bazių valdymo sistemų papildomi skyriai", 0);
                table.Rows.Add(null, "Geografinės informacinės sistemos", 0);
                table.Rows.Add(null, "Giliojo mokymosi metodai", 0);
                table.Rows.Add(null, "Kompiuterinė technika", 0);
                table.Rows.Add(null, "Kompiuterių tinklai profesionalams I", 0);
                table.Rows.Add(null, "Operacinės sistemos", 0);
                table.Rows.Add(null, "Programavimas PYTHON kalba", 0);
                table.Rows.Add(null, "Skaitmeninis intelektas ir sprendimų priėmimas", 0);
                table.Rows.Add(null, "Informacinės sistemos", 0);
                table.Rows.Add(null, "Matematinis modeliavimas", 0);
                table.Rows.Add(null, "Chaoso teorija ir fraktalai", 0);
                table.Rows.Add(null, "Grafų teorija", 0);
                table.Rows.Add(null, "Informacijos teorija", 0);
                table.Rows.Add(null, "Programavimas OS UNIX", 0);
                table.Rows.Add(null, "UML ir MDA įvadas", 0);

                // Update the DB
                adapter.Update(table);
            }
            return table;
        }

        public static void UpdateSubjectRating(Subject subject)
        {
            // Updates a subject's rating in the DataTable as well as the DB
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (Convert.ToInt32(table.Rows[i]["Id"]) == subject.Id)
                {
                    table.Rows[i]["Rating"] = subject.Rating;
                }
            }
            adapter.Update(table);
        }
    }
}
