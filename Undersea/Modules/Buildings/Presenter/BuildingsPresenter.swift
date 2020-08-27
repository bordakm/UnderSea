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
    
    class Presenter : CombinedPresenterProtocol {
        
        private var subscriptions: [Buildings.Event: AnyCancellable] = [:]
        
        private(set) var viewModel: ViewModelType = ViewModelType()
        
        // MARK: - Buildings
        
        //bind(dataSubject: AnyPublisher<[DataModelType]?, Error>)
        func bind<S>(dataListSubject: AnyPublisher<[S], Error>) where S : DTOProtocol {
         
            subscriptions[.buildingDataLoaded] = dataListSubject
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
        
        //bind(buyDataSubject: AnyPublisher<DataModelType?, Error>)
        func bind<S: DTOProtocol>(dataSubject: AnyPublisher<S?, Error>) {
         
            subscriptions[.buildingBought] = dataSubject
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
                    
                    guard let data = data as? BuildingDTO else {
                        DDLogDebug("Error: no building data cereived in response")
                        return
                    }
                    
                    self.viewModel.setRemainingBuildTime(id: data.id, remaining: data.remainingRounds)
                    
                })
            
        }
        
        func bind(loadingSubject: AnyPublisher<Bool, Never>) {
            subscriptions[.viewLoading] = loadingSubject
            .receive(on: DispatchQueue.main)
            .sink(receiveValue: { [weak self] (isLoading) in
                self?.viewModel.isLoading.send(isLoading)
            })
        }
        
        // MARK: - Populate model
        
        private func populateViewModel<S>(dataModel: [S]?) where S : DTOProtocol {
            
            guard let dataModel = dataModel else {
                return
            }
            
            let buildings: [BuildingModel] = dataModel.compactMap { buildingData in
                return BuildingModel(data: buildingData)
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
