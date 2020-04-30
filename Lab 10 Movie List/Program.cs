using System;
using System.Collections.Generic;

namespace Lab_10_Movie_List
{
    class Program // seamless GR
    {
        static void Main(string[] args)
        {
            List<Movie> allmovies = new List<Movie>();
            allmovies.Add(new Movie(MovieCategory.Animated, "Transformers"));
            allmovies.Add(new Movie(MovieCategory.Animated, "Pokemon"));
            allmovies.Add(new Movie(MovieCategory.Drama, "Parasite"));
            allmovies.Add(new Movie(MovieCategory.Drama, "Ford v Ferrari"));
            allmovies.Add(new Movie(MovieCategory.Horror, "The Shining"));
            allmovies.Add(new Movie(MovieCategory.Horror, "Scream"));
            allmovies.Add(new Movie(MovieCategory.Scifi, "2001: A Space Odyssey"));
            allmovies.Add(new Movie(MovieCategory.Scifi, "E.T.The Extra-terrestrial"));
            allmovies.Add(new Movie(MovieCategory.Scifi, "Close Encounters of the Third Kind"));
            allmovies.Add(new Movie(MovieCategory.Scifi, "Star Wars"));
            allmovies.Sort();

            string cont = "y";
            Console.WriteLine("Welcome to the Movie List Application!");
            Console.WriteLine("There are " + allmovies.Count + " movies in this list.");

            do
            {
                Console.WriteLine("\nPlease enter the category number that you interested in: ");

                foreach (MovieCategory mc in Enum.GetValues(typeof(MovieCategory)))
                {
                    Console.WriteLine( (int)mc + ": " + mc);
                }
                
                string inputCategory = Console.ReadLine();

                int inputCatInt = 0;
                MovieCategory movieCategory;
                String mcString;

                try
                {
                    inputCatInt = int.Parse(inputCategory);                
                    movieCategory = (MovieCategory) inputCatInt;
                    mcString = Enum.GetName(typeof(MovieCategory), inputCatInt);
                } catch
                {
                    mcString = null;
                }

                if (mcString != null)
                {
                    foreach (Movie m in allmovies)
                    {
                        if (m.Category == (MovieCategory) inputCatInt)
                        {
                            Console.WriteLine(m.Title);
                        }
                    }

                    Console.WriteLine("\nContinue?(y/n): ");
                    cont = Console.ReadLine();
                } else
                {
                    Console.WriteLine("I'm sorry I didn't understand");
                }
                
            } while (cont.Equals("y"));
        }
    }

    public enum MovieCategory
    {
        Animated = 1,
        Drama = 2,
        Horror = 3,
        Scifi = 4
    }

    class Movie : IComparable<Movie>
    {
        
        private MovieCategory category;
        public MovieCategory Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
            }

        }

        private string title;
        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }

        }

        public Movie(MovieCategory categoryIn, string titleIn)
        {
            category = categoryIn;
            title = titleIn;
        }

        public int CompareTo(Movie other)
        {
            return this.Title.CompareTo(other.Title);
        }
    }
}
