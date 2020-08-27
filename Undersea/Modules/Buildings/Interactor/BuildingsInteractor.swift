//
//  BuildingsInteractor.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 28..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

extension Buildings {
    
    class Interactor {
        
        // MARK: - Properties
        
        private lazy var presenter: CombinedPresenterProtocol = setPresenter()
        var setPresenter: (() -> CombinedPresenterProtocol)!
        
        private let worker = Buildings.ApiWorker()
        
        let dataSubject = CurrentValueSubject<[DataModelType], Error>([])
        let buyDataSubject = CurrentValueSubject<DataModelType?, Error>(nil)
        let loadingSubject = CurrentValueSubject<Bool, Never>(false)
        
        private var subscription: AnyCancellable?
     
        func handleUsecase(_ event: Buildings.Usecase) {
            
            switch event {
            case .loadBuildings:
                loadBuildings()
            case .buyBuilding(let id):
                buyBuilding(id: id)
            }
            
        }
        
        // MARK: - Buildings
        
        private func loadBuildings() {
            
            loadingSubject.send(true)
            subscription = worker.getBuildings()
                .receive(on: DispatchQueue.global())
                .sink(receiveCompletion: { (result) in
                    self.loadingSubject.send(false)
                    switch result {
                    case .failure(_):
                        self.dataSubject.send(completion: result)
                    default:
                        print("-- Profile Interactor: load data finished")
                        break
                    }
                }, receiveValue: { data in
                    sleep(3)
                    self.dataSubject.send(data)
                })
            
        }
        
        private func buyBuilding(id: Int) {
            
            loadingSubject.send(true)
            subscription = worker.buyBuildings(data: BuyBuildingDTO(id: id))
                .receive(on: DispatchQueue.global())
                .sink(receiveCompletion: { (result) in
                    self.loadingSubject.send(false)
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
