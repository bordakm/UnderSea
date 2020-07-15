//
//  AttackInteractor.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 15..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

extension Attack {
    
    class Interactor {
        
        private lazy var presenter: Presenter = setPresenter()
        var setPresenter: (() -> Presenter)!
        
        private let worker = Attack.ApiWorker()
        let dataSubject = CurrentValueSubject<DataModelType?, Error>(nil)
        private var subscription: AnyCancellable?
     
        func handleUsecase(_ event: Attack.Usecase) {
            
            switch event {
            case .load:
                loadData()
            }
            
        }
        
        private func loadData() {
            
            subscription = worker.getAttack()
                .receive(on: DispatchQueue.global())
                .sink(receiveCompletion: { (result) in
                    switch result {
                    case .failure(_):
                        self.sendTestData()
                        self.dataSubject.send(completion: result)
                    default:
                        print("-- Interactor: load data finished")
                        break
                    }
                }, receiveValue: { data in
                    self.dataSubject.send(data)
                })
            
        }
        
        private func sendTestData() {
            
            var users: [AttackPageDTO.User] = []
            
            for i in 0 ..< 10 {
                users.append(AttackPageDTO.User(id: i, name: "User\(i)"))
            }
            
            self.dataSubject.send(AttackPageDTO(users: users))
            
        }
        
    }
    
}
