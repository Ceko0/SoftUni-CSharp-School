using MilitaryElite.Interfaces.SoldierInterfece.PrivateInterfeceInterfece;
using System.Text;

namespace MilitaryElite.Models.SoldierTree.PrivateTree
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            privates = new();
        }
        public readonly List<Private> privates;

        public IReadOnlyCollection<Private> Privates => privates.AsReadOnly();

        public void AddPrivate(Private priv)
        {
            privates.Add(priv);
        }
        public override string ToString()
        {
            StringBuilder sb = new ();
            sb.AppendLine(base.ToString());
            sb.Append("Privates:");

            foreach (Private @private in this.Privates)
            {
                sb.AppendLine();
                sb.Append("  ");
                sb.Append(@private);
            }

            return sb.ToString();
        }
    }
}
