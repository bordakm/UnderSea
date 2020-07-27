//
//  RegisterPresenter.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 15..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

extension Register {
    
    class Presenter {
        
        private var subscriptions: [Register.Event: AnyCancellable] = [:]
        
        private(set) var viewModel: ViewModelType = ViewModelType()
        
        func bind(dataSubject: AnyPublisher<DataModelType?, Error>) {
         
            subscriptions[.loggedIn] = dataSubject
                .receive(on: DispatchQueue.main)
                .sink(receiveCompletion: { (result) in
                    
                    switch result {
                    case .failure(let error):
                        self.presentUsefulErrorMessage(error: error)
                    default:
                        print("-- Presenter: finished")
                        break
                    }
                    
                }, receiveValue: { data in
                    
                    if data != nil {
                        RootPageManager.shared.currentPage = RootPage.main
                    }
                    
                })
            
        }
        
        func presentUsefulErrorMessage(error: Error) {
            
            guard let errorData = error.localizedDescription.data(using: .utf8) else {
                self.viewModel.alertMessage = "Ismeretlen hiba történt!"
                self.viewModel.alert = true
                return
            }
            
            guard let array = try? JSONSerialization.jsonObject(with: errorData, options: .mutableContainers) as? [AnyObject] else {
                self.viewModel.alertMessage = "Ismeretlen hiba történt!"
                self.viewModel.alert = true
                return
            }
            
            guard let jsonDict = array.first as? [String: AnyObject] else {
                self.viewModel.alertMessage = "Ismeretlen hiba történt!"
                self.viewModel.alert = true
                return
            }
            
            if let code = jsonDict["code"] {
                
                if code.isEqual(to: "PasswordTooShort") {
                    self.viewModel.alertMessage = "Túl rövid jelszó!"
                } else if let description = jsonDict["description"] {
                    self.viewModel.alertMessage = "\(description)"
                }
                
                self.viewModel.alert = true
                
            } else {
            
                if let description = jsonDict["description"] {
                    self.viewModel.alertMessage = "\(description)"
                } else {
                    self.viewModel.alertMessage = "Ismeretlen hiba: \(error.localizedDescription)"
                }
                
                self.viewModel.alert = true
                
            }
            
        }
        
    }
    
}
