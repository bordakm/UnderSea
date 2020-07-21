using System.ComponentModel.DataAnnotations.Schema;

namespace UnderSea.DAL.Models.Buildings
{
    public class Building
    {
        public int Id { get; set; }
        [ForeignKey("BuildingGroup")]
        public int BuildingGroupId { get; set; }
        [ForeignKey("BuildingType")]
        public int TypeId { get; set; }
        public virtual BuildingType Type { get; set; }
        public int Count { get; set; }
        public int UnderConstructionCount { get; set; }
        public int ConstructionTimeLeft { get; set; }
        [NotMapped]
        public int CoralBonusTotal => Type.CoralBonus * (Count - UnderConstructionCount);
    }
}
