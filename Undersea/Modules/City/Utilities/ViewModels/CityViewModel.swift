//
//  CityViewModel.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 23..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

extension City {
    
    class ViewModel: ObservableObject {
        
        @Published var isLoading = false
        private(set) var cityPageViewModel: CityPageViewModel = CityPageViewModel()
        @Published var errorModel: ErrorAlertModel = ErrorAlertModel(message: "Unknown error", show: false)
        
        func set(viewModel: CityPageViewModel) {
            cityPageViewModel = viewModel
            objectWillChange.send()
        }
        
        func set(buildings: [CityPageViewModel.Building]) {
            cityPageViewModel.buildings = buildings
            objectWillChange.send()
        }
        
        func setRemainingBuildTime(id: Int, remaining: Int) {
            
            if let index = cityPageViewModel.buildings?.firstIndex(where: { (building) -> Bool in
                return building.id == id
            }) {
                cityPageViewModel.buildings?[index].remainingRounds = remaining
            }
            objectWillChange.send()
            
        }
        
        func set(upgrades: [CityPageViewModel.Upgrade]) {
            cityPageViewModel.upgrades = upgrades
            objectWillChange.send()
        }
        
        func setRemainingUpgradeTime(id: Int, remaining: Int) {
            
            if let index = cityPageViewModel.upgrades?.firstIndex(where: { (upgrade) -> Bool in
                return upgrade.id == id
            }) {
                cityPageViewModel.upgrades?[index].remainingRounds = remaining
            }
            objectWillChange.send()
            
        }
        
        func set(units: [CityPageViewModel.Unit]) {
            cityPageViewModel.units = units
            objectWillChange.send()
        }
        
        /*func set(alertMessage: String) {
            self.alertMessage = alertMessage
            objectWillChange.send()
        }*/
        
    }
    
}
