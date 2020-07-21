//
//  LeaderboardUsecases.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 21..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

extension Leaderboard {
    
    enum Usecase {
        case load
        case loadMore(_ userName: String)
        case search(_ userName: String)
    }
    
}
