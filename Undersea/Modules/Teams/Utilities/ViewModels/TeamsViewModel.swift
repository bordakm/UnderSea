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
        private(set) var alertMessage: String?
        
        func set(teams: [TeamModel]) {
            alertMessage = nil
            self.teams = teams
            objectWillChange.send()
        }
        
        func set(alertMessage: String) {
            //mainPageModel = nil
            self.alertMessage = alertMessage
            objectWillChange.send()
        }
        
    }
    
}
