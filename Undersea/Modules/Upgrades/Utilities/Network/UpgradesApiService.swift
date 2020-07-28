//
//  UpgradesApiService.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 28..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Moya

extension Upgrades {
    
    enum ApiService {
        case getUpgrades
        case buyUpgrade(_ data: BuyUpgradeDTO)
    }
    
}

extension Upgrades.ApiService: BaseApiService {
    
    var path: String {
        switch self {
        case .getUpgrades:
            return "/Upgrades"
        case .buyUpgrade:
            return "/Upgrades/research"
        }
    }
    
    var method: Moya.Method {
        switch self {
        case .getUpgrades:
            return .get
        case .buyUpgrade:
            return .post
        }
    }
    
    var parameters: [String : Any] {
        switch self {
        case .getUpgrades:
            return [:]
        case .buyUpgrade(let data):
            return data.getDictionary()
        }
    }
    
}
