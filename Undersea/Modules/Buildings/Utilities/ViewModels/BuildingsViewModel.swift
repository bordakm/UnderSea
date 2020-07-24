//
//  BuildingsViewModel.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 24..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

extension Buildings {
    
    class ViewModel: ObservableObject {
        
        @Published var isLoading = false
        @Published private(set) var buildings: [Building] = []
        private(set) var alertMessage: String?
        
        func set(buildings: [Building]) {
            alertMessage = nil
            self.buildings = buildings
            objectWillChange.send()
        }
        
        func setRemaining(buildingId: Int, remaining: Int) {
            objectWillChange.send()
            //cityPageViewModel.objectWillChange.send()
            alertMessage = nil
            buildings[buildingId].remainingRounds = remaining
        }
        
        func set(alertMessage: String) {
            //mainPageModel = nil
            self.alertMessage = alertMessage
            objectWillChange.send()
        }
        
    }
    
}
