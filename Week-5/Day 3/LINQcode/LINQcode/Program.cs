using System;
using System.Linq;

namespace LinqCodeTemplate
{
    internal class Program
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();

            // 1. FMCG Products
            Console.WriteLine("\n1. FMCG Products:");
            var result1 = products.Where(p => p.ProCategory == "FMCG");
            foreach (var item in result1)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProCategory}\t{item.ProMrp}");

            // 2. Grain Products
            Console.WriteLine("\n2. Grain Products:");
            var result2 = products.Where(p => p.ProCategory == "Grain");
            foreach (var item in result2)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProCategory}\t{item.ProMrp}");

            // 3. Sort by Product Code (Ascending)
            Console.WriteLine("\n3. Sorted by Product Code:");
            var result3 = products.OrderBy(p => p.ProCode);
            foreach (var item in result3)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProCategory}\t{item.ProMrp}");

            // 4. Sort by Category (Ascending)
            Console.WriteLine("\n4. Sorted by Category:");
            var result4 = products.OrderBy(p => p.ProCategory);
            foreach (var item in result4)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProCategory}\t{item.ProMrp}");

            // 5. Sort by MRP (Ascending)
            Console.WriteLine("\n5. Sorted by MRP (Ascending):");
            var result5 = products.OrderBy(p => p.ProMrp);
            foreach (var item in result5)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProCategory}\t{item.ProMrp}");

            // 6. Sort by MRP (Descending)
            Console.WriteLine("\n6. Sorted by MRP (Descending):");
            var result6 = products.OrderByDescending(p => p.ProMrp);
            foreach (var item in result6)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProCategory}\t{item.ProMrp}");

            // 7. Group by Category
            Console.WriteLine("\n7. Group by Category:");
            var result7 = products.GroupBy(p => p.ProCategory);
            foreach (var group in result7)
            {
                Console.WriteLine($"\nCategory: {group.Key}");
                foreach (var item in group)
                    Console.WriteLine($"{item.ProName} - {item.ProMrp}");
            }

            // 8. Group by MRP
            Console.WriteLine("\n8. Group by MRP:");
            var result8 = products.GroupBy(p => p.ProMrp);
            foreach (var group in result8)
            {
                Console.WriteLine($"\nMRP: {group.Key}");
                foreach (var item in group)
                    Console.WriteLine($"{item.ProName} - {item.ProCategory}");
            }

            // 9. Highest price in FMCG
            Console.WriteLine("\n9. Highest Price in FMCG:");
            var result9 = products
                          .Where(p => p.ProCategory == "FMCG")
                          .OrderByDescending(p => p.ProMrp)
                          .FirstOrDefault();

            if (result9 != null)
                Console.WriteLine($"{result9.ProCode}\t{result9.ProName}\t{result9.ProMrp}");

            // 10. Count of total products
            Console.WriteLine("\n10. Total Products Count:");
            Console.WriteLine(products.Count());

            // 11. Count of FMCG products
            Console.WriteLine("\n11. FMCG Products Count:");
            Console.WriteLine(products.Count(p => p.ProCategory == "FMCG"));

            // 12. Max price
            Console.WriteLine("\n12. Maximum Price:");
            Console.WriteLine(products.Max(p => p.ProMrp));

            // 13. Min price
            Console.WriteLine("\n13. Minimum Price:");
            Console.WriteLine(products.Min(p => p.ProMrp));

            // 14. All products below Rs.30?
            Console.WriteLine("\n14. Are all products below Rs.30?");
            Console.WriteLine(products.All(p => p.ProMrp < 30));

            // 15. Any product below Rs.30?
            Console.WriteLine("\n15. Is any product below Rs.30?");
            Console.WriteLine(products.Any(p => p.ProMrp < 30));

            Console.ReadLine();
        }
    }
}