//
//  LeaderboardApiService.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 21..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Moya

extension Leaderboard {
    
    enum ApiService {
        case getLeaderboard(_ userName: String?, page: Int)
    }
    
}

extension Leaderboard.ApiService: BaseApiService {
    
    var path: String {
        switch self {
        case .getLeaderboard:
            return "/Scoreboard"
        }
    }
    
    var method: Moya.Method {
        switch self {
        case .getLeaderboard:
            return .get
        }
    }
    
    var parameters: [String : Any] {
        switch self {
        case .getLeaderboard(let userName, let page):
            
            if let userName = userName?.trimmingCharacters(in: .whitespacesAndNewlines), !userName.isEmpty {
                return ["SearchPhrase": userName, "Page": page, "ItemPerPage": 15]
            } else {
                return ["Page": page, "ItemPerPage": 15]
            }
            
        }
    }
    
}
