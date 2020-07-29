//
//  MainPageViewModel.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 13..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import CocoaLumberjack

extension Main {

    struct MainPageViewModel {
        
        var roundAndRank: String
        var statList: [StatusBarItem]
        var builtStructures: Set<StructureType>
        
    }

}

extension Main.MainPageViewModel {
    
    init?(data: DTOProtocol) {
        
        if let dataModel = data as? MainPageDTO {
            
            let dtoStatBar = dataModel.statusBar
            
            let resources = dtoStatBar.resources
            
            var statList: [StatusBarItem] = []
            
            for unit in dtoStatBar.units {
                switch unit.id {
                case 1:
                    statList.append(.shark(unit.availableCount, unit.allCount))
                case 2:
                    statList.append(.seal(unit.availableCount, unit.allCount))
                case 3:
                    statList.append(.seahorse(unit.availableCount, unit.allCount))
                default:
                    DDLogDebug("Unknown unit id \(unit.id)")
                }
            }
            
            statList.append(.pearl(resources.pearlCount, resources.pearlProductionCount))
            statList.append(.coral(resources.coralCount, resources.coralProductionCount))
            
            for building in dtoStatBar.buildings {
                switch building.typeId {
                case 1:
                    statList.append(.reefcastle(building.count))
                case 2:
                    statList.append(.flowRegulator(building.count))
                default:
                    DDLogDebug("Unknown building id \(building.typeId)")
                }
            }
            
            var builtStructures: Set<StructureType> = Set<StructureType>()
            
            if dataModel.structures.reefCastle {
                builtStructures.insert(.reefcastle)
            }
            
            if dataModel.structures.flowManager {
                builtStructures.insert(.flowRegulator)
            }
            
            if dataModel.structures.alchemy {
                builtStructures.insert(.alchemy)
            }
            
            if dataModel.structures.sonarCannon {
                builtStructures.insert(.sonarCannon)
            }
            
            let roundAndRank = "\(dtoStatBar.roundCount). kör\t\(dtoStatBar.scoreboardPosition). hely"
            
            self.init(roundAndRank: roundAndRank, statList: statList, builtStructures: builtStructures)
            
        } else {
            return nil
        }
        
    }
    
}
