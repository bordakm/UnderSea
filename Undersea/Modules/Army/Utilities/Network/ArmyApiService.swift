//
//  ArmyApiService.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 28..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Moya

extension Army {
    
    enum ApiService {
        case getArmy
        case buyUnits(_ data: [BuyUnitsDTO])
    }
    
}

extension Army.ApiService: BaseApiService {
    
    var path: String {
        switch self {
        case .getArmy,
             .buyUnits:
            return "/Units"
        }
    }
    
    var method: Moya.Method {
        switch self {
        case .getArmy:
            return .get
        case .buyUnits:
            return .post
        }
    }
    
    var task: Task {
        switch self {
        case .buyUnits(let data):
            return .requestJSONEncodable(data)
        default:
            return .requestParameters(parameters: parameters, encoding: parameterEncoding)
        }
    }
    
    var parameters: [String : Any] {
        switch self {
        case .getArmy,
             .buyUnits:
            return [:]
        }
    }
    
}
