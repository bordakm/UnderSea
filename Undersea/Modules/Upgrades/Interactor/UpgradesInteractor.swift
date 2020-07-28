//
//  UpgradesInteractor.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 28..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

extension Upgrades {
    
    class Interactor {
        
        // MARK: - Properties
        
        private lazy var presenter: Presenter = setPresenter()
        var setPresenter: (() -> Presenter)!
        
        private let worker = Upgrades.ApiWorker()
        
        let dataSubject = CurrentValueSubject<[DataModelType]?, Error>(nil)
        let buyDataSubject = CurrentValueSubject<DataModelType?, Error>(nil)
        
        private var subscription: AnyCancellable?
     
        func handleUsecase(_ event: Upgrades.Usecase) {
            
            switch event {
            case .loadUpgrades:
                loadUpgrades()
            case .buyUpgrade(let id):
                buyUpgrade(id: id)
            }
            
        }
        
        // MARK: - Upgrades
        
        private func loadUpgrades() {
            
            subscription = worker.getUpgrades()
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
        
        private func buyUpgrade(id: Int) {
            
            subscription = worker.buyUpgrade(data: BuyUpgradeDTO(id: id))
                .receive(on: DispatchQueue.global())
                .sink(receiveCompletion: { (result) in
                    switch result {
                    case .failure(_):
                        self.buyDataSubject.send(completion: result)
                    default:
                        print("-- Profile Interactor: load data finished")
                        break
                    }
                }, receiveValue: { data in
                    
                    self.buyDataSubject.send(data)
                    
                })
            
        }
        
    }
    
}
