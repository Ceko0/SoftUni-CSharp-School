int numberOne = int.Parse(Console.ReadLine());
int numberTwo = int.Parse(Console.ReadLine());
int numberThree = int.Parse(Console.ReadLine());

int bigest = 0;
int average = 0;
int smaller = 0;

if ( numberOne >= numberTwo && numberOne >= numberThree) bigest = numberOne;
else if ( numberTwo >= numberThree && numberTwo >= numberOne ) bigest = numberTwo;
else bigest = numberThree;

if (numberOne <= numberTwo && numberOne <= numberThree) smaller = numberOne;
else if (numberTwo <= numberThree && numberTwo <= numberOne) smaller = numberTwo;
else smaller = numberThree;

if (numberOne <= numberTwo && numberOne >= numberThree || numberOne >= numberTwo && numberOne <= numberThree) average = numberOne;
else if (numberTwo <= numberThree && numberTwo >= numberOne || numberTwo >= numberThree && numberTwo <= numberOne) average = numberTwo;
else average = numberThree;

Console.WriteLine(bigest);
Console.WriteLine(average);
Console.WriteLine(smaller);