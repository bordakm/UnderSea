//
//  ArmyListViewModel.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 28..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

extension Army {
    
    class ViewModel: ObservableObject {
        
        @Published var isLoading = PassthroughSubject<Bool, Never>()
        private(set) var unitList: [UnitModel] = []
        @Published var errorModel: ErrorAlertModel = ErrorAlertModel(message: "Unknown error", show: false)
        
        func set(unitList: [UnitModel]) {
            self.unitList = unitList
            objectWillChange.send()
        }
        
    }
    
}
