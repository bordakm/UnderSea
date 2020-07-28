//
//  LoginPresenter.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 15..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

extension Login {
    
    class Presenter {
        
        private var subscriptions: [Login.Event: AnyCancellable] = [:]
        
        private(set) var viewModel: ViewModelType = ViewModelType()
        
        func bind(dataSubject: AnyPublisher<DataModelType?, Error>) {
         
            subscriptions[.loggedIn] = dataSubject
                .receive(on: DispatchQueue.main)
                .sink(receiveCompletion: { (result) in
                    
                    switch result {
                    case .failure(let error):
                        self.presentError(error)
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
        
        func presentError(_ error: Error) {
            
            viewModel.errorModel = ErrorAlertModel(error: error)
            
        }
        
        func presentError(message: String) {
            
            viewModel.errorModel = ErrorAlertModel(message: message)
            
        }
        
    }
    
}
