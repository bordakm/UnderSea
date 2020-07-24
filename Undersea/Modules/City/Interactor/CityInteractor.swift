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
        let armyDataSubject = CurrentValueSubject<[UnitDTO]?, Error>(nil)
        let selectedUnitsChangedSubject = CurrentValueSubject<BuyUnitsDTO?, Error>(nil)
        //let buyUnitsDataSubject = CurrentValueSubject<[BuyUnitsDTO]?, Error>(nil)
        
        private var subscription: AnyCancellable?
        private var buyUnitData: [BuyUnitsDTO] = []
     
        func handleUsecase(_ event: City.Usecase) {
            
            switch event {
            case .loadBuildings:
                loadBuildings()
            case .buyBuilding(let id):
                buyBuilding(id: id)
            case .loadArmy:
                loadArmy()
            case .selectUnitAmount(let id, let amount):
                selectedUnitsChanged(id: id, amount: amount)
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
        
        private func selectedUnitsChanged(id: Int, amount: Int) {
            
            if let index = buyUnitData.firstIndex(where: { (unit) -> Bool in
                return unit.typeId == id
            }) {
                buyUnitData[index].count = amount
                self.selectedUnitsChangedSubject.send(buyUnitData[index])
            } else {
                let unitData = BuyUnitsDTO(typeId: id, count: amount)
                buyUnitData.append(unitData)
                self.selectedUnitsChangedSubject.send(unitData)
            }
            
            
            
            /*var tmpSubjectValue = self.armyDataSubject.value ?? []
            
            
            if let index = tmpSubjectValue.firstIndex(where: { (unitData) -> Bool in
                unitData.id == id
            }) {
                tmpSubjectValue[index].selected += amount
            }
            
            self.armyDataSubject.send(tmpSubjectValue)*/
            
        }
        
        private func buyUnits() {
            
            for index in (0..<buyUnitData.count).reversed() {
                if buyUnitData[index].count == 0 {
                    buyUnitData.remove(at: index)
                }
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
                
            })
            
        }
        
    }
    
}
