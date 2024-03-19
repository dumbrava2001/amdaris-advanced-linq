namespace AssignmentAdvancedLinQ;

public class Movie
{
    public string Title { get; init; }
    public string Director { get; init; }
    public string Genre { get; init; }
    public int Year { get; init; }

    public Movie(string title, string director, string genre, int year)
    {
        Title = title;
        Director = director;
        Genre = genre;
        Year = year;
    }
}