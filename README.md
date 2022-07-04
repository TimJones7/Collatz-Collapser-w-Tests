<img src="https://i.imgur.com/eVa5MPX.png" width="500" height="400" />

# Collatz Collapser 
> This is the functionality behind the Collatz Collapser Minimal API... with x-unit testing using FluentAssertions

Collatz Collapser is a small console app for calculating the paths that numbers take en route to the eventual ```1-4-2``` pattern proposted by Lothar Collatz in 1937, as well as various other statistics.
#

> ###### The following is from Wikipedia
>## Statement of the problem
>
>Consider the following operation on an arbitrary [positive integer][]:
>
>-   If the number is even, halve it (ie. divide by two)
>-   If the number is odd, triple it and add one.
>
>In [modular arithmetic][] notation, define the [function][] as follows:
>$f(n) = \\begin{cases} \\frac{n}{2} &\\text{if } n \\equiv 0 \\pmod{2}\\\\\[4px\] 3n+1 & \\text{if } n\\equiv 1 \\pmod{2} .\\end{cases}$
>
>Now form a sequence by performing this operation repeatedly, beginning
>with any positive integer, and taking the result at each step as the
>input at the next.
>
>In notation:
>$a_i = \\begin{cases}n & \\text{for } i = 0 \\\\ f(a\_{i-1}) & \\text{for } i \> 0 \\end{cases}$
>(that is: is the value of applied to recursively times; *f*(*n*)}}).
>
>The Collatz conjecture is: *This process will eventually reach the
>number 1, regardless of which positive integer is chosen initially.*
>
>  [positive integer]: positive_integer "wikilink"
>  [modular arithmetic]: modular_arithmetic "wikilink"
>  [function]: function_(mathematics) "wikilink"
>




## Developing

If you would like to start contributing to this library, please use the following commands to download the repository to your machine. Please look inside of the folder named ```/Collatz``` for the solution file to open with Visual Studio. 

```shell
git clone https://github.com/TimJones7/Collatz-Collapser-w-Tests.git
```

## Features

Current features
* Print Collatz Chain 
* Find Least Common Ancestor of Two numbers
* Print Leading Digit Distribution on Collatz path
<img src="https://i.imgur.com/gA5WDYy.png" width="500" height="400" />
* Uncle Bob approved short methods with meaningful names that do one thing
<img src="https://i.imgur.com/RGtF1PJ.png" width="500" height="400" />



## Thanks

Thanks for stopping by. Check out my portfolio at https://www.TimothyJones.Dev/

Check out my Geo-Locational based Blog Social Media website:
https://www.LoklYokl.com/

- www.github.com/TimJones7



## Licensing
The code in this project is licensed under:
``` 
MIT License 
Copyright (c) 2022 Tim Jones.  
```
