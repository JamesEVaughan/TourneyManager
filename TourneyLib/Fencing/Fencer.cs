using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TourneyLib.Fencing
{
    /// <summary>
    /// Represents a single fencer in a tournament.
    /// </summary>
    class Fencer : IComparable
    {
        // Properties
        /// <summary>
        /// The fencer's first name.
        /// </summary>
        public string FirstName
        {
            get { return fName; }
            set { fName = value; }
        }
        /// <summary>
        /// The fencer's last name.
        /// </summary>
        public string LastName
        {
            get { return lName; }
            set { lName = value; }
        }
        /// <summary>
        /// The fencer's ranking. Used to determine initial seeding
        /// </summary>
        public Ranking Rank
        {
            get { return rank; }
            set { rank = new Ranking(value); }
        }
        /// <summary>
        /// The fencer's lot number, used for tiebreaking in initial seeding
        /// </summary>
        public int Lot
        {
            get { return lot; }
            internal set { lot = value; }
        }

        // Constructors
        public Fencer(string first, string last, string rnk)
        {
            fName = first;
            lName = last;
            rank = new Ranking(rnk);
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

            // Now, try to make it a Fencer instance
            Fencer othFen = obj as Fencer;
            if (othFen == null)
            {
                // It's not a Fencer, throw an argument exception
                throw new ArgumentException();
            }

            int result;
            // If it is a fencer, do it by Rank...
            result = rank.CompareTo(othFen.rank);
            if (result != 0)
            {
                return result;
            }
            // If the Ranks are equal, break the tie with lots
            else
            {
                return lot - othFen.lot;
            }
        }

        // Fields
        /// <summary>
        /// The field behind the FirstName property.
        /// </summary>
        private string fName;
        /// <summary>
        /// The field behind the LastName property.
        /// </summary>
        private string lName;
        /// <summary>
        /// The field behind the Rank property
        /// </summary>
        private Ranking rank;
        /// <summary>
        /// The field behing the Lot property
        /// </summary>
        private int lot;
    }
}
