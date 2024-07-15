namespace MilitaryElite.Models.SoldierTree.PrivateTree.SpecialisedSoldierTree.SetForSpecialistTree 
{ 
    public class Repair
    {
        public Repair(string partName, int workedHours)
        {
            if(string.IsNullOrWhiteSpace(partName)) throw new ArgumentException(nameof(partName));
            if (workedHours <= 0) throw new ArgumentException("hours can`t be negative");
            PartName = partName;
            WorkedHours = workedHours;
        }

        public string PartName { get; }
        public int WorkedHours { get; }
        public override string ToString() => $"Part Name: {this.PartName} Hours Worked: {this.WorkedHours}";
    }
}
