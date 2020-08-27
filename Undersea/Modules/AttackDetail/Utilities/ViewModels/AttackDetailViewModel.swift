//
//  AttackDetailViewModel.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 22..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

extension AttackDetail {
    
    class ViewModel: ObservableObject {
        
        var isLoading = PassthroughSubject<Bool, Never>()
        var shouldPopBack = PassthroughSubject<Void, Never>()
        private(set) var animalList: [AnimalViewModel] = []
        @Published var errorModel: ErrorAlertModel = ErrorAlertModel(message: "Unknown error", show: false)
        
        func set(animalList: [AnimalViewModel]) {
            self.animalList = animalList
            objectWillChange.send()
        }
        
    }
    
}
