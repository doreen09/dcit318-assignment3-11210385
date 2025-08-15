using System;
using System.Collections.Generic;
using System.IO;

namespace SchoolGradingSystem
{
    // a) Student class
    public class Student
    {
        public int Id;
        public string FullName;
        public int Score;

        public Student(int id, string fullName, int score)
        {
            Id = id;
            FullName = fullName;
            Score = score;
        }

        public string GetGrade()
        {
            if (Score >= 80 && Score <= 100) return "A";
            if (Score >= 70 && Score <= 79) return "B";
            if (Score >= 60 && Score <= 69) return "C";
            if (Score >= 50 && Score <= 59) return "D";
            return "F";
        }
    }

    
    public class InvalidScoreFormatException : Exception
    {
        public InvalidScoreFormatException(string message) : base(message) { }
    }

    public class MissingFieldException : Exception
    {
        public MissingFieldException(string message) : base(message) { }
    }

    public class StudentResultProcessor
    {
        public List<Student> ReadStudentsFromFile(string inputFilePath)
        {
            var students = new List<Student>();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');

                    if (parts.Length != 3)
                        throw new MissingFieldException($"Missing field in line: {line}");

                    int id;
                    if (!int.TryParse(parts[0], out id))
                        throw new Exception($"Invalid ID format in line: {line}");

                    string name = parts[1].Trim();

                    int score;
                    if (!int.TryParse(parts[2], out score))
                        throw new InvalidScoreFormatException($"Invalid score format in line: {line}");

                    students.Add(new Student(id, name, score));
                }
            }

            return students;
        }
    }



}