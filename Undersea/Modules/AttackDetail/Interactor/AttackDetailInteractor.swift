//
//  AttackDetailInteractor.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 22..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

extension AttackDetail {
    
    class Interactor {
        
        private lazy var presenter: Presenter = setPresenter()
        var setPresenter: (() -> Presenter)!
        
        private let worker = AttackDetail.ApiWorker()
        let dataSubject = CurrentValueSubject<DataModelType?, Error>(nil)
        let loadingSubject = CurrentValueSubject<Bool, Never>(false)
        private var subscription: AnyCancellable?
     
        func handleUsecase(_ event: AttackDetail.Usecase) {
            
            switch event {
            case .load:
                loadData()
            case .attack:
                print("attack")
            }
            
        }
        
        private func loadData() {
            
            subscription = worker.getUnits()
                .receive(on: DispatchQueue.global())
                .sink(receiveCompletion: { (result) in
                    switch result {
                    case .failure(_):
                        self.sendFakeData()
                        //self.dataSubject.send(completion: result)
                    default:
                        print("-- Profile Interactor: load data finished")
                        break
                    }
                }, receiveValue: { data in
                    //self.dataSubject.send(data)
                    self.sendFakeData()
                })
            
        }
        
        private func sendFakeData() {
            let animals = [AttackDetailPageDTO(id: 1, name: "shark", availableCount: 15, imageUrl: ""), AttackDetailPageDTO(id: 2, name: "seahorse", availableCount: 20, imageUrl: ""), AttackDetailPageDTO(id: 3, name: "seal", availableCount: 12, imageUrl: "")]
            self.dataSubject.send(animals)
        }
        
    }
    
}
