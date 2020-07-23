//
//  AttackDetailApiService.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 22..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Moya

extension AttackDetail {
    
    enum ApiService {
        case getUnits
        case attack(_ data: SendAttackDTO)
    }
    
}

extension AttackDetail.ApiService: BaseApiService {
    
    var path: String {
        switch self {
        case .getUnits:
            return "/Attacks/getunits"
        case .attack:
            return "/Attacks/send"
        }
    }
    
    var method: Moya.Method {
        switch self {
        case .getUnits:
            return .get
        case .attack:
            return .post
        }
    }
    
    var parameters: [String : Any] {
        switch self {
        case .getUnits:
            return [:]
        case .attack(let data):
            return data.getDictionary()
        }
    }
    
}

