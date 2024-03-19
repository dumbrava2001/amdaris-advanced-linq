namespace AssignmentAdvancedLinQ;

internal static class Program
{
    public static void Main(string[] args)
    {
        var listOfActors = new List<Actor>
        {
            new("Cillian", "Murphy", 45, 2),
            new("Tom", "Cruise", 55, 1),
            new("Emma", "Stone", 38, 2),
            new("Johnny", "Depp", 60, 1),
            new("William", "Defoe", 70, 1),
            new("Anthony", "Hopkins", 70, 3),
        };

        var listOfMovies = new List<Movie>
        {
            new("Oppenheimer", "Christopher Nolan", "Documentary", 2023),
            new("Silece of the Lamb", "Jonathan Demme", "Psychological", 1991),
            new("Spider-man", "Sam Reimi", "Action", 2002),
            new("Pirates of the Caribbean", "Disney", "Adventure", 2002),
            new("The mission impossible", "Tom Cruise", "Spy", 2023),
            new("Lala Land", "Disney", "Musical", 2021),
        };
    }
}