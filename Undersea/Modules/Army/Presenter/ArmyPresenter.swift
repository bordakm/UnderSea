//
//  ArmyPresenter.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 28..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine
import CocoaLumberjack

extension Army {
    
    class Presenter : ArmyPresenterProtocol {
        
        private var subscriptions: [Army.Event: AnyCancellable] = [:]
        
        private(set) var viewModel: ViewModelType = ViewModelType()
        
        // MARK: - Army
        
        func bind<S, T>(dataListSubject: AnyPublisher<[S], Error>, buyDataSubject: AnyPublisher<[T], Error>) where S : DTOProtocol, T : DTOProtocol {
         
            subscriptions[.dataLoaded] = Publishers.CombineLatest(dataListSubject, buyDataSubject)
                .receive(on: DispatchQueue.main)
                .sink(receiveCompletion: { (result) in
                    
                    switch result {
                    case .failure(let error):
                        self.presentError(error)
                    default:
                        print("-- Presenter: finished")
                        break
                    }
                    
                }, receiveValue: { (armyData, selectedUnitData) in

                    guard let armyData = armyData as? [DataModelType], let selectedUnitData = selectedUnitData as? [BuyUnitsDTO] else {
                        return
                    }
                    
                    self.populateModel(armyData: armyData, selectedUnitData: selectedUnitData)
                    
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
        
        private func populateModel(armyData: [DataModelType], selectedUnitData: [BuyUnitsDTO]) {
            
            var units: [UnitModel] = []
            for unitData in armyData {
                let selected = selectedUnitData.first { (item) -> Bool in
                    return unitData.id == item.typeId
                }
                units.append(UnitModel(unitData: unitData, selected: selected?.count ?? 0))
            }
            
            self.viewModel.set(unitList: units)
            
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
