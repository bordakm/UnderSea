//
//  ServerProxy.swift
//  CleanTemplate
//
//  Created by Horti Tamás on 2020. 06. 29..
//  Copyright © 2020. Horti Tamás. All rights reserved.
//

import Foundation
import Moya

class ServerProxy {
    
    // MARK: - Shared Instance
    
    static let shared: ServerProxy = ServerProxy()
    
    private init() { }
    
    // MARK: - Constants
    
    struct Constants {
        static let baseUrl: URL = URL(string: "http://underseaapit2.webtest.encosoft.internal/api")!
    }
    
    // MARK: - Functions
    
    static func getProvider<Target: TargetType>() -> MoyaProvider<Target> {
        let config = NetworkLoggerPlugin.Configuration(logOptions: .verbose)
        let plugins = [NetworkLoggerPlugin(configuration: config)]
        return MoyaProvider<Target>(plugins: plugins)
    }
    
}
