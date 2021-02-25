using System;
using System.Linq;

namespace LinqTut {
    class Program {
        static void Main(string[] args) {
            //join examples 
            var customers = new Customer[] {
                new Customer {Id = 1, Name = "MAX"},
                new Customer {Id = 2, Name = "Jimmy Johns"}
            };
            var orders = new Order[] {
                new Order { Id = 1, Total = 100m, CustId = 2},
                new Order { Id = 2, Total = 200m, CustId = 1},
                new Order { Id = 3, Total = 300m, CustId = 2}
            };
            var orderlines = new Orderline[] {
                new Orderline { Id = 1, OrderId = 1, Product = "Echo", Quantity = 1, Price = 100m},
                new Orderline { Id = 2, OrderId = 2, Product = "Echo", Quantity = 1, Price = 100m},
                new Orderline { Id = 3, OrderId = 2, Product = "EchoDot", Quantity = 2, Price = 50m},
                new Orderline { Id = 4, OrderId = 3, Product = "Echo", Quantity = 2, Price = 100m},
                new Orderline { Id = 5, OrderId = 3, Product = "EchoShow8", Quantity = 1, Price = 140m},
                new Orderline { Id = 6, OrderId = 3, Product = "Fire TV Stick", Quantity = 1, Price = 60m}
            };
            // Query Syntax: List all orders and the lines on those orders
            // display order: id, total; orderline: product, quantity, price
            #region Answer
            var ordlines = from o in orders
                        join l in orderlines
                        on o.Id equals l.OrderId
                        orderby o.Id
                        select new {
                            o.Id, o.Total, l.Product, l.Quantity, l.Price,
                            Subtotal = l.Quantity * l.Price
                        };
            #endregion





            ////var custord = from c in customers
            ////              join o in orders
            ////              on c.Id equals o.CustId
            ////              join l in orderlines
            ////              on o.Id equals l.OrderId
            ////              orderby o.Total descending
            ////              group o by o.Id into ord
            ////              select new {
            ////                  ord.Key, o.total
            ////              };

            ////example of doing what we did in Linq in a foreach statement to show how much easier and less error prone linq can be
            //foreach(var col in custord) {
            //    Console.WriteLine($"{col.Id}|{ col.Name}|{col.Total}|{col.Product}|{col.Quantity}|{col.Price}");
            //}


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

            var numbers2 = new int[] {
               3374,6512,6885,4146,4229,2752,  3990,6406,1712,8844,
               9113,9427,5021,1455,7621,4933,  2630,8245,2527,7931,
               9027,4463,7382,2411,7650,8503,  1539,6115,7877,5338,
               1442,6126,2612,5965,7712,4034,  3496,7151,3998,9566,
               3682,4607,6566,1426,7370,9807,  9922,1355,7195,3687
                };
            // display numbers in numbers2 evenly divisable by 3
            #region Answer
            var divsBy3 = from nbr in numbers2
                          where nbr % 3 == 0
                          select nbr;
            #endregion



            // join the two collections together and only have them display the numbers they both have together 
            #region Answer
            var nbrsInBoth = from n1 in numbers
                        join n2 in numbers2
                        on n1 equals n2
                        select n1; // the select could also be n2, it does not matter
            #endregion





            //Query Syntax: (sum the numbers// this is new) between 1500 and 3000 OR between 6500 and 8500
            // sorted in asc order
            #region Answer
            var q3 = (from nbr in numbers
                      where (nbr > 1500 && nbr < 3000) || (nbr > 6500 && nbr < 8500) // they are wrapped in () so they can get read by themselves and evaluated
                      orderby nbr
                      select nbr).Sum(n => n);// here we wrapped the entire statement inside () to find the sum then did .sum(n => n); this would bring us the sum of the statement we did.
          
            //method
            var m3 = numbers.Where(nbr => (nbr > 1500 && nbr < 3000) || (nbr >6500 && nbr < 8500))
                            .OrderBy(nbr => nbr).ToList();
            #endregion                  

            //Query Syntax: number less than 2000, OR greater than 8000 sorted by desc
            #region Answer
            var q2 = from nbr in numbers
                   where  nbr < 2000 || nbr < 8000 // you can do OR by the double straight brackets (||)
                   orderby nbr descending // aecending is default but this is how you would do descending, you put it after the variable 
                   select nbr;

            //method
            var m2 = numbers.Where(nbr => nbr < 2000 || nbr < 8000)
                                .OrderByDescending(nbr => nbr).ToList();
            #endregion


            //Query Syntax: number greater than 2500 and less than 7500
            #region Answer
            var q1 = from nbr in numbers
                       where nbr >= 2500 && nbr <= 7500// the && means and
                       orderby nbr
                       select nbr;

            //method
           var m1 = numbers.Where(nbr => nbr >= 2500 &&  nbr <= 7500)
                                    .OrderBy(nbr => nbr).ToList();
            #endregion





            //Query syntax
            var lessThan5000 = from nbr in numbers
                               where nbr < 5000
                               orderby nbr
                               select nbr;
            //method Syntax
            var lessThan5000A = numbers.Where(nbr => nbr < 5000)
                             .OrderBy(nbr => nbr).ToList();// the nbr=> nbr means it sorting by the value in the collections

        }
    }
}


