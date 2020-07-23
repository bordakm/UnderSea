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
        
        let units: [Unit]
        let buildings: [Building]
        
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
    
    //New
    struct Unit: Decodable {
        
        let id: Int
        let name: String
        let availableCount: Int
        let allCount: Int
        let imageUrl: String
        
    }
    
    struct Building: Decodable {
        
        let typeId: Int
        let imageUrl: String
        let name: String
        let count: Int
        let underConstructionCount: Int
        
    }
    
    //Old
    struct ResourcesDTO: Decodable {
        
        let pearlCount: Int
        let pearlProductionCount: Int
        let pearlPictureUrl: String
        let coralCount: Int
        let coralProductionCount: Int
        let coralPictureUrl: String
        
    }
    
}
