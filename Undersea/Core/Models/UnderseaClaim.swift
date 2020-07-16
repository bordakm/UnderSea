//
//  UnderseaClaim.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 16..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import SwiftJWT

struct UnderseaClaim : Claims {
    
    let sub: String
    let exp: Date
    let iss: String
    
}
