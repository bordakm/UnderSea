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
        
        private var subscriptions: [Main.Event: AnyCancellable] = [:]
        
        private(set) var viewModel: ViewModelType = ViewModelType()
        
        func bind(dataSubject: AnyPublisher<DataModelType?, Error>) {
         
            subscriptions[.dataLoaded] = dataSubject
                .receive(on: DispatchQueue.main)
                .sink(receiveCompletion: { (result) in
                    
                    switch result {
                    case .failure(let error):
                        self.viewModel.set(alertMessage: error.localizedDescription)
                    default:
                        print("-- Presenter: finished")
                        break
                    }
                    
                }, receiveValue: { (data) in

                    self.populateViewModel(dataModel: data)
                    
                })
            
        }
        
        private func populateViewModel(dataModel: DataModelType?) {
            
            guard let dataModel = dataModel
                else {
                    return
            }
            
            var users: [AttackPageViewModel.User] = []
            
            for user in dataModel.users {
                users.append(AttackPageViewModel.User(id: user.id, name: user.name))
            }
            
            self.viewModel.set(viewModel: AttackPageViewModel(users: users))
            
        }
        
    }
    
}

