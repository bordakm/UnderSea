//
//  BuildingsPresenter.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 24..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine
import CocoaLumberjack

extension Buildings {
    
    class Presenter {
        
        private var subscriptions: [Buildings.Event: AnyCancellable] = [:]
        
        private(set) var viewModel: ViewModelType = ViewModelType()
        
        func bind(dataSubject: AnyPublisher<[BuildingDTO]?, Error>) {
         
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
        
        func bind(buyBuildingDataSubject: AnyPublisher<BuildingDTO?, Error>) {
         
            subscriptions[.dataLoaded] = buyBuildingDataSubject
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
                    
                    guard let data = data else {
                        DDLogDebug("Error: no building data cereived in response")
                        return
                    }
                    
                    self.viewModel.setRemaining(buildingId: data.id, remaining: data.remainingRounds)
                    
                })
            
        }
        
        private func populateViewModel(dataModel: [BuildingDTO]?) {
            
            guard let dataModel = dataModel
                else {
                    return
            }
            
            var buildings: [Building] = []
            for buildingData in dataModel {
                buildings.append(Building(buildingData: buildingData))
            }
            
            self.viewModel.set(buildings: buildings)
            
        }
        
    }
    
}
