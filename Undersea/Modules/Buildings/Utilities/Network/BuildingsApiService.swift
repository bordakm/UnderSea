//
//  BuildingsApiService.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 24..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Moya

extension Buildings {
    
    enum ApiService {
        case getBuildings
        case buyBuilding(_ data: BuyBuildingDTO)
    }
    
}

extension Buildings.ApiService: BaseApiService {
    
    var path: String {
        switch self {
        case .getBuildings:
            return "/Buildings"
        case .buyBuilding:
            return "/Buildings/purchase"
        }
    }
    
    var method: Moya.Method {
        switch self {
        case .getBuildings:
            return .get
        case .buyBuilding:
            return .post
        }
    }
    
    var parameters: [String : Any] {
        switch self {
        case .getBuildings:
            return [:]
        case .buyBuilding(let data):
            return data.getDictionary()
        }
    }
    
}
