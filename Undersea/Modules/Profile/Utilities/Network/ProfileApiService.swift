//
//  ProfileApiService.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 21..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Moya

extension Profile {
    
    enum ApiService {
        case getProfile
    }
    
}

extension Profile.ApiService: BaseApiService {
    
    var baseURL: URL {
        return URL(string: "http://underseat2lasttry.webtest.encosoft.internal")!
    }
    
    var path: String {
        switch self {
        case .getProfile:
            return "/profile"
        }
    }
    
    var method: Moya.Method {
        switch self {
        case .getProfile:
            return .get
        }
    }
    
    var parameters: [String : Any] {
        switch self {
        case .getProfile:
            return [:]
        }
    }
    
}
