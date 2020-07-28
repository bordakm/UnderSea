//
//  UpgradesPresenter.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 28..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine
import CocoaLumberjack

extension Upgrades {
    
    class Presenter {
        
        private var subscriptions: [Upgrades.Event: AnyCancellable] = [:]
        
        private(set) var viewModel: ViewModelType = ViewModelType()
        
        // MARK: - Upgrades
        
        func bind(dataSubject: AnyPublisher<[DataModelType]?, Error>) {
         
            subscriptions[.upgradeDataLoaded] = dataSubject
                .receive(on: DispatchQueue.main)
                .sink(receiveCompletion: { (result) in
                    
                    switch result {
                    case .failure(let error):
                        self.presentError(error)
                    default:
                        print("-- Presenter: finished")
                        break
                    }
                    
                }, receiveValue: { (data) in

                    self.populateModel(dataModel: data)
                    
                })
            
        }
        
        func bind(buyDataSubject: AnyPublisher<DataModelType?, Error>) {
         
            subscriptions[.upgradeBought] = buyDataSubject
                .receive(on: DispatchQueue.main)
                .sink(receiveCompletion: { (result) in
                    
                    switch result {
                    case .failure(let error):
                        self.presentError(error)
                    default:
                        print("-- Presenter: finished")
                        break
                    }
                    
                }, receiveValue: { (data) in
                    
                    guard let data = data else {
                        DDLogDebug("Error: no building data received in response")
                        return
                    }
                    
                    self.viewModel.setRemainingUpgradeTime(id: data.id, remaining: data.remainingRounds)
                    
                })
            
        }
        
        // MARK: - Populate model
        
        private func populateModel(dataModel: [DataModelType]?) {
            
            guard let dataModel = dataModel else {
                return
            }
            
            var upgrades: [UpgradeModel] = []
            for upgradeData in dataModel {
                upgrades.append(UpgradeModel(upgradeData: upgradeData))
            }
            
            self.viewModel.set(upgradeList: upgrades)
            
        }
        
        // MARK: - Error handling
        
        func presentError(_ error: Error) {
            
            viewModel.errorModel = ErrorAlertModel(error: error)
            
        }
        
        func presentError(message: String) {
            
            viewModel.errorModel = ErrorAlertModel(message: message)
            
        }
        
    }
    
}
