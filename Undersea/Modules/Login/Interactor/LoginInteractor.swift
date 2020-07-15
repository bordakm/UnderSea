//
//  LoginInteractor.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 15..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

extension Login {
    
    class Interactor {
        
        private lazy var presenter: Presenter = setPresenter()
        var setPresenter: (() -> Presenter)!
        
        private let worker = Attack.ApiWorker()
        let dataSubject = CurrentValueSubject<DataModelType?, Error>(nil)
        private var subscription: AnyCancellable?
     
        func handleUsecase(_ event: Login.Usecase) {
            
            switch event {
            case .login(let username, let password):
                login(LoginDTO(userName: username, password: password))
            }
            
        }
        
        private func login(_ data: LoginDTO) {
            
            subscription = UserManager.shared.login(data)
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
                }, receiveValue: { (data) in
                    self.dataSubject.send(data)
                })
            
        }
        
        private func sendTestData() {
            
            self.dataSubject.send(UserDTO(refreshToken: "", accessToken: ""))
            
        }
        
    }
    
}

