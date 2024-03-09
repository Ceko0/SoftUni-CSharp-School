namespace _04.Snowwhite
{
    class dwarf
    {
        public dwarf(string name, string color, int physic)
        {
            Name = name;
            Color = color;
            Physic = physic;
        }

        public string Name { get; set; }
        public string Color { get; set; }
        public int Physic { get; set; }
        public override string ToString()
        {
            return $"({Color}) {Name} <-> {Physic}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<dwarf> dwarfList = new List<dwarf>();

            string income;
            while ((income = Console.ReadLine()) != "Once upon a time")
            {
                string[] information = income
                    .Split("<:>")
                    .Select(x => x.Trim())
                    .ToArray();

                string name = information[0];
                string color = information[1];
                int physic = int.Parse(information[2]);

                dwarf newDwarf = new dwarf(name , color , physic);

                dwarf currentDwarf = dwarfList.FirstOrDefault(d => d.Name == name);

                if (currentDwarf != null)
                {
                    if (currentDwarf.Color != color)
                    {
                        dwarfList.Add(newDwarf);
                    }
                    else
                    {
                        if (currentDwarf.Physic < physic)
                        {
                            currentDwarf.Physic = physic;
                        }
                    }
                }
                else
                {
                    dwarfList.Add(newDwarf);
                }
            }
            
            foreach (var dwarf in dwarfList.OrderByDescending(d => d.Physic)
                         .ThenByDescending(d => dwarfList.Count(x => x.Color == d.Color)))
            {
                Console.WriteLine(dwarf);
            }

        }
    }
}
