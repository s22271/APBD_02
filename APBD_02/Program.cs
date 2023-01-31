using System;
using System.Collections;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        string author = "Karolina Domańska";
        string createDate = DateTime.Now.ToShortDateString();
        var studentList = new List<Student>();
        var studiesList = new List<ActiveStudies>();

        string logger = "log.txt";
        StreamWriter streamWriter = null;

        if(File.Exists(logger))
        {
            streamWriter = File.AppendText(logger);
        }
        else
        {
            streamWriter = File.CreateText(logger);
        }
        if (args.Length != 3)
        {
            string ex = "Za mało argumentów!";
            streamWriter.WriteLine(ex);
            throw new ArgumentException(ex);
            streamWriter.Dispose();
        }
        string data = args[0];
        

        if(!data.EndsWith(".csv") || data.Length == 0)
        {
            string ex = "Podana ścieżka jest niepoprawna!";
            streamWriter.WriteLine(ex);
            throw new ArgumentException(ex);
            streamWriter.Dispose();
        }
        if(!File.Exists(data))
        {
            string ex = "Plik " + data + " nie istnieje!";
            streamWriter.WriteLine(ex);
            throw new FileNotFoundException(ex);
            streamWriter.Dispose();
        }

        foreach (var line in File.ReadLines(data))
        {
            string[] content = line.Split(',');
            if(!(content.Length == 9)) {
                string ex = "Nieprawidłowa liczba kolumn!";
                streamWriter.WriteLine(ex + line);
                throw new Exception(ex);
                streamWriter.Dispose();
            }
            foreach(var i in content)
            {
                if(i.Length == 0)
                {
                    string ex = "Brakująca wartość!";
                    streamWriter.WriteLine(ex + "\n" + line);
                    throw new Exception(ex);
                    streamWriter.Dispose();
                }
                Student student = new Student
                {
                    FirstName = content[0],
                    LastName = content[1],
                    Studies = new StudiesType
                    {
                        Subject = content[2],
                        Mode = content[3],
                    },
                    IndexNumber = content[4],
                    BirthDate = content[5],
                    Email = content[6],
                    MotherName = content[7],
                    FatherName = content[8]
                };
                foreach (var s in studentList)
                {
                    if (!((s.FirstName == student.FirstName) && (s.LastName == student.LastName) && (s.IndexNumber == student.IndexNumber)))
                    {
                        studentList.Add(student);
                    }
                    else
                    {
                        string ex = "Duplikat!";
                        streamWriter.WriteLine(ex + "\n" + line);
                        throw new Exception(ex);
                        streamWriter.Dispose();
                    }
                    
                }
                 foreach(var l in studiesList)
                    {
                    foreach (var v in studentList)
                    {

                        if (!(l.ActiveName == v.Studies.Subject))
                        {
                            ActiveStudies activestudies = new ActiveStudies
                            {
                                ActiveName = v.Studies.Subject,
                                NumberOfStudents = 0
                            }; 
                            activestudies.NumberOfStudents++;

                            studiesList.Add(activestudies);
                        }

                    }
                }

                


            }
        }
        string destination = args[1];
        string format = args[2];
        if (!(format == "json"))
        {
            string ex = "Nieprawidłowy format!";
            streamWriter.WriteLine(ex);
            throw new Exception(ex);
            streamWriter.Dispose();
        }
        University university = new University
        {
            Author = author,
            CreatedAt = createDate,
            studentSet = studentList,
            activeStudies = new ActiveStudies
            {
                ActiveName = studiesList.Keys,
                NumberOfStudents = studiesList.Values
            }
        }
        File.WriteAllLines(destination, university.ToString());
       
    }
    
}