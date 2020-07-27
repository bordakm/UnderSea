//
//  CityPageViewModel.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 23..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import CocoaLumberjack

extension City {
    
    struct CityPageViewModel {
        
        var buildings: [Building]?
        var upgrades: [Upgrade]?
        var units: [Unit]?
        
    }
    
}

extension City.CityPageViewModel {
    
    struct Building : Identifiable {
        
        let id: Int
        let name: String
        let description: String
        var count: Int
        let price: Int
        var remainingRounds: Int
        var imageName: String
        
    }
    
    struct Upgrade : Identifiable {
        let id: Int
        let name: String
        let description: String
        var isPurchased: Bool
        var remainingRounds: Int
        var imageName: String
    }
    
    struct Unit : Identifiable {
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
