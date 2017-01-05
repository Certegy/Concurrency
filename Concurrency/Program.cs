using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Concurrency.Models;

namespace Concurrency
{
    public class Program
    {
        static void Main(string[] args)
        {
            App_Start.EntityFrameworkProfilerBootstrapper.PreStart();

            var contextOne = new DatabaseContext(isOracle: true);
            var contextTwo = new DatabaseContext(isOracle: true);

            try
            {
                var first = contextOne.Set<UnitTest>().FirstOrDefault();
                Console.WriteLine(first.ToString());

                int rowId = first.Id;

                var second = contextTwo.Set<UnitTest>().Find(rowId);
                Console.WriteLine(second.ToString());

                first.ReferenceNumber++;
                second.ReferenceNumber++;

                first.Name = "FIRST" + first.ReferenceNumber;
                second.Name = "SECOND" + second.ReferenceNumber;

                contextTwo.SaveChanges();
                contextOne.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                contextOne?.Dispose();
                contextTwo?.Dispose();
            }

            Console.WriteLine("Finished");
            Console.ReadLine();
        }
    }
}

