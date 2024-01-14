    double sum = double.Parse(Console.ReadLine());
    int time = int.Parse(Console.ReadLine());
    double procent =  double.Parse(Console.ReadLine());
    double mount = (sum * procent / 100) / 12;
    Console.WriteLine(sum + time*mount);