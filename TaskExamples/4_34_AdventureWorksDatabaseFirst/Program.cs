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
        static void Main(string[] args) {

            AdventureWorksContext context = new AdventureWorksContext();

            context.Product.Take(10).ToList().ForEach(x => {
                Console.WriteLine(x.Name);
            });

        }
    }
}
