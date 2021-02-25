using System;
using System.Linq;

namespace LinqTut {
    class Program {
        static void Main(string[] args) {

            var numbers = new int[] {
            8927, 2150, 2883, 2221, 3643, 4126, 5256, 9275, 7016, 1169,
            2681, 3087, 8256, 8125, 6865, 9366, 9547, 6634, 4739, 7914,
            9636, 8905, 9553, 4122, 8553, 9658, 8406, 8915, 7426, 7525,
            2279, 2724, 7744, 5838, 2630, 1483, 7161, 4514, 9937, 9453,
            3173, 5348, 3380, 4891, 5079, 8044, 5584, 6619, 8953, 4438,
            2543, 3843, 7468, 4139, 1426, 9309, 4631, 7133, 2527, 7507,
            2196, 2993, 3333, 9427, 3895, 3532, 8503, 4874, 2459, 5657,
            3086, 4653, 2396, 7749, 9524, 3291, 1895, 8809, 6948, 7992,
            3187, 4512, 1318, 6572, 9904, 2175, 6726, 9956, 3943, 3190,
            6469, 5237, 7988, 1240, 7585, 1458, 4339, 3120, 2976, 3659
            };
            //Query Syntax: numbers between 1500 and 3000 OR between 6500 and 8500
            // sorted in asc order
            var q3 from nbr in numbers
                   where (nbr > 1500 && < 3000) || (nbr > 6500 && < 8500) // they are wrapped in () so they can get read by themselves and evaluated
                   orderby nbr descending
                   select nbr;

            //method
            var m3 = numbers.Where(nbr => nbr > 1500) && (nbr => nbr < 3000) || (nbr => nbr 6500) && (nbr => nbr < 8500).orderby(nbr => nbr).Tolist;

            //Query Syntax: number less than 2000, OR greater than 8000 sorted by desc
            var q2 from nbr in numbers
                   where  nbr < 2000 || nbr < 8000 // you can do OR by the double straight brackets (||)
                   orderby nbr descending // aecending is default but this is how you would do descending, you put it after the variable 
                   select nbr;

            //method
            var m2 = numbers.Where(nbr => nbr < 2000 || nbr < 8000).orderby.descending(nbr => nbr).Tolist();



            //Query Syntax: number greater than 2500 and less than 7500
            var q1 = from nbr in numbers
                       where nbr >= 2500 && nbr <= 7500// the && means and
                       orderby nbr
                       select nbr;

            //method
           var m1 = numbers.where(nbr => nbr >= 2500 &&  nbr <= 7500)
                                    .orderby(nbr => nbr).Tolist();





            //Query syntax
            var lessThan5000 = from nbr in numbers
                               where nbr < 5000
                               orderby nbr
                               select nbr;
            //method Syntax
            var lessThan5000A = numbers.Where(nbr => nbr < 5000).OrderBy(nbr => nbr).ToList();// the nbr=> nbr means it sorting by the value in the collections

        }
    }
}


