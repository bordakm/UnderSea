//
//  UserDTO.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 15..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

struct UserDTO: Decodable {
    
    let refreshToken: String
    let accessToken: String
    
}
