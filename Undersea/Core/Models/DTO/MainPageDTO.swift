//
//  MainPageDTO.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 13..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

struct MainPageDTO: Decodable {
    
      let statusBar: StatusBarDTO
      let countryName: String
      let structures: StructuresDTO
    
}

extension MainPageDTO {
    
    struct StatusBarDTO: Decodable {
        
        let combatSeaHorseCount: Int
        let laserSharkCount: Int
        let stromSealCount: Int
        let flowManagerCount: Int
        let reefCastleCount: Int
        let roundCount: Int
        let scoreboardPosition: Int
        let resources: ResourcesDTO
        
    }
    
    struct StructuresDTO: Decodable {
        
        let flowManager: Bool
        let reefCastle: Bool
        let mudTractor: Bool
        let mudHarvester: Bool
        let coralWall: Bool
        let sonarCannon: Bool
        let underwaterMartialArts: Bool
        let alchemy: Bool
        
    }
    
}

extension MainPageDTO.StatusBarDTO {
    
    struct ResourcesDTO: Decodable {
        
        let pearlCount: Int
        let pearlProductionCount: Int
        let coralCount: Int
        let coralProductionCount: Int
        
    }
    
}
