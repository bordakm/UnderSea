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
        private(set) var userList: [UserViewModel] = []
        private(set) var alertMessage: String?
        
        func set(userList: [UserViewModel]) {
            alertMessage = nil
            self.userList = userList
            objectWillChange.send()
        }
        
        func set(alertMessage: String) {
            //mainPageModel = nil
            self.alertMessage = alertMessage
            objectWillChange.send()
        }
        
    }
    
}
