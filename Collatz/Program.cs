// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Collatz.Collatz;
using Collatz.Services;
using Collatz.Interfaces;

Console.WriteLine("Hello, Collatz!");
Console.WriteLine(" ");





var serviceProvider = new ServiceCollection()
    .AddSingleton<ICollatzService, CollatzService>()
    .BuildServiceProvider();


var collatz = serviceProvider.GetRequiredService<ICollatzService>();

collatz.Print_From_Number(10);





















//CollatzTree tree = new CollatzTree();
//CollatzService CollatzService = new CollatzService(tree);


//int x = CollatzService.Find_Least_Common_Ancestor(69, 1280).value;

//Console.WriteLine($"The Least Common Ancestor is: {x}");

//Console.WriteLine("Printing Tree 101:");
//tree.PrintFromNumber(101);
//Console.WriteLine(" ");

//disty.getTallyFromNum(tree, 101);
//Console.WriteLine($"Leading Digit Distribution from {101} => 1");
//disty.printDistribution();

//int x = 10;
//int y = 12;
//int z = 13;

//Console.WriteLine($"Printing Tree {x}:");
//tree.PrintFromNumber(x);
//Console.WriteLine(" ");

////tree._distribution.getTallyFromNum(tree, x);
//Console.WriteLine($"Leading Digit Distribution from {x} => 1");
////tree._distribution.printDistribution();
//tree.printdistributionFrom(x);
//Console.WriteLine(" ");

//Console.WriteLine($"Printing Tree {y}:");
//tree.PrintFromNumber(y);
//Console.WriteLine(" ");
//Console.WriteLine($"Leading Digit Distribution from {y} => 1");
////tree._distribution.printDistribution();
//tree.printdistributionFrom(y);
//Console.WriteLine(" ");

//Console.WriteLine($"Printing Tree {z}:");
//tree.PrintFromNumber(z);
//Console.WriteLine(" ");
//Console.WriteLine($"Leading Digit Distribution from {z} => 1");
////tree._distribution.printDistribution();
//tree.printdistributionFrom(z);
//Console.WriteLine(" ");


//int i = tree.findCommonAncestor(1360, 75).value;

//Console.WriteLine("Finding common ancestor between 75 and 1360");
//Console.WriteLine(i);

//int j = tree.findCommonAncestor(69, 1280).value;

//Console.WriteLine("Finding common ancestor between 69 and 1280");
//Console.WriteLine(j);

//int k = tree.findCommonAncestor(11, 21).value;

//Console.WriteLine("Finding common ancestor between 11 and 21");
//Console.WriteLine(k);

