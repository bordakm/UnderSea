//
//  LeaderboardPageViewModel.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 21..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

extension Leaderboard {

    struct UserViewModel: Identifiable, Equatable {
            
        let id: Int
        let place: Int
        let userName: String
        let score: Int
        
    }

}

extension Leaderboard.UserViewModel {
    
    init?(data: DTOProtocol) {
        
        if let user = data as? LeaderboardPageDTO {
            
            self.init(id: user.id, place: user.place, userName: user.userName, score: user.score)
            
        } else {
            return nil
        }
        
    }
    
}
