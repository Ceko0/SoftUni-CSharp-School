string income = Console.ReadLine();


int one = income[0] - '0';
int two = income[1] - '0';
int three = income[2] - '0';
for (int i = 1; i <= three ; i++)
{
	for (int j = 1; j <= two; j++)
	{
		for (int k = 1; k <= one; k++)
		{
            Console.WriteLine($"{i} * {j} * {k} = {i * j * k};");
        }
	}
}

