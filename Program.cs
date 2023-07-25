using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>();

        // Read data from the text file and populate the 'students' list
        string filePath = @"D:\mphasis\Assisted project\phase1section8_1.32\phase1section8_1.32\students.txt\";
        ReadDataFromFile(filePath, students);

        // Sort the 'students' list by name
        students.Sort((s1, s2) => string.Compare(s1.Name, s2.Name, StringComparison.OrdinalIgnoreCase));

        // Display the sorted list of students
        DisplayStudents(students);

        // Allow searching of students by name
        Console.Write("\nEnter the student's name to search: ");
        string searchName = Console.ReadLine();
        SearchStudentByName(students, searchName);
    }

    // Read student data from the file and populate the list
    static void ReadDataFromFile(string filePath, List<Student> students)
    {
        try
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                if (data.Length == 2)
                {
                    string name = data[0].Trim();
                    int studentClass = int.Parse(data[1].Trim());

                    students.Add(new Student { Name = name, Class = studentClass });
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found. Please ensure 'students.txt' exists with the correct data format.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while reading the file: " + ex.Message);
        }
    }

    // Display the list of students
    static void DisplayStudents(List<Student> students)
    {
        Console.WriteLine("\nList of students:");
        Console.WriteLine("-----------------");
        foreach (var student in students)
        {
            Console.WriteLine($"{student.Name}, Class {student.Class}");
        }
    }

    // Search for a student by name and display the result
    static void SearchStudentByName(List<Student> students, string searchName)
    {
        var result = students.FindAll(student => student.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));

        if (result.Count > 0)
        {
            Console.WriteLine("\nSearch results:");
            Console.WriteLine("----------------");
            foreach (var student in result)
            {
                Console.WriteLine($"{student.Name}, Class {student.Class}");
            }
        }
        else
        {
            Console.WriteLine("\nStudent not found.");
        }
    }
}
