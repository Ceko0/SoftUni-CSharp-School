
string season = Console.ReadLine();
double distance = double.Parse(Console.ReadLine());
//•	Първи ред – Сезон – текст "Spring", "Summer", "Autumn" или "Winter"
//•	Втори ред –  Километри на месец – реално число в интервала [10.00...20000.00]
double finalMoney = 0;

        if (distance <= 5000)
        {
             switch (season)
             {
                   case "Spring":
                   case "Autumn":
                      finalMoney = (distance *0.75 * 4) ;
                      finalMoney *= 0.90;
                   break;
                   case "Summer":
                      finalMoney = (distance * 0.90 * 4);
                      finalMoney *= 0.90;
                   break;
            

                   case "Winter":
                        finalMoney = (distance * 1.05 * 4);
                        finalMoney *= 0.90;
                   break;
             }
        }
        else if (distance <= 10000)
        {
            switch (season)
            {
                 case "Spring":
                 case "Autumn":
                    finalMoney = (distance * 0.95 * 4);
                    finalMoney *= 0.90;
                 break;
                 case "Summer":
                    finalMoney = (distance * 1.10 * 4);
                    finalMoney *= 0.90;
                 break;
                 case "Winter":
                    finalMoney = (distance * 1.25 * 4);
                    finalMoney *= 0.90;
                 break;
            }
        }
        else if (distance <= 20000)
        {
            finalMoney = (distance * 1.45 * 4);
            finalMoney *= 0.90;
        }

Console.WriteLine($"{finalMoney:f2}");