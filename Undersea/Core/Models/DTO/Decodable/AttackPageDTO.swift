//
//  AttackPageDTO.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 15..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

struct AttackPageDTO: Decodable {
    
    let users: [User]
    
}

extension AttackPageDTO {
    
    struct User: Decodable {
        
        let id: Int
        let name: String
        
    }
    
}
