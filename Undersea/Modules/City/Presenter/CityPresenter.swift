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
                    
                    self.viewModel.setRemaining(remaining: data.remainingRounds)
                    
                })
            
        }
        
        func bind(upgradeDataSubject: AnyPublisher<[UpgradeDTO]?, Error>) {
         
            subscriptions[.upgradeDataLoaded] = upgradeDataSubject
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

                    self.populateUpgradesModel(dataModel: data)
                    
                })
            
        }
        
        func bind(buyUpgradeDataSubject: AnyPublisher<UpgradeDTO?, Error>) {
         
            subscriptions[.upgradeBought] = buyUpgradeDataSubject
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
                    
                    self.viewModel.setRemainingUpgrades(id: data.id, remaining: data.remainingRounds)
                    
                })
            
        }
        
        func bind(armyDataSubject: AnyPublisher<[UnitDTO]?, Error>, buyUnitDataSubject: AnyPublisher<[BuyUnitsDTO], Error>) {
         
            subscriptions[.armyDataLoaded] = Publishers.CombineLatest(armyDataSubject, buyUnitDataSubject)
                .receive(on: DispatchQueue.main)
                .sink(receiveCompletion: { (result) in
                    
                    switch result {
                    case .failure(let error):
                        self.viewModel.set(alertMessage: error.localizedDescription)
                    default:
                        print("-- Presenter: finished")
                        break
                    }
                    
                }, receiveValue: { (armyData, selectedUnitData) in

                    self.populateArmyModel(armyData: armyData ?? [], selectedUnitData: selectedUnitData)
                    
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
        
        private func populateUpgradesModel(dataModel: [UpgradeDTO]?) {
            
            guard let dataModel = dataModel
                else {
                    return
            }
            
            var upgrades: [CityPageViewModel.Upgrade] = []
            for upgradeData in dataModel {
                upgrades.append(CityPageViewModel.Upgrade(upgradeData: upgradeData))
            }
            
            self.viewModel.set(upgrades: upgrades)
            
        }
        
        
        private func populateArmyModel(armyData: [UnitDTO], selectedUnitData: [BuyUnitsDTO]) {
            
            
            var units: [CityPageViewModel.Unit] = []
            for unitData in armyData {
                let selected = selectedUnitData.first { (item) -> Bool in
                    return unitData.id == item.typeId
                }
                units.append(CityPageViewModel.Unit(unitData: unitData, selected: selected?.count ?? 0))
            }
            
            self.viewModel.set(units: units)
            
        }
        
    }
    
}
