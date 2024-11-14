using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SortingAlgore
{
    public class Book : IComparable<Book>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public Book(string lastName, string firstName, string title, string releaseDate) 
        {
            LastName = lastName;
            FirstName = firstName;
            Title = title;
            ReleaseDate = releaseDate;
        }
        //Got help form Luke with this
        private static readonly Regex Regex = new Regex(@"^\|\s*(?<LastName>\w+)\s*\|\s*(?<FirstName>\w+)\s*\|\s*(?<Title>.+?)\s*\|\s*(?<ReleaseDate>\d{4}-\d{2}-\d{2})\s*\|$", RegexOptions.Compiled);
        public static Book Parse(string description)
        {
            string lastName;
            string firstName;
            string title;
            string releaseData;
            if (TryParse(description))
            {
                //removes the | from the start of the string
                if (description.StartsWith("|")) { description = description.Remove(0, 1); }
                //removes the | from the end of the string
                if (description.EndsWith("|")) { description = description.Remove(description.Length - 1, 1); }
                //splits the string around the |s
                string[] data = description.Split('|');
                for (int i = 0; i < data.Length; i++)
                {
                    bool active = true;
                    //removes spaces from the begining of the string
                    while (active)
                    {
                        if (data[i].StartsWith(" ")) { data[i] = data[i].Remove(0, 1); }
                        else {  active = false; }
                    }
                    active = true;
                    //removes spaces from the end of the string
                    while (active)
                    {
                        if (data[i].EndsWith(" ")) { data[i] = data[i].Remove(data[i].Length - 1, 1); }
                        else { active = false; }
                    }
                }
                lastName = data[0];
                firstName = data[1];
                title = data[2];
                releaseData = data[3];
                return new Book(lastName, firstName, title, releaseData);
            }
            else { throw new ArgumentException("Book data invalid"); }
        }
        public static bool TryParse(string description)
        {
            var match = Regex.Match(description);
            string lastName = match.Groups[1].Value;
            string firstName = match.Groups[2].Value;
            string title = match.Groups[3].Value;
            string releaseDate = match.Groups[4].Value;
            if (lastName != null && firstName != null && title != null && releaseDate != null) { return true; }
            else return false;
        }
        public string ToString()
        {
            return $"{LastName}, {FirstName}, \"{Title}\", {ReleaseDate}";
        }
        public int CompareTo(Book? other)
        {
            if (LastName.CompareTo(other.LastName) < 0) { return -1; }
            else if (LastName.CompareTo(other.LastName) == 0)
            {
                if (FirstName.CompareTo(other.FirstName) < 0) { return -1; }
                else if (FirstName.CompareTo(other.FirstName) == 0)
                {
                    if (Title.CompareTo(other.Title) < 0) { return -1; }
                    else if (Title.CompareTo(other.Title) == 0)
                    {
                        if (ReleaseDate.CompareTo(other.ReleaseDate) < 0) { return -1; }
                        else if (ReleaseDate.CompareTo(other.ReleaseDate) == 0) { return 0; }
                        else { return 1; }
                    }
                    else { return 1; }
                }
                else { return 1; }
            }
            else { return 1; }
        }
    }
}
