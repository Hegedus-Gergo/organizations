using ConsoleApp7;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

List<Organization> organizations = new List<Organization>();
StreamReader streamReader = new StreamReader("organizations-100000.csv");
streamReader.ReadLine();
while (!streamReader.EndOfStream) {
    organizations.Add(new Organization(streamReader.ReadLine().Replace(", ", " ").Split(';')));
}
Console.WriteLine($"1. Feladat\n\t {organizations.Count(x=>x.Founded == 2012)} db");
Console.WriteLine($"2. Feladat {(organizations.Count(x => x.Industry == "Secondary Education") > organizations.Count(x => x.Industry == "Military Industry") ? "Secondary Education" : "Military Industry")} területen többen dolgoznak!");
Console.WriteLine("3. Feladat");
var evente = organizations.GroupBy(x => x.Founded).Select(x => new{year = x.Key,count = x.Count() }).OrderBy(x => x.year);
foreach (var item in evente) {
    Console.WriteLine($"{item.year} évben {item.count} szervezet jött létre");
}
Console.WriteLine("4. Feladat");
var orszagonkent = organizations.GroupBy(x => x.Country).Select(x => new {country = x.Key,count = x.Count() }).OrderByDescending(x => x.count).Take(5);
foreach (var item in orszagonkent) {
Console.WriteLine($"{item.country} országban {item.count} szervezet jött létre");   
}
Console.WriteLine("5. Feladat");
var orszagok = organizations.GroupBy(x => x.Country).OrderBy(x => x.Key);
foreach (var item in orszagok) {
    Console.WriteLine(item.Key);
}
var orgok = organizations.Where(x => x.Website.EndsWith(".org")).GroupBy(x=>x.Country).Select(x => new {orszag =x.Key, orgosWeboldalakSzama = x.Key }).ToList();
foreach (var item in orgok) {
//    Console.WriteLine(item.Count());
}

Console.WriteLine(organizations.Where(x => x.Industry == "Plastics").Average(x=>x.EmployeesNumber));
