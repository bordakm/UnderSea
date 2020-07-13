//
//  MainViewModel.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 13..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

extension Main {
    
    class ViewModel: ObservableObject {
        
        @Published var isLoading = false
        private(set) var mainPageModel: MainPageViewModel?
        private(set) var alertMessage: String?
        
        func set(viewModel: MainPageViewModel) {
            alertMessage = nil
            mainPageModel = viewModel
            objectWillChange.send()
        }
        
        func set(alertMessage: String) {
            mainPageModel = nil
            self.alertMessage = alertMessage
            objectWillChange.send()
        }
        
    }
    
}
