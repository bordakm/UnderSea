//
//  LeaderboardApiWorker.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 21..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

extension Leaderboard {
 
    class ApiWorker: BaseApiWorker<ApiService> {
        
        func getLeaderboard(_ userName: String? = nil, page: Int? = 1) -> AnyPublisher<[LeaderboardPageDTO], Error> {
            return execute(target: .getLeaderboard(userName, page: page))
        }
        
    }

}
