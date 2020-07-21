//
//  LeaderboardPresenter.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 21..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine
import CocoaLumberjack

extension Leaderboard {
    
    class Presenter {
        
        private var subscriptions: [Leaderboard.Event: AnyCancellable] = [:]
        
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
        
        func bind(loadingSubject: AnyPublisher<Bool, Never>) {
            subscriptions[.nextPageLoading] = loadingSubject
                .receive(on: DispatchQueue.main)
                .sink(receiveValue: { [weak self] (isLoading) in
                    self?.viewModel.isLoading = isLoading
                })
        }
        
        private func populateViewModel(dataModel: DataModelType?) {
            
            guard let dataModel = dataModel
                else {
                    return
            }
            
            let userList = dataModel.map { user in
                return UserViewModel(id: user.id, userName: user.userName, place: user.place, score: user.score)
            }
            
            self.viewModel.set(userList: userList)
            
        }
        
    }
    
}
