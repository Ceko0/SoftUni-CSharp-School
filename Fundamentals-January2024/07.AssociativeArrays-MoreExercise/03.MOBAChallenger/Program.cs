using System.Text;

namespace _03.MOBAChallenger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> playerInfo = new Dictionary<string, Dictionary<string, int>>();
            string income = "";

            while ((income = Console.ReadLine()) != "Season end")
            {
                if (income.Contains("->"))
                {
                    string[] incomeInformation = income
                        .Split("->", StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x .Trim())
                        .ToArray();
                    string name = incomeInformation[0];
                    string skill = incomeInformation[1];
                    int skillPoints = int.Parse(incomeInformation[2]);

                    if (playerInfo.ContainsKey(name))
                    {
                        if (playerInfo[name].ContainsKey(skill))
                        {
                            foreach (var (playerSkill , playerSkillPoints) in playerInfo[name])
                            {
                                if (playerSkillPoints < skillPoints)
                                {
                                    playerInfo[name][playerSkill] = skillPoints;
                                }
                            }
                        }
                        else
                        {
                            playerInfo[name].Add(skill , skillPoints);
                        }
                    }
                    else
                    {
                        playerInfo.Add(name,new Dictionary<string, int>());
                        playerInfo[name].Add(skill, skillPoints);
                    }

                }
                else
                {
                    string[] incomeInformation = income
                        .Split("vs", StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Trim())
                        .ToArray();
                    string firstPlayer = incomeInformation[0];
                    string secondPlayer = incomeInformation[1];
                    string playerToRemove = "";
                    if (playerInfo.ContainsKey(firstPlayer) && playerInfo.ContainsKey(secondPlayer))
                    {
                        foreach (var (skill , skillPoints) in playerInfo[firstPlayer])
                        {
                            foreach (var (secondSkill , secondSkillPoints) in playerInfo[secondPlayer])
                            {
                                if (skill == secondSkill)
                                {
                                    if (skillPoints == secondSkillPoints)
                                    {
                                        continue;
                                    }
                                    else if (skillPoints < secondSkillPoints)
                                    {
                                        playerToRemove = firstPlayer;
                                    }
                                    else
                                    {
                                        playerToRemove =secondPlayer;
                                    }
                                }
                            }
                        }

                        playerInfo.Remove(playerToRemove);
                    }
                    
                }
            }
           
            foreach (var (playerName , skillInformation) in playerInfo.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine($"{playerName}: {skillInformation.Values.Sum()} skill");
                foreach (var (skill , skillPoints) in skillInformation.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"- {skill} <::> {skillPoints}");
                }
            }
        }
    }
}
