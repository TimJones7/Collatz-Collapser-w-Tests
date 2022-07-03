
using Microsoft.Extensions.DependencyInjection;
using Collatz.Services;
using Collatz.Interfaces;

Console.WriteLine("Collatz Collapser!");
Console.WriteLine(" ");

//  AddScoped => create whats need only when calling it.
//  AddSingleton => object which exists for the life of the program
//  AddTransient => new (different) object on each request

var serviceProvider = new ServiceCollection()
    .AddScoped<ICollatzService, CollatzService>()
    .BuildServiceProvider();


//  Access service
var collatz = serviceProvider.GetRequiredService<ICollatzService>();

//  Test Service Functions:
collatz.Print_Collatz_Chain_From_Number(10);
int x = collatz.Find_Least_Common_Ancestor(16, 5).value;
Console.WriteLine("The Least Common ancestor of 16 and 5 is: " + x);
Console.WriteLine("The Leading Digit Distribution on path starting at 101:");
collatz.Print_Leading_Digit_Distribution_From(101);

