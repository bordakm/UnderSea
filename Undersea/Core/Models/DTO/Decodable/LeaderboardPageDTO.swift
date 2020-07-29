//
//  LeaderboardDTO.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 21..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

struct LeaderboardPageDTO: Decodable, DTOProtocol {
    
    let id: Int
    let userName: String
    let place: Int
    let score: Int
    
}
