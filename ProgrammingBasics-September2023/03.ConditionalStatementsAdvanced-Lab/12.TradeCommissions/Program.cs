string city = Console.ReadLine();
double sales = double.Parse(Console.ReadLine());

//Град    0 ≤ s ≤ 500	500 < s ≤ 1 000	1 000 < s ≤ 10 000	s > 10 000
//Sofia     	5%	              7%	        8%	           12%
//Varna        	4.5%	        7.5%	        10%         	13%
//Plovdiv	    5.5%	        8%           	12%	           14.5%

if (city == "Sofia")
{
    if (sales < 0) { Console.WriteLine("error"); }
    else if (sales >= 0 && sales <= 500) { Console.WriteLine($"{sales * 0.05:f2}"); }
    else if (sales <= 1000) { Console.WriteLine($"{sales * 0.07:f2}"); }
    else if (sales <= 10000) { Console.WriteLine($"{sales * 0.08:f2}"); }
    else if (sales > 10000) { Console.WriteLine($"{sales * 0.12:f2}"); }
}
else if (city == "Varna")
{
    if (sales < 0) { Console.WriteLine("error"); }
    else if (sales >= 0 && sales <= 500) { Console.WriteLine($"{sales * 0.045:f2}"); }
    else if (sales <= 1000) { Console.WriteLine($"{sales * 0.075:f2}"); }
    else if (sales <= 10000) { Console.WriteLine($"{sales * 0.10:f2}"); }
    else if (sales > 10000) { Console.WriteLine($"{sales * 0.13:f2}"); }
}
else if (city == "Plovdiv")
{
    if (sales < 0) { Console.WriteLine("error"); }
    else if (sales >= 0 && sales <= 500) { Console.WriteLine($"{sales * 0.055:f2}"); }
    else if (sales <= 1000) { Console.WriteLine($"{sales * 0.08:f2}"); }
    else if (sales <= 10000) { Console.WriteLine($"{sales * 0.12:f2}"); }
    else if (sales > 10000) { Console.WriteLine($"{sales * 0.145:f2}"); }
    
}
else { Console.WriteLine("error"); }