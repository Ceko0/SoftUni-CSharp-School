

string  first = Console.ReadLine();
string second = Console.ReadLine();
string  third = Console.ReadLine();
int won = 0;
int lost = 0;
int drawn = 0;

int firstGoal = first[0];
int firstGoalOthers = first[2];
int secondGoal = second[0];
int secondGoalOthers = second[2];
int thirdGoal = third[0];
int thirdGoalOthers = third[2];

if (firstGoal > firstGoalOthers) won++;
else if (firstGoal < firstGoalOthers) lost++;
else drawn++;
if (secondGoal > secondGoalOthers) won++;
else if (secondGoal < secondGoalOthers) lost++;
else drawn++;
if (thirdGoal > thirdGoalOthers) won++;
else if (thirdGoal < thirdGoalOthers) lost++;
else drawn++;

Console.WriteLine($"Team won {won} games.");
Console.WriteLine($"Team lost {lost} games.");
Console.WriteLine($" Drawn games: {drawn}");