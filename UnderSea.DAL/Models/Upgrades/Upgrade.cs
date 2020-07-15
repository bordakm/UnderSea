using System.ComponentModel.DataAnnotations.Schema;

namespace UnderSea.DAL.Models.Upgrades
{
    public class Upgrade
    {
        public int Id { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        [ForeignKey("UpgradeType")]
        public int TypeId { get; set; }
        public UpgradeType Type { get; set; }
        public UpgradeState State { get; set; } = UpgradeState.Unresearched;
    }
}
