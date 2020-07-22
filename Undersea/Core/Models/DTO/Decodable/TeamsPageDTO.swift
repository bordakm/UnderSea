//
//  TeamsPageDTO.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 22..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

struct TeamsPageDTO: Decodable {
    
    let countryName: String
    let units: [Unit]
    
}

extension TeamsPageDTO {
    
    struct Unit: Decodable {
        
        let count: Int
        let name: String
        
    }
    
}
