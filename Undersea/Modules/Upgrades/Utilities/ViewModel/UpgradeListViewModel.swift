//
//  UpgradeListViewModel.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 28..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

extension Upgrades {
    
    class ViewModel: ObservableObject {
        
        @Published var isLoading = false
        private(set) var upgradeList: [UpgradeModel] = []
        @Published var errorModel: ErrorAlertModel = ErrorAlertModel(message: "Unknown error", show: false)
        
        func set(upgradeList: [UpgradeModel]) {
            self.upgradeList = upgradeList
            objectWillChange.send()
        }
        
        func setRemainingUpgradeTime(id: Int, remaining: Int) {
            
            if let index = upgradeList.firstIndex(where: { (upgrade) -> Bool in
                return upgrade.id == id
            }) {
                upgradeList[index].remainingRounds = remaining
            }
            objectWillChange.send()
            
        }
        
    }
    
}
