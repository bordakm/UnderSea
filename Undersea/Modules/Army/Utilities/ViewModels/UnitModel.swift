//
//  UnitModel.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 28..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

extension Army {
    
    struct UnitModel : Identifiable {
        let id: Int
        let name: String
        var count: Int
        let attackScore: Int
        let defenseScore: Int
        let pearlCostPerTurn: Int
        let coralCostPerTurn: Int
        let price: Int
        var imageURL: URL
        let selectedAmount: Int
    }
    
}
