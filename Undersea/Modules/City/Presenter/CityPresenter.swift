//
//  CityPresenter.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 23..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine
import CocoaLumberjack

extension City {
    
    class Presenter {
        
        private var subscriptions: [City.Event: AnyCancellable] = [:]
        
        private(set) var viewModel: ViewModelType = ViewModelType()
        
        func bind(buildingDataSubject: AnyPublisher<[BuildingDTO]?, Error>) {
         
            subscriptions[.buildingDataLoaded] = buildingDataSubject
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

                    self.populateBuildingsModel(dataModel: data)
                    
                })
            
        }
        
        func bind(buyBuildingDataSubject: AnyPublisher<BuildingDTO?, Error>) {
         
            subscriptions[.buildingBought] = buyBuildingDataSubject
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
                    
                    self.viewModel.setRemaining(id: data.id, remaining: data.remainingRounds)
                    
                })
            
        }
        
        func bind(armyDataSubject: AnyPublisher<[UnitDTO]?, Error>) {
         
            subscriptions[.armyDataLoaded] = armyDataSubject
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

                    self.populateArmyModel(dataModel: data)
                    
                })
            
        }
        
        func bind(selectedUnitsChangedSubject: AnyPublisher<BuyUnitsDTO?, Error>) {
         
            subscriptions[.unitSelectedChange] = selectedUnitsChangedSubject
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
                        DDLogDebug("Unit select change received empty data")
                        return
                    }
                    
                    self.viewModel.set(id: data.typeId, count: data.count)
                    
                })
            
        }
        
        private func populateBuildingsModel(dataModel: [BuildingDTO]?) {
            
            guard let dataModel = dataModel
                else {
                    return
            }
            
            var buildings: [CityPageViewModel.Building] = []
            for buildingData in dataModel {
                buildings.append(CityPageViewModel.Building(buildingData: buildingData))
            }
            
            self.viewModel.set(buildings: buildings)
            
        }
        
        private func populateArmyModel(dataModel: [UnitDTO]?) {
            
            guard let dataModel = dataModel
                else {
                    return
            }
            
            var units: [CityPageViewModel.Unit] = []
            for unitData in dataModel {
                units.append(CityPageViewModel.Unit(unitData: unitData))
            }
            
            self.viewModel.set(units: units)
            
        }
        
    }
    
}
