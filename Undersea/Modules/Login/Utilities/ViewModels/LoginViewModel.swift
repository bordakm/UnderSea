//
//  LoginViewModel.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 15..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

extension Login {
    
    class ViewModel: ObservableObject {
        
        @Published var errorModel: ErrorAlertModel = ErrorAlertModel(message: "Unknown error", show: false)
        
    }
    
}
