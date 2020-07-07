using System;
using System.Collections.Generic;
using System.Text;
using UnderSeaModel.Models.Buildings;

namespace UnderSeaModel.Models
{
    public class BuildingGroup
    {
        public FlowManager FlowManager { get; set; } = new FlowManager();
        public ReefCastle ReefCastle { get; set; } = new ReefCastle();

        public BuildingState BuildingState { get; set; } 


    }
}
