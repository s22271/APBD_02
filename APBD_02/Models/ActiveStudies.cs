using System;

public class ActiveStudies
{
	public string ActiveName { get; set; }
	public int NumberOfStudents { get; set; }
    public override string ToString()
    {
        string s = "name: {0}, numberOfStudents: {1}", ActiveName, NumberOfStudents;
        return s;
    }
}
