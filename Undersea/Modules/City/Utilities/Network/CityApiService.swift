//
//  CityApiService.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 23..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Moya

extension City {
    
    enum ApiService {
        case getBuildings
        case buyBuilding(_ data: BuyBuildingDTO)
        case getArmy
        case buyUnits(_ data: [BuyUnitsDTO])
    }
    
}

extension City.ApiService: BaseApiService {
    
    var path: String {
        switch self {
        case .getBuildings:
            return "/Buildings"
        case .buyBuilding:
            return "/Buildings/purchase"
        case .getArmy,
             .buyUnits:
            return "/Units"
        }
    }
    
    var method: Moya.Method {
        switch self {
        case .getBuildings:
            return .get
        case .buyBuilding:
            return .post
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
        case .getBuildings,
             .getArmy,
             .buyUnits:
            return [:]
        case .buyBuilding(let data):
            return data.getDictionary()
        /*case .buyUnits(let data):
            return data.encodeArray(withKey: nil)*/
        }
    }
    
}
