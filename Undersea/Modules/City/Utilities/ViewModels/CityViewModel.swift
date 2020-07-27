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
        private(set) var alertMessage: String?
        
        func set(viewModel: CityPageViewModel) {
            alertMessage = nil
            cityPageViewModel = viewModel
            objectWillChange.send()
        }
        
        func set(buildings: [CityPageViewModel.Building]) {
            alertMessage = nil
            cityPageViewModel.buildings = buildings
            objectWillChange.send()
        }
        
        func setRemaining(id: Int, remaining: Int) {
            alertMessage = nil
            if let index = cityPageViewModel.buildings?.firstIndex(where: { (building) -> Bool in
                return building.id == id
            }) {
                cityPageViewModel.buildings?[index].remainingRounds = remaining
            }
            objectWillChange.send()
        }
        
        func set(units: [CityPageViewModel.Unit]) {
            alertMessage = nil
            cityPageViewModel.units = units
            objectWillChange.send()
        }
        
        func set(id: Int, count: Int) {
            
            if let index = cityPageViewModel.units?.firstIndex(where: { (unit) -> Bool in
                return unit.id == id
            }) {
                alertMessage = nil
                cityPageViewModel.units?[index].selectedAmount = count
                objectWillChange.send()
            }
            
        }
        
        func set(alertMessage: String) {
            //mainPageModel = nil
            self.alertMessage = alertMessage
            objectWillChange.send()
        }
        
    }
    
}
