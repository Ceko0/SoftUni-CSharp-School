double racketPrice = double.Parse(Console.ReadLine());
int racket =  int.Parse(Console.ReadLine());
int sneakers = int.Parse(Console.ReadLine());


double totalRacket = racketPrice * racket;
double totalSneakers = sneakers * (racketPrice * 1/6);
double other = (totalRacket + totalSneakers) * 0.20;

double totalprice = totalRacket + totalSneakers + other;

double DjokovicMoney = totalprice * 1/8;
double sponsorMoney = totalprice * 7 / 8;
Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(DjokovicMoney)}");
Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(sponsorMoney)}");