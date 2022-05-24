// See https://aka.ms/new-console-template for more information
using Collatz.CollatzTree;

Console.WriteLine("Hello, Collatz!");

Console.WriteLine("Hello, Collatz!");
Console.WriteLine(" ");

CollatzTree tree = new CollatzTree();

//Console.WriteLine("Printing Tree 101:");
//tree.PrintFromNumber(101);
//Console.WriteLine(" ");

//disty.getTallyFromNum(tree, 101);
//Console.WriteLine($"Leading Digit Distribution from {101} => 1");
//disty.printDistribution();

int x = 10;
int y = 12;
int z = 13;

Console.WriteLine($"Printing Tree {x}:");
tree.PrintFromNumber(x);
Console.WriteLine(" ");

//tree._distribution.getTallyFromNum(tree, x);
Console.WriteLine($"Leading Digit Distribution from {x} => 1");
//tree._distribution.printDistribution();
tree.printdistributionFrom(x);
Console.WriteLine(" ");

Console.WriteLine($"Printing Tree {y}:");
tree.PrintFromNumber(y);
Console.WriteLine(" ");
Console.WriteLine($"Leading Digit Distribution from {y} => 1");
//tree._distribution.printDistribution();
tree.printdistributionFrom(y);
Console.WriteLine(" ");

Console.WriteLine($"Printing Tree {z}:");
tree.PrintFromNumber(z);
Console.WriteLine(" ");
Console.WriteLine($"Leading Digit Distribution from {z} => 1");
//tree._distribution.printDistribution();
tree.printdistributionFrom(z);
Console.WriteLine(" ");