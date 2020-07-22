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
        case load(_ userName: String)
        case loadMore(_ userName: String)
    }
    
}
