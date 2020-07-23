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
        let attackSentSubject = CurrentValueSubject<[SendAttackResponseDTO]?, Error>(nil)
        let loadingSubject = CurrentValueSubject<Bool, Never>(false)
        private var subscription: AnyCancellable?
        
        private var attackingUnits: [SendAttackDTO.Unit] = []
        private var defenderId: Int?
        
        init(defenderId: Int) {
            self.defenderId = defenderId
        }
     
        func handleUsecase(_ event: AttackDetail.Usecase) {
            
            switch event {
                
            case .load:
                loadData()
                
            case .setSendCount(let id, let count):
                
                if let index = attackingUnits.firstIndex(where: { (unit) -> Bool in
                    return unit.id == id
                }) {
                    attackingUnits[index].sendCount = count
                } else {
                    attackingUnits.append(SendAttackDTO.Unit(id: id, sendCount: count))
                }
                
            case .attack:
                attack()
                
            }
            
        }
        
        private func loadData() {
            
            subscription = worker.getUnits()
                .receive(on: DispatchQueue.global())
                .sink(receiveCompletion: { (result) in
                    switch result {
                    case .failure(_):
                        //self.sendFakeData()
                        self.dataSubject.send(completion: result)
                    default:
                        print("-- Profile Interactor: load data finished")
                        break
                    }
                }, receiveValue: { data in
                    self.dataSubject.send(data)
                    //self.sendFakeData()
                })
            
        }
        
        private func attack() {
            
            guard let defenderId = defenderId else {
                return
            }
            
            for index in (0..<attackingUnits.count).reversed() {
                if attackingUnits[index].sendCount == 0 {
                    attackingUnits.remove(at: index)
                }
            }
            
            if attackingUnits.count == 0 {
                return
            }
            
            let attackData = SendAttackDTO(defenderUserId: defenderId, attackingUnits: attackingUnits)
            
            subscription = worker.attack(attackData)
                .receive(on: DispatchQueue.global())
                .sink(receiveCompletion: { (result) in
                    switch result {
                    case .failure(_):
                        //self.sendFakeData()
                        self.attackSentSubject.send(completion: result)
                    default:
                        print("-- Profile Interactor: load data finished")
                        break
                    }
                }, receiveValue: { data in
                    //self.sendFakeData()
                    self.attackSentSubject.send(data)
                })
            
        }
        
        /*
        private func sendFakeData() {
            let animals = [AttackDetailPageDTO(id: 1, name: "shark", availableCount: 15, imageUrl: ""), AttackDetailPageDTO(id: 2, name: "seahorse", availableCount: 20, imageUrl: ""), AttackDetailPageDTO(id: 3, name: "seal", availableCount: 12, imageUrl: "")]
            self.dataSubject.send(animals)
        }
        */
        
    }
    
}
