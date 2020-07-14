//
//  MainApiService.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 13..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Moya

extension Main {
    
    enum ApiService {
        case getMain
    }
    
}

extension Main.ApiService: BaseApiService {
    
    var path: String {
        switch self {
        case .getMain:
            return "/MainPage"
        }
    }
    
    var method: Moya.Method {
        switch self {
        case .getMain:
            return .get
        }
    }
    
    var parameters: [String : Any] {
        switch self {
        case .getMain:
            return [:]
        }
    }
    
}
