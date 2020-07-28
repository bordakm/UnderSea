//
//  TeamsPresenter.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 22..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine
import CocoaLumberjack

extension Teams {
    
    class Presenter {
        
        private var subscriptions: [Teams.Event: AnyCancellable] = [:]
        
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
        
        private func populateViewModel(dataModel: DataModelType?) {
            
            guard let dataModel = dataModel else {
                return
            }
            
            let teams = dataModel.map { team in
                return TeamModel(name: team.countryName, units: team.units.map { unit in
                    return "\(unit.count) \(unit.name)"
                })
            }
            
            self.viewModel.set(teams: teams)
            
        }
        
        func presentError(_ error: Error) {
            
            viewModel.errorModel = ErrorAlertModel(error: error)
            
        }
        
        func presentError(message: String) {
            
            viewModel.errorModel = ErrorAlertModel(message: message)
            
        }
        
    }
    
}
