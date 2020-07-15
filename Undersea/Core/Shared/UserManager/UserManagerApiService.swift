//
//  UserManagerApiService.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 15..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Moya

extension UserManager {
    
    enum ApiService {
        case login(_ data: LoginDTO)
        case register(_ data: RegisterDTO)
        case logout
    }
    
}

extension UserManager.ApiService: BaseApiService {
    
    var path: String {
        switch self {
        case .login:
            return "/Login"
        case .register:
            return "/Register"
        case .logout:
            return "/Logout"
        }
    }
    
    var method: Moya.Method {
        switch self {
        case .login,
             .register,
             .logout:
            return .post
        }
    }
    
    var parameters: [String : Any] {
        switch self {
        case .login(let data):
            return data.getDictionary()
        case .register(let data):
            return data.getDictionary()
        case .logout:
            return [:]
        }
    }
    
}
