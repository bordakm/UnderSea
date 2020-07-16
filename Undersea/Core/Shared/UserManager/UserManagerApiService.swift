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
        case renew(_ data: RenewDTO)
    }
    
}

extension UserManager.ApiService: BaseApiService {
    
    var path: String {
        switch self {
        case .login:
            return "/Auth/login"
        case .register:
            return "/Auth/register"
        case .logout:
            return "/Auth/logout"
        case .renew:
            return "/Auth/renew"
        }
    }
    
    var method: Moya.Method {
        switch self {
        case .login,
             .register,
             .logout,
             .renew:
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
        case .renew(let data):
            return data.getDictionary()
        }
    }
    
}
