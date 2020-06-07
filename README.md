# pretiffier
My implementation of NumberPretiffier written in .netcore 3.1

The solution has 4 projects. One is Common, with all interface and model definitions. One is PrettifierService which is the implementation of interfaces defined in the Common project. Two sub-services are used, one is numberValidator, the other is numberPrettifier. The third project is prettifierApp which is a console application that allows user to input a number and get the result. I also wrote a test project, which has 3 test files, each of which tests specific interfaces/service.

It became more complicated than what I started with. I started with string input, but then when I read the requirement of numeric input, i overthought it, and started with various numeric types , hence the defined types inside of numberValidator. 

An alternative and simpler solution is to use string manipulation, something like string.Format to output desired string based on the range of input value.
