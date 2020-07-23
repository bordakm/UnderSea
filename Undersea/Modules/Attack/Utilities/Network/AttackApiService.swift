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
        case getAttack(_ userName: String?, page: Int)
    }
    
}

extension Attack.ApiService: BaseApiService {
    
    var path: String {
        switch self {
        case .getAttack:
            return "/Attacks/searchtargets"
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
        case .getAttack(let userName, let page):
            
            if let userName = userName?.trimmingCharacters(in: .whitespacesAndNewlines), !userName.isEmpty {
                return ["SearchPhrase": userName, "Page": page, "ItemPerPage": 15]
            } else {
                return ["Page": page, "ItemPerPage": 15]
            }
            
        }
    }
}
