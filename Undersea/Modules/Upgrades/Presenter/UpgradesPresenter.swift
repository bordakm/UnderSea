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
    
    class Presenter : CombinedPresenterProtocol {
        
        private var subscriptions: [Upgrades.Event: AnyCancellable] = [:]
        
        private(set) var viewModel: ViewModelType = ViewModelType()
        
        // MARK: - Upgrades
        
        //bind(dataSubject: AnyPublisher<[DataModelType]?, Error>)
        func bind<S>(dataListSubject: AnyPublisher<[S], Error>) where S : DTOProtocol {
         
            subscriptions[.upgradeDataLoaded] = dataListSubject
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
        
        //bind(buyDataSubject: AnyPublisher<DataModelType?, Error>)
        func bind<S: DTOProtocol>(dataSubject: AnyPublisher<S?, Error>) {
         
            subscriptions[.upgradeBought] = dataSubject
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
                    
                    guard let data = data as? UpgradeDTO else {
                        DDLogDebug("Error: no building data received in response")
                        return
                    }
                    
                    self.viewModel.setRemainingUpgradeTime(id: data.id, remaining: data.remainingRounds)
                    
                })
            
        }
        
        func bind(loadingSubject: AnyPublisher<Bool, Never>) {
        }
        
        // MARK: - Populate model
        
        private func populateModel<S>(dataModel: [S]?) where S : DTOProtocol {
            
            guard let dataModel = dataModel else {
                return
            }
            
            var upgrades: [UpgradeModel] = dataModel.compactMap { upgrade in
                return UpgradeModel(data: upgrade)
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
