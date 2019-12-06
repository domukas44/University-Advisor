using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UniversityAdvisor.Models;

namespace UniversityAdvisor.Services
{
    public class SubjectDataStore : IDataStore<Subject>
    {
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "uniAdv.db3");
        SQLiteConnection db;

        readonly List<Subject> subjects;

        public SubjectDataStore()
        {
            subjects = new List<Subject>()
            {
                new Subject ("Buhalterinė apskaita", 0),
                new Subject ("Informatikos teisė", 0),
                new Subject ("Vadybos pagrindai", 0),
                new Subject ("Elektronikos fizikiniai pagrindai", 0), 
                new Subject ("Fizika informatikams", 0),
                new Subject ("Bioinformatika", 0),
                new Subject ("Blokų grandinių technologijos", 0),
                new Subject ("Dirbtinis intelektas", 0),
                new Subject ("Elektroninės komercijos technologijų pagrindai", 0),
                new Subject ("Finansinis intelektas", 0),
                new Subject ("Funkcinis programavimas", 0),
                new Subject ("Informacinių technologijų veiklos valdymas organizacijoje", 0),
                new Subject ("Įvadas į verslo procesų vadybą", 0),
                new Subject ("Judrusis programavimas Ruby", 0),
                new Subject ("Kompiuterinė grafika", 0),
                new Subject ("Kompiuterinių žaidimų projektavimas ir kūrimas", 0),
                new Subject ("Kompiuterių tinklai II", 0),
                new Subject ("Kompiuterių tinklai profesionalams II", 0),
                new Subject ("Lygiagretusis programavimas", 0),
                new Subject ("Loginis programavimas", 0),
                new Subject ("Oracle PL/SQL programavimas", 0),
                new Subject ("Programavimas Windows API", 0),
                new Subject ("Taikomųjų programų kūrimas mobiliesiems įrenginiams ir autonominėms sistemoms", 0),
                new Subject ("Transliavimo metodai", 0),
                new Subject ("Žinių vaizdavimas", 0),
                new Subject ("Diferencialinės lygtys", 0),
                new Subject ("Kodavimo teorija", 0),
                new Subject ("Kombinatorika ir grafų teorija", 0),
                new Subject ("Matematinė analizė", 0),
                new Subject ("Optimizavimo metodai", 0),
                new Subject ("Skaitiniai metodai", 0),
                new Subject ("Statistinė duomenų analizė", 0),
                new Subject ("Duomenų bazių valdymo sistemų papildomi skyriai", 0),
                new Subject ("Geografinės informacinės sistemos", 0),
                new Subject ("Giliojo mokymosi metodai", 0),
                new Subject ("Kompiuterinė technika", 0),
                new Subject ("Kompiuterių tinklai profesionalams I", 0),
                new Subject ("Operacinės sistemos", 0),
                new Subject ("Programavimas PYTHON kalba", 0),
                new Subject ("Skaitmeninis intelektas ir sprendimų priėmimas", 0),
                new Subject ("Informacinės sistemos", 0),
                new Subject ("Matematinis modeliavimas", 0),
                new Subject ("Chaoso teorija ir fraktalai", 0),
                new Subject ("Grafų teorija", 0),
                new Subject ("Informacijos teorija", 0),
                new Subject ("Programavimas OS UNIX", 0),
                new Subject ("UML ir MDA įvadas", 0)
            };

            db = new SQLiteConnection(_dbPath);
            db.DropTable<Subject>();            // delete line later
            db.CreateTable<Subject>();

            // or add check if already inserted?
            db.InsertAll(subjects);
        }

        public async Task<bool> AddItemAsync(Subject s)
        {
            subjects.Add(s);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Subject s)
        {
            var oldItem = subjects.Where((Subject arg) => arg.Id == s.Id).FirstOrDefault();
            subjects.Remove(oldItem);
            subjects.Add(s);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = subjects.Where((Subject arg) => arg.Id == Convert.ToInt32(id)).FirstOrDefault();
            subjects.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Subject> GetItemAsync(string id)
        {
            return await Task.FromResult(subjects.FirstOrDefault(s => s.Id == Convert.ToInt32(id)));
        }

        public async Task<IEnumerable<Subject>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(subjects);
        }
    }
}