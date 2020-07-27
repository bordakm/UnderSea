//
//  CityPageInteractor.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 23..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

extension City {
    
    class Interactor {
        
        private lazy var presenter: Presenter = setPresenter()
        var setPresenter: (() -> Presenter)!
        
        private let worker = City.ApiWorker()
        
        let buildingDataSubject = CurrentValueSubject<[BuildingDTO]?, Error>(nil)
        let buyBuildingDataSubject = CurrentValueSubject<BuildingDTO?, Error>(nil)
        
        let upgradeDataSubject = CurrentValueSubject<[UpgradeDTO]?, Error>(nil)
        let buyUpgradeDataSubject = CurrentValueSubject<UpgradeDTO?, Error>(nil)
        
        let armyDataSubject = CurrentValueSubject<[UnitDTO]?, Error>(nil)
        let buyUnitDataSubject = CurrentValueSubject<[BuyUnitsDTO], Error>([])
        
        private var subscription: AnyCancellable?
     
        func handleUsecase(_ event: City.Usecase) {
            
            switch event {
            case .loadBuildings:
                loadBuildings()
            case .buyBuilding(let id):
                buyBuilding(id: id)
            case .loadUpgrades:
                loadUpgrades()
            case .buyUpgrade(let id):
                buyUpgrade(id: id)
            case .loadArmy:
                loadArmy()
            case .changeUnitAmount(let id, let inc):
                selectedUnitsChanged(id: id, inc: inc)
            case .buyUnits:
                buyUnits()
            }
            
        }
        
        private func loadBuildings() {
            
            subscription = worker.getBuildings()
                .receive(on: DispatchQueue.global())
                .sink(receiveCompletion: { (result) in
                    switch result {
                    case .failure(_):
                        self.buildingDataSubject.send(completion: result)
                    default:
                        print("-- Profile Interactor: load data finished")
                        break
                    }
                }, receiveValue: { data in
                    self.buildingDataSubject.send(data)
                })
            
        }
        
        private func buyBuilding(id: Int) {
            
            subscription = worker.buyBuildings(data: BuyBuildingDTO(id: id))
                .receive(on: DispatchQueue.global())
                .sink(receiveCompletion: { (result) in
                    switch result {
                    case .failure(_):
                        self.buyBuildingDataSubject.send(completion: result)
                    default:
                        print("-- Profile Interactor: load data finished")
                        break
                    }
                }, receiveValue: { data in
                    
                    self.buyBuildingDataSubject.send(data)
                    
                })
            
        }
        
        private func loadUpgrades() {
            
            subscription = worker.getUpgrades()
                .receive(on: DispatchQueue.global())
                .sink(receiveCompletion: { (result) in
                    switch result {
                    case .failure(_):
                        self.upgradeDataSubject.send(completion: result)
                    default:
                        print("-- Profile Interactor: load data finished")
                        break
                    }
                }, receiveValue: { data in
                    self.upgradeDataSubject.send(data)
                })
            
        }
        
        private func buyUpgrade(id: Int) {
            
            subscription = worker.buyUpgrade(data: BuyUpgradeDTO(id: id))
                .receive(on: DispatchQueue.global())
                .sink(receiveCompletion: { (result) in
                    switch result {
                    case .failure(_):
                        self.buyUpgradeDataSubject.send(completion: result)
                    default:
                        print("-- Profile Interactor: load data finished")
                        break
                    }
                }, receiveValue: { data in
                    
                    self.buyUpgradeDataSubject.send(data)
                    
                })
            
        }
        
        private func loadArmy() {
            
            subscription = worker.getArmy()
            .receive(on: DispatchQueue.global())
            .sink(receiveCompletion: { (result) in
                switch result {
                case .failure(_):
                    self.armyDataSubject.send(completion: result)
                default:
                    print("-- Profile Interactor: load data finished")
                    break
                }
            }, receiveValue: { data in
                self.armyDataSubject.send(data)
            })
            
        }

        private func selectedUnitsChanged(id: Int, inc: Bool) {
            
            var buyUnitData = buyUnitDataSubject.value
            if let index = buyUnitData.firstIndex(where: { (unit) -> Bool in
                return unit.typeId == id
            }) {
                let currentValue = buyUnitData[index].count
                buyUnitData[index].count = max(0, currentValue + (inc ? 1 : -1))
            } else {
                let unitData = BuyUnitsDTO(typeId: id, count: 1)
                buyUnitData.append(unitData)
            }
            buyUnitDataSubject.send(buyUnitData)
            
        }
        
        private func buyUnits() {
            
            let buyUnitData = buyUnitDataSubject.value.filter { (item) -> Bool in
                return item.count != 0
            }
            
            if buyUnitData.count == 0 {
                return
            }
            
            subscription = worker.buyUnits(data: buyUnitData)
            .receive(on: DispatchQueue.global())
            .sink(receiveCompletion: { (result) in
                switch result {
                case .failure(_):
                    self.armyDataSubject.send(completion: result)
                default:
                    print("-- Profile Interactor: load data finished")
                    break
                }
            }, receiveValue: { data in
                
                var tmpSubjectValue = self.armyDataSubject.value ?? []
                
                for index in 0 ..< tmpSubjectValue.count {
                    if let buyUnitData = data.first(where: { (buyUnitData) -> Bool in
                        buyUnitData.typeId == tmpSubjectValue[index].id
                    }) {
                        tmpSubjectValue[index].count += buyUnitData.count
                    }
                }
                
                self.armyDataSubject.send(tmpSubjectValue)
                self.buyUnitDataSubject.send([])
                
            })
            
        }
        
    }
    
}
