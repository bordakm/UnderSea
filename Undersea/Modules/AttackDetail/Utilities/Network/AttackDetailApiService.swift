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
    }
    
}

extension AttackDetail.ApiService: BaseApiService {
    
    var path: String {
        switch self {
        case .getUnits:
            return "/Attacks/getunits"
        }
    }
    
    var method: Moya.Method {
        switch self {
        case .getUnits:
            return .get
        }
    }
    
    var parameters: [String : Any] {
        switch self {
        case .getUnits:
            return [:]
        }
    }
    
}

