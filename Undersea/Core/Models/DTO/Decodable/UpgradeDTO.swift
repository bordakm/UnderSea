//
//  UpgradeDTO.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 27..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

struct UpgradeDTO : Decodable {
    
    let id: Int
    let name: String
    let description: String
    let imageUrl: String
    let isPurchased: Bool
    let remainingRounds: Int
    
}
