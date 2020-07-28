//
//  TeamsViewModel.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 22..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

extension Teams {
    
    class ViewModel: ObservableObject {
        
        @Published var isRefreshing = false
        private(set) var teams: [TeamModel] = []
        @Published var errorModel: ErrorAlertModel = ErrorAlertModel(message: "Unknown error", show: false)
        
        func set(teams: [TeamModel]) {
            self.teams = teams
            objectWillChange.send()
        }
        
    }
    
}
