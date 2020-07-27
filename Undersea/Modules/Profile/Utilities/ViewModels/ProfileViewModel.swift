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
        @Published var errorModel: ErrorAlertModel = ErrorAlertModel(message: "Unknown error", show: false)
        
        func set(viewModel: ProfilePageViewModel) {
            profilePageModel = viewModel
            objectWillChange.send()
        }
        
    }
    
}
