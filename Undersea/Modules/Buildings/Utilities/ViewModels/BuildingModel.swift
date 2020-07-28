//
//  BuildingModel.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 28..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

extension Buildings {

    struct BuildingModel : Identifiable {
        
        let id: Int
        let name: String
        let description: String
        var count: Int
        let price: Int
        var remainingRounds: Int
        var imageName: String
        
    }

}
