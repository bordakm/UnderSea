//
//  BuildingsPresenter.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 28..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine
import CocoaLumberjack

extension Buildings {
    
    class Presenter {
        
        private var subscriptions: [Buildings.Event: AnyCancellable] = [:]
        
        private(set) var viewModel: ViewModelType = ViewModelType()
        
        // MARK: - Buildings
        
        func bind(dataSubject: AnyPublisher<[DataModelType]?, Error>) {
         
            subscriptions[.buildingDataLoaded] = dataSubject
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

                    self.populateViewModel(dataModel: data)
                    
                })
            
        }
        
        func bind(buyDataSubject: AnyPublisher<DataModelType?, Error>) {
         
            subscriptions[.buildingBought] = buyDataSubject
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
                        DDLogDebug("Error: no building data cereived in response")
                        return
                    }
                    
                    self.viewModel.setRemainingBuildTime(id: data.id, remaining: data.remainingRounds)
                    
                })
            
        }
        
        // MARK: - Populate model
        
        private func populateViewModel(dataModel: [DataModelType]?) {
            
            guard let dataModel = dataModel else {
                return
            }
            
            var buildings: [BuildingModel] = []
            for buildingData in dataModel {
                buildings.append(BuildingModel(buildingData: buildingData))
            }
            
            self.viewModel.set(buildingList: buildings)
            
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
