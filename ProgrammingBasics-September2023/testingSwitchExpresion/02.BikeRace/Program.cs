// "juniors"
// "seniors" 

//Група    trail	cross-country	downhill	road
//juniors	5.50        	8	      12.25      20
//seniors	7	          9.50	      13.75	     21.50

using System.Diagnostics;

int juniors = int.Parse(Console.ReadLine());
int seniors  = int.Parse(Console.ReadLine());
string trase =  Console.ReadLine();

double incomeMoney = 0;

incomeMoney = trase switch
{
  "trail"=> (juniors * 5.5 + seniors * 7) * 0.95,
  "cross-country" => (juniors * 8 + seniors * 9.50) * 0.95,
  "downhill" => (juniors * 12.25 + seniors * 13.75) * 0.95,
  "road" => (juniors * 20 + seniors * 21.50) * 0.95,  
};
if (trase == "cross-country" && (juniors + seniors) >= 50 )
{
    incomeMoney *= 0.75;
}
Console.WriteLine($"{incomeMoney :f2}");