//
//  UnitDTO.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 24..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

struct UnitDTO : Decodable, DTOProtocol {
    
    let id: Int
    let name: String
    var count: Int
    let attackScore: Int
    let defenseScore: Int
    let pearlCostPerTurn: Int
    let coralCostPerTurn: Int
    let price: Int
    let imageUrl: String
    
}
