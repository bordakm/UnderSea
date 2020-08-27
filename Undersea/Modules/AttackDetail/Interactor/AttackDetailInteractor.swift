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
    
    class AttackDetailInteractor {
        
        private lazy var presenter: AttackDetailPresenterProtocol = setPresenter()
        var setPresenter: (() -> AttackDetailPresenterProtocol)!
        
        private let worker = AttackDetail.ApiWorker()
        let dataSubject = CurrentValueSubject<DataModelType, Error>(DataModelType())
        let attackSentSubject = CurrentValueSubject<[SendAttackResponseDTO], Error>([])
        let loadingSubject = PassthroughSubject<Bool, Never>()
        
        private var subscription: AnyCancellable?
        private var signalRSubscription: AnyCancellable?
        
        private var attackingUnits: [SendAttackDTO.Unit] = []
        private var defenderId: Int?
        
        init(defenderId: Int?) {
            self.defenderId = defenderId
            signalRSubscription = SignalRService.shared.incomingSignalSubject
                .receive(on: DispatchQueue.global())
                .sink(receiveValue: { [weak self] (_) in
                    self?.loadData()
                })
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
            
            print("-- INTERACTOR LOAD DATA")
            //loadingSubject.send(true)
            subscription = worker.getUnits()
                .receive(on: DispatchQueue.global())
                .sink(receiveCompletion: { [weak self] (result) in
                    //self.loadingSubject.send(false)
                    switch result {
                    case .failure(_):
                        //self.sendFakeData()
                        self?.dataSubject.send(completion: result)
                    default:
                        print("-- Profile Interactor: load data finished")
                        break
                    }
                }, receiveValue: { [weak self] data in
                    sleep(2)
                    self?.dataSubject.send(data)
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
            
            //loadingSubject.send(true)
            subscription = worker.attack(attackData)
                .receive(on: DispatchQueue.global())
                .sink(receiveCompletion: { [weak self] (result) in
                    //self?.loadingSubject.send(false)
                    switch result {
                    case .failure(_):
                        //self.sendFakeData()
                        self?.attackSentSubject.send(completion: result)
                    default:
                        print("-- Profile Interactor: load data finished")
                        break
                    }
                }, receiveValue: { [weak self] data in
                    self?.attackSentSubject.send(data)
                })
            
        }
        
    }
    
}
