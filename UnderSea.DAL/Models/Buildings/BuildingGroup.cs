using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Buildings
{
    public class BuildingGroup
    {
        public int Id { get; set; }
        public FlowManager FlowManager { get; set; }
        public ReefCastle ReefCastle { get; set; }
        public BuildingState BuildingState { get; set; }
    }
}
