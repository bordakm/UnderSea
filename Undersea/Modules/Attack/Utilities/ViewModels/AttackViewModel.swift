//
//  AttackViewModel.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 15..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

extension Attack {
    
    class ViewModel: ObservableObject {
        
        @Published var isLoading = false
        private(set) var attackPageModel: AttackPageViewModel?
        private(set) var alertMessage: String?
        
        func set(viewModel: AttackPageViewModel) {
            alertMessage = nil
            attackPageModel = viewModel
            objectWillChange.send()
        }
        
        func set(alertMessage: String) {
            //mainPageModel = nil
            self.alertMessage = alertMessage
            objectWillChange.send()
        }
        
    }
    
}
