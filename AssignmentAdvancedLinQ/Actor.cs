using System.Runtime.InteropServices.JavaScript;

namespace AssignmentAdvancedLinQ;

public class Actor
{
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public string FullName => $"{FirstName} {LastName}";

    public int Age { get; init; }

    public int NumberOfOscars { get; set; }

    public Movie Movie { get; init; }

    public Actor(string firstName, string lastName, int age, Movie movie, int numberOfOscars)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Movie = movie;
        NumberOfOscars = numberOfOscars;
    }
}