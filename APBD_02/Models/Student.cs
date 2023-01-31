public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public StudiesType Studies { get; set; }
    public string IndexNumber { get; set; }
    public string BirthDate { get; set; }
    public string Email { get; set; }
    public string MotherName { get; set; }
    public string FatherName { get; set; }
    public override string ToString()
    {
        string s = "indexNumber: s{0}, fname: {1}, lname: {2}, birthdate: {3}," +
            "email: {4}, mothersName: {5}, fathersName: {6}, studies: {7}", IndexNumber,
            FirstName, LastName, BirthDate, Email, MotherName, FatherName, Studies;
        return s;
    }
}
