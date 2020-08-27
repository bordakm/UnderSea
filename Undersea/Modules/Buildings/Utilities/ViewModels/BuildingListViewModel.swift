//
//  BuildingListViewModel.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 28..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

extension Buildings {
    
    class ViewModel: ObservableObject {
        
        @Published var isLoading = PassthroughSubject<Bool, Never>()
        private(set) var buildingList: [BuildingModel] = []
        @Published var errorModel: ErrorAlertModel = ErrorAlertModel(message: "Unknown error", show: false)
        
        func set(buildingList: [BuildingModel]) {
            self.buildingList = buildingList
            objectWillChange.send()
        }
        
        func setRemainingBuildTime(id: Int, remaining: Int) {
            
            if let index = buildingList.firstIndex(where: { (building) -> Bool in
                return building.id == id
            }) {
                buildingList[index].remainingRounds = remaining
            }
            objectWillChange.send()
            
        }
        
    }
    
}
