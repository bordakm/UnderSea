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
        
        @Published var isLoading = false
        var shouldPopBack = PassthroughSubject<Void, Never>()
        private(set) var animalList: [AnimalViewModel] = []
        private(set) var alertMessage: String?
        
        func set(animalList: [AnimalViewModel]) {
            alertMessage = nil
            self.animalList = animalList
            objectWillChange.send()
        }
        
        func set(alertMessage: String) {
            //mainPageModel = nil
            self.alertMessage = alertMessage
            objectWillChange.send()
        }
        
    }
    
}
