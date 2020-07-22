//
//  TeamsApiService.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 22..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Moya

extension Teams {
    
    enum ApiService {
        case getTeams
    }
    
}

extension Teams.ApiService: BaseApiService {
    
    var path: String {
        switch self {
        case .getTeams:
            return "/Attacks/getoutgoing"
        }
    }
    
    var method: Moya.Method {
        switch self {
        case .getTeams:
            return .get
        }
    }
    
    var parameters: [String : Any] {
        switch self {
        case .getTeams:
            return [:]
        }
    }
    
}
