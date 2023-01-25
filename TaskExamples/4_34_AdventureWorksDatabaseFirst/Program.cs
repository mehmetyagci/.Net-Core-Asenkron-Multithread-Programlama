using _4_34_AdventureWorksDatabaseFirst.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _4_34_AdventureWorksDatabaseFirst {
    internal class Program {

        private static void WriteLog(Product p) {
            Console.WriteLine($"ProductId:{p.ProductId} ProductName:{p.Name} ManagedThreadId:{Thread.CurrentThread.ManagedThreadId} log 'a kaydedildi");
        }

        private static bool IsControl(Product p) {
            try {
                return p.Name[2] == 'a';
            }
            catch(IndexOutOfRangeException iEx) {
                Console.WriteLine($"Dizin sınırları aşıldı! Ama hata değil.");
                return false;
            }
            catch (Exception ex) {
                throw;
            }
        }

        static void Main(string[] args) {

            AdventureWorksContext context = new AdventureWorksContext();

            var products = context.Product.Take(100).ToArray();

            products[3].Name = "##";

            products[5].Name = "##";

            var query = products.AsParallel().Where(IsControl);

            try {
                query.ForAll(x => {
                    Console.WriteLine($"{x.ProductId} - {x.Name} - TheadId:{Thread.CurrentThread.ManagedThreadId}");
                });
            }
            catch (AggregateException aggEx) {
                aggEx.InnerExceptions.ToList().ForEach(x => {
                    if (x is IndexOutOfRangeException) {
                        Console.WriteLine($"Hata: {x.GetType().Name} -  {x.Message} TheadId:{Thread.CurrentThread.ManagedThreadId}");
                    }
                });
            }
            catch (Exception ex) {
                throw;
            }
        }
    }
}




//context.Product.Take(10).ToList().ForEach(x => {
//    Console.WriteLine(x.Name);
//});

// elimde var olan array üzerinde bir sorgu yapmak istiyorsak AsParallel()
// context.Product tüm Product'ları alır. IQueryable
//var product = (from p in context.Product.AsParallel()
//               where p.ListPrice > 10M
//               select p).Take(10);

//var product2 = context.Product.AsParallel().Where(p => p.ListPrice > 10M).Take(10);
//product.ForAll(x => {
//    Console.WriteLine(x.Name);
//});

// IQueryable versiyon
//IQueryable<Product> product = (from p in context.Product
//                               where p.ListPrice > 10M
//                               select p).Take(10);

//var result =product.AsParallel().Where(x => x.Name.StartsWith('a')).For;

//product.ToList().ForEach(p => {
//    Console.WriteLine($"{p.Name} {p.ProductId} {p.ProductNumber}");
//});