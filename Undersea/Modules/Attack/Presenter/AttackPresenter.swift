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
    
    class AttackPresenter : AttackPresenterProtocol {
        
        private var subscriptions: [Attack.Event: AnyCancellable] = [:]
        
        private(set) var viewModel: ViewModelType = ViewModelType()
        
        func bind<S>(dataListSubject: AnyPublisher<[S], Error>) where S : DTOProtocol {
            
            subscriptions[.dataLoaded] = dataListSubject
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
        
        func bind(loadMoreSubject: AnyPublisher<Bool, Never>) {
            subscriptions[.nextPageLoading] = loadMoreSubject
            .receive(on: DispatchQueue.main)
            .sink(receiveValue: { [weak self] (isLoadingMore) in
                self?.viewModel.isLoadingMore = isLoadingMore
            })
        }
        
        func bind(loadingSubject: AnyPublisher<Bool, Never>) {
            subscriptions[.viewLoading] = loadingSubject
            .receive(on: DispatchQueue.main)
            .sink(receiveValue: { [weak self] (isLoading) in
                self?.viewModel.isLoading.send(isLoading)
            })
        }
        
        private func populateViewModel<S>(dataModel: [S]?) where S : DTOProtocol {
            
            guard let dataModel = dataModel else {
                return
            }
            
            let userList = dataModel.compactMap { user in
                return UserViewModel(data: user)
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

