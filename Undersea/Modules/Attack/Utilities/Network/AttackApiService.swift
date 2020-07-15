//
//  MainApiService.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 15..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Moya

extension Attack {
    
    enum ApiService {
        case getAttack
    }
    
}

extension Attack.ApiService: BaseApiService {
    
    var path: String {
        switch self {
        case .getAttack:
            return "/AttackPage"
        }
    }
    
    var method: Moya.Method {
        switch self {
        case .getAttack:
            return .get
        }
    }
    
    var parameters: [String : Any] {
        switch self {
        case .getAttack:
            return [:]
        }
    }
}
