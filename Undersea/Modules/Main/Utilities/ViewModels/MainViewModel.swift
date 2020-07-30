//
//  MainViewModel.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 13..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

extension Main {
    
    class ViewModel: ObservableObject {
        
        @Published var isLoading = PassthroughSubject<Bool, Never>()
        private(set) var mainPageModel: MainPageViewModel?
        @Published var errorModel: ErrorAlertModel = ErrorAlertModel(message: "Unknown error", show: false)
        
        func set(viewModel: MainPageViewModel) {
            mainPageModel = viewModel
            objectWillChange.send()
        }
        
    }
    
}
