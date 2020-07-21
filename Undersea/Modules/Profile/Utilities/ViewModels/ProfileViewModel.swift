//
//  ProfileViewModel.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 21..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

extension Profile {
    
    class ViewModel: ObservableObject {
        
        @Published var isLoading = false
        private(set) var profilePageModel: ProfilePageViewModel?
        private(set) var alertMessage: String?
        
        func set(viewModel: ProfilePageViewModel) {
            alertMessage = nil
            profilePageModel = viewModel
            objectWillChange.send()
        }
        
        func set(alertMessage: String) {
            //mainPageModel = nil
            self.alertMessage = alertMessage
            objectWillChange.send()
        }
        
    }
    
}
