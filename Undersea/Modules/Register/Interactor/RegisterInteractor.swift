//
//  RegisterInteractor.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 15..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

extension Register {
    
    class Interactor {
        
        private lazy var presenter: Presenter = setPresenter()
        var setPresenter: (() -> Presenter)!
        
        let dataSubject = CurrentValueSubject<DataModelType?, Error>(nil)
        private var subscription: AnyCancellable?
     
        func handleUsecase(_ event: Register.Usecase) {
            
            switch event {
            case .register(let username,let countryName, let password):
                register(RegisterDTO(userName: username, countryName: countryName, password: password))
            }
            
        }
        
        private func register(_ data: RegisterDTO) {
            
            subscription = UserManager.shared.register(data)
                .receive(on: DispatchQueue.global())
                .sink(receiveCompletion: { (result) in
                    switch result {
                    case .failure(_):
                        self.dataSubject.send(completion: result)
                    default:
                        print("-- Interactor: load data finished")
                        break
                    }
                }, receiveValue: { (data) in
                    self.dataSubject.send(data)
                })
            
        }
        
    }
    
}
