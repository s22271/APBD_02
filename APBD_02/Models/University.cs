using System;

public class University
{
	public string CreatedAt { get; set; }
	public string Author { get; set; }
	public List<Student> studentSet;
	public ActiveStudies activeStudies;
    public override string ToString()
    {
		string s = "createdAt: {0}, author: {1}, students: {2}, activeStudies: {3}", CreatedAt, Author, studentSet, activeStudies;
		return s;
	}

}
