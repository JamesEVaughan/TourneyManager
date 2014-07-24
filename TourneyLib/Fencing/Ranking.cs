using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TourneyLib.Fencing
{
    /// <summary>
    /// Represents a rating, used for initial seeding of a fencer.
    /// </summary>
    class Ranking : IComparable
    {
        public enum Classification
        {
            A = 1,
            B,
            C,
            D,
            E,
            U
        };

        // Properties
        public Classification Rating
        {
            get { return rating; }
            internal set { rating = value; }
        }

        public int Year
        {
            get { return year; }
            internal set { year = value; }
        }

        // Constructors/destructors
        /// <summary>
        /// Default contructor. Sets Ranking as lowest value
        /// </summary>
        public Ranking()
        {
            Rating = Classification.U;
            Year = -1;
        }
        /// <summary>
        /// Sets up Ranking based on a character and year.
        /// </summary>
        /// <param name="temp">String representing a ranking. Expect as a 3 
        /// char string of a letter and two-digit year</param>
        public Ranking(string temp)
        {
            char rt = temp[0];
            int yr = Int32.Parse(temp.Substring(1));
            switch (rt)
            {
                case 'a':
                case 'A':
                    Rating = Classification.A;
                    break;
                case 'b':
                case 'B':
                    Rating = Classification.B;
                    break;
                case 'c':
                case 'C':
                    Rating = Classification.C;
                    break;
                case 'd':
                case 'D':
                    Rating = Classification.D;
                    break;
                case 'e':
                case 'E':
                    Rating = Classification.E;
                    break;
                case 'u':
                case 'U':
                default:
                    Rating = Classification.U;
                    break;
            }
            if (rating == Classification.U)
            {
                year = -1;
            }
            else 
            {
                year = yr;
            }
        }
        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="oth">Some other Ranking to be copied</param>
        public Ranking(Ranking oth)
        {
            rating = oth.rating;
            year = oth.year;
        }

        // Methods


        // IComparable
        public int CompareTo(Object obj)
        {
            // If obj isn't valid, it goes first
            if (obj == null)
            {
                return 1;
            }

            // Now, try to make it a Ranking instance
            Ranking othRan = obj as Ranking;
            if (othRan == null)
            {
                // It's not a Ranking, throw an argument exception
                throw new ArgumentException();
            }

            // First, order by Rating
            int result = (int)rating - (int)othRan.rating;
            if (result != 0)
            {
                return result;
            }
            else if (rating == Classification.U)
            {
                return 0;
            }
            else
            {
                return year - othRan.year;
            }
        }

        // Fields
        private Classification rating;
        private int year;
    }
}
