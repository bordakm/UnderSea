//
//  BuyUnitsDTO.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 24..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

struct BuyUnitsDTO : Encodable, Decodable, DTOProtocol {
    
    let typeId: Int
    var count: Int
    
}
