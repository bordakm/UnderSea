//
//  BuildingsDTO.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 23..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

struct BuildingDTO : Decodable {
    
    let id: Int
    let name: String
    let description: String
    let count: Int
    let price: Int
    let imageUrl: String
    let remainingRounds: Int
    
}
