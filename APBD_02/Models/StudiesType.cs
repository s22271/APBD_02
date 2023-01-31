using System;

public class StudiesType	
{
	public string Subject { get; set; }
	public string Mode { get; set; }
    public override string ToString()
    {
        string s = "name: {0}, mode: {1}", Subject, Mode;
        return s;
    }
}
