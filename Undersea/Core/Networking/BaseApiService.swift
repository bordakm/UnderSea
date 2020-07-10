//
//  BaseApiService.swift
//  CleanTemplate
//
//  Created by Horti Tamás on 2020. 06. 30..
//  Copyright © 2020. Horti Tamás. All rights reserved.
//

import Foundation
import Moya

protocol BaseApiService: TargetType {
 
    var parameters: [String : Any] { get }
    var parameterEncoding: ParameterEncoding { get }
    
}

extension BaseApiService {
    
    var baseURL: URL {
        return ServerProxy.Constants.baseUrl
    }
    
    var headers: [String : String]? {
        var buffer: [String : String] = [:]
        buffer["Content-Type"] = "application/json"
        buffer["Accept"] = "application/json"
        
        return buffer
    }
    
    var parameterEncoding: ParameterEncoding {
        switch self.method {
        case .get,
             .delete:
            return URLEncoding.default
        default:
            return JSONEncoding.default
        }
    }
    
    var task: Task {
        return .requestParameters(parameters: parameters, encoding: parameterEncoding)
    }
    
    var sampleData: Data {
        return Data()
    }
    
}
