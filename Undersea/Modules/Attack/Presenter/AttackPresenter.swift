//
//  AttackPresenter.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 15..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

extension Attack {
    
    class Presenter {
        
        private var subscriptions: [Attack.Event: AnyCancellable] = [:]
        
        private(set) var viewModel: ViewModelType = ViewModelType()
        
        func bind(dataSubject: AnyPublisher<DataModelType?, Error>) {
         
            subscriptions[.dataLoaded] = dataSubject
                .receive(on: DispatchQueue.main)
                .sink(receiveCompletion: { (result) in
                    
                    switch result {
                    case .failure(let error):
                        self.viewModel.isRefreshing = false
                        self.presentError(error)
                    default:
                        print("-- Presenter: finished")
                        break
                    }
                    
                }, receiveValue: { (data) in

                    self.viewModel.isRefreshing = false
                    self.populateViewModel(dataModel: data)
                    
                })
            
        }
        
        func bind(loadingSubject: AnyPublisher<Bool, Never>) {
            subscriptions[.nextPageLoading] = loadingSubject
                .receive(on: DispatchQueue.main)
                .sink(receiveValue: { [weak self] (isLoading) in
                    self?.viewModel.isLoading = isLoading
                })
        }
        
        private func populateViewModel(dataModel: DataModelType?) {
            
            guard let dataModel = dataModel else {
                return
            }
            
            let userList = dataModel.map { user in
                return UserViewModel(id: user.id, place: user.place, userName: user.userName)
            }
            
            self.viewModel.set(userList: userList)
            
        }
        
        func presentError(_ error: Error) {
            
            viewModel.errorModel = ErrorAlertModel(error: error)
            
        }
        
        func presentError(message: String) {
            
            viewModel.errorModel = ErrorAlertModel(message: message)
            
        }
        
    }
    
}

