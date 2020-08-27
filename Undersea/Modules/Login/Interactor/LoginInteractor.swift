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
        
        private lazy var presenter: DetailPresenterProtocol = setPresenter()
        var setPresenter: (() -> DetailPresenterProtocol)!
        
        let dataSubject = CurrentValueSubject<DataModelType?, Error>(nil)
        let loadingSubject = CurrentValueSubject<Bool, Never>(false)
        private var subscription: AnyCancellable?
     
        func handleUsecase(_ event: Login.Usecase) {
            
            switch event {
            case .login(let username, let password):
                login(LoginDTO(userName: username, password: password))
            }
            
        }
        
        private func login(_ data: LoginDTO) {
            
            loadingSubject.send(true)
            subscription = UserManager.shared.login(data)
                .receive(on: DispatchQueue.global())
                .sink(receiveCompletion: { (result) in
                    self.loadingSubject.send(false)
                    switch result {
                    case .failure(_):
                        self.dataSubject.send(completion: result)
                    default:
                        print("-- Interactor: load data finished")
                        break
                    }
                }, receiveValue: { (data) in
                    sleep(2)
                    self.dataSubject.send(data)
                })
            
        }
        
    }
    
}

