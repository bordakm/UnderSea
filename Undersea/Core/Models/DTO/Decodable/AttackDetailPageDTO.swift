//
//  AttackDetailPageDTO.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 22..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

struct AttackDetailPageDTO : Decodable {
        
    let id: Int
    let name: String
    let availableCount: Int
    let imageUrl: String
    
}
