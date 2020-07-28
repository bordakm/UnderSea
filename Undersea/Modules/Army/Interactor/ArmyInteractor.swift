//
//  ArmyInteractor.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 28..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

extension Army {
    
    class Interactor {
        
        // MARK: - Properties
        
        private lazy var presenter: Presenter = setPresenter()
        var setPresenter: (() -> Presenter)!
        
        private let worker = Army.ApiWorker()
        
        let dataSubject = CurrentValueSubject<[DataModelType]?, Error>(nil)
        let buyDataSubject = CurrentValueSubject<[BuyUnitsDTO], Error>([])
        
        private var subscription: AnyCancellable?
     
        func handleUsecase(_ event: Army.Usecase) {
            
            switch event {
            case .load:
                loadArmy()
            case .changeUnitAmount(let id, let inc):
                selectedUnitsChanged(id: id, inc: inc)
            case .buyUnits:
                buyUnits()
            }
            
        }
        
        // MARK: - Army/Units
        
        private func loadArmy() {
            
            subscription = worker.getArmy()
            .receive(on: DispatchQueue.global())
            .sink(receiveCompletion: { (result) in
                switch result {
                case .failure(_):
                    self.dataSubject.send(completion: result)
                default:
                    print("-- Profile Interactor: load data finished")
                    break
                }
            }, receiveValue: { data in
                self.dataSubject.send(data)
            })
            
        }

        private func selectedUnitsChanged(id: Int, inc: Bool) {
            
            var buyUnitData = buyDataSubject.value
            if let index = buyUnitData.firstIndex(where: { (unit) -> Bool in
                return unit.typeId == id
            }) {
                let currentValue = buyUnitData[index].count
                buyUnitData[index].count = max(0, currentValue + (inc ? 1 : -1))
            } else {
                let unitData = BuyUnitsDTO(typeId: id, count: 1)
                buyUnitData.append(unitData)
            }
            buyDataSubject.send(buyUnitData)
            
        }
        
        private func buyUnits() {
            
            let buyUnitData = buyDataSubject.value.filter { (item) -> Bool in
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
                    self.dataSubject.send(completion: result)
                default:
                    print("-- Profile Interactor: load data finished")
                    break
                }
            }, receiveValue: { data in
                
                var tmpSubjectValue = self.dataSubject.value ?? []
                
                for index in 0 ..< tmpSubjectValue.count {
                    if let buyUnitData = data.first(where: { (buyUnitData) -> Bool in
                        buyUnitData.typeId == tmpSubjectValue[index].id
                    }) {
                        tmpSubjectValue[index].count += buyUnitData.count
                    }
                }
                
                self.dataSubject.send(tmpSubjectValue)
                self.buyDataSubject.send([])
                
            })
            
        }
        
    }
    
}
