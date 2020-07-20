//
//  TokenDTO.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 15..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import SwiftJWT

struct TokenDTO: Decodable {
    
    let refreshToken: String
    let accessToken: String
 
    let expirationDate: Date
    
    enum CodingKeys: String, CodingKey {
        
        case refreshToken
        case accessToken
        
    }
    
    init(from decoder: Decoder) throws {
        let values = try decoder.container(keyedBy: CodingKeys.self)
        refreshToken = try values.decode(String.self, forKey: .refreshToken)
        accessToken = try values.decode(String.self, forKey: .accessToken)
        
        let jwtToken: JWT<UnderseaClaim> = try JWT(jwtString: accessToken)
        expirationDate = jwtToken.claims.exp
        
    }
    
    init(_ refreshToken: String, _ accessToken: String) throws {
        self.refreshToken = refreshToken
        self.accessToken = accessToken
        let jwtToken: JWT<UnderseaClaim> = try JWT(jwtString: accessToken)
        expirationDate = jwtToken.claims.exp
    }
    
}
