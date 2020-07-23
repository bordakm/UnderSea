//
//  SendAttackDTO.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 23..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

struct SendAttackDTO : Encodable {
    
    let defenderUserId: Int
    let attackingUnits: [Unit]
    
}

extension SendAttackDTO {
    
    struct Unit : Encodable {
        
        let id: Int
        var sendCount: Int
        
    }
    
}
