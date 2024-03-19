namespace AssignmentAdvancedLinQ;

internal static class Program
{
    public static void Main(string[] args)
    {
        var oppenheimer = new Movie("Oppenheimer", "Christopher Nolan", "Documentary", 2023);
        var sotl = new Movie("Silece of the Lamb", "Jonathan Demme", "Psychological", 1991);
        var spiderMan = new Movie("Spider-man", "Sam Reimi", "Action", 2002);
        var potc = new Movie("Pirates of the Caribbean", "Disney", "Adventure", 2002);
        var tmi = new Movie("The mission impossible", "Tom Cruise", "Spy", 2023);
        var lll = new Movie("Lala Land", "Disney", "Musical", 2021);

        var listOfMovies = new List<Movie>
        {
            oppenheimer,
            sotl,
            spiderMan,
            potc,
            tmi,
            lll
        };
        var listOfActors = new List<Actor>
        {
            new("Cillian", "Murphy", 45, oppenheimer, 2),
            new("Tom", "Cruise", 55, tmi, 1),
            new("Emma", "Stone", 38, lll, 2),
            new("Johnny", "Depp", 60, potc, 1),
            new("William", "Defoe", 70, spiderMan, 1),
            new("Anthony", "Hopkins", 70, sotl, 3),
        };

        //using join operator
        UsingJoinOperator(listOfMovies, listOfActors);

        //using group join to join and group actors by movie
        Console.WriteLine("\nUsing group join operator");
        UsingGroupJoinToGroupActorsByMovie(listOfMovies, listOfActors);

        //using zip to produce new sequence
        Console.WriteLine("\nUsing zip operator");
        UsingZipToProduceNewSequence(listOfMovies, listOfActors);

        //group actors by movies
        Console.WriteLine("\nUsing group by operator");
        UsingGroupByToGroupActors(listOfActors);

        //concatenate actors full names with movies titles
        Console.WriteLine("\nUsing concat operator");
        UsingConcatOperator(listOfActors, listOfMovies);

        //aggregation methods
        Console.WriteLine("\n\nUsing aggregation methods");
        UsingAggregationMethods(listOfMovies, listOfActors);

        //Order by and order then
        Console.WriteLine("\nUsing order by, then by");
        UsingGroupByThenByOperators(listOfMovies);

        //Quantifier
        Console.WriteLine("\nUsing quantifier contains");
        UsingQuantifierOperator(listOfActors, sotl);
    }

    private static void UsingGroupByThenByOperators(List<Movie> listOfMovies)
    {
        var orderListOfMovies = listOfMovies.OrderBy(movie => movie.Title).ThenBy(movie => movie.Year);
        foreach (var movie in orderListOfMovies)
        {
            Console.WriteLine($"{movie.Title}|{movie.Year}|{movie.Genre}|{movie.Director}");
        }
    }

    private static void UsingQuantifierOperator(List<Actor> listOfActors, Movie movieToFind)
    {
        var isTheMovieToFindHasActorWithTheMostOscars = listOfActors
            .Where(actor => actor.NumberOfOscars == listOfActors.Max(a => a.NumberOfOscars))
            .Select(a => a.Movie)
            .Contains(movieToFind);
        Console.WriteLine(
            $"Is the silence of the lamb movie with an actor with the most oscars?:{isTheMovieToFindHasActorWithTheMostOscars}");
    }

    private static void UsingAggregationMethods(List<Movie> listOfMovies, List<Actor> listOfActors)
    {
        var numberOfMoviesBefore2010 = listOfMovies.Count(movie => movie.Year < 2010);
        Console.WriteLine($"Total movies before 2010: {numberOfMoviesBefore2010}");
        var sumOfAllOscars = listOfActors.Sum(actor => actor.NumberOfOscars);
        Console.WriteLine($"Total oscars of all actors: {sumOfAllOscars}");
        var oldestMovieTitle = listOfMovies.Where(movie => movie.Year == listOfMovies.Min(m => m.Year))
            .Select(movie => movie.Title).FirstOrDefault();
        Console.WriteLine($"Oldest movie: {oldestMovieTitle}");
    }

    private static void UsingConcatOperator(IEnumerable<Actor> listOfActors, IEnumerable<Movie> listOfMovies)
    {
        var concatenatedLists = listOfActors.Select(actor => actor.FullName)
            .Concat(listOfMovies.Select(movie => movie.Title)).ToList();
        foreach (var element in concatenatedLists)
        {
            Console.Write($"{element},");
        }
    }

    private static void UsingGroupByToGroupActors(List<Actor> listOfActors)
    {
        var groupedActors = listOfActors.GroupBy(actor => actor.Movie);
        foreach (var groupedActor in groupedActors)
        {
            Console.WriteLine($"{groupedActor.Key.Title}");
            foreach (var actor in groupedActor)
            {
                Console.WriteLine($"{actor.FullName}, Age:{actor.Age}, Oscars:{actor.NumberOfOscars}");
            }
        }
    }

    private static void UsingZipToProduceNewSequence(List<Movie> listOfMovies, List<Actor> listOfActors)
    {
        var zipResult = listOfMovies.Zip(listOfActors, (movie, actor) => $"{movie.Title}-{actor.FullName}");
        foreach (var result in zipResult)
        {
            Console.WriteLine(result);
        }
    }

    private static void UsingGroupJoinToGroupActorsByMovie(IEnumerable<Movie> listOfMovies,
        IEnumerable<Actor> listOfActors)
    {
        var groupJoinResult =
            listOfMovies.GroupJoin(listOfActors, movie => movie, actor => actor.Movie,
                (movie, actor) => new { MovieTitle = movie.Title, Actors = actor });
        foreach (var group in groupJoinResult)
        {
            Console.WriteLine($"{group.MovieTitle}:");
            foreach (var actor in group.Actors)
            {
                Console.WriteLine($"{actor.FullName}, Age:{actor.Age}, Oscars:{actor.NumberOfOscars}");
            }
        }
    }

    private static void UsingJoinOperator(IEnumerable<Movie> listOfMovies, IEnumerable<Actor> listOfActors)
    {
        var joinResult = listOfMovies.Join(listOfActors, movie => movie, actor => actor.Movie,
            (movie, actor) => new { ActorName = actor.FullName, MovieTitle = movie.Title });
        foreach (var result in joinResult)
        {
            Console.WriteLine($"{result.ActorName} - {result.MovieTitle}");
        }
    }
}