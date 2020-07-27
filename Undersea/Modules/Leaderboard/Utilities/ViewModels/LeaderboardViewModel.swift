//
//  LeaderboardViewModel.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 21..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

extension Leaderboard {
    
    class ViewModel: ObservableObject {
        
        @Published var isLoading = false
        @Published var isRefreshing = false
        private(set) var userList: [UserViewModel] = []
        @Published var errorModel: ErrorAlertModel = ErrorAlertModel(message: "Unknown error", show: false)
        
        func set(userList: [UserViewModel]) {
            self.userList = userList
            objectWillChange.send()
        }
        
    }
    
}
