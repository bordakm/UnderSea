//
//  UserManager.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 15..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

class UserManager {
    
    let loggedInUser = CurrentValueSubject<UserDTO?, Never>(nil)
    private let worker = BaseApiWorker<UserManager.ApiService>()
    private var subscription: AnyCancellable?
    
    static let shared: UserManager = UserManager()
    private init() {}
    
    func login(_ data: LoginDTO) {
        
        subscription = worker.execute(target: .login(data))
            .receive(on: DispatchQueue.global())
            .sink(receiveCompletion: { (result) in
                switch result {
                case .failure(_):
                    self.loggedInUser.send(nil)
                default:
                    print("-- UserManager: load data finished")
                    break
                }
            }, receiveValue: { (data: UserDTO) in
                self.loggedInUser.send(data)
            })
        
    }
    
    func register(_ data: RegisterDTO) {
        
        subscription = worker.execute(target: .register(data))
            .receive(on: DispatchQueue.global())
            .sink(receiveCompletion: { (result) in
                switch result {
                case .failure(_):
                    self.loggedInUser.send(nil)
                default:
                    print("-- UserManager: load data finished")
                    break
                }
            }, receiveValue: { (data: UserDTO) in
                self.loggedInUser.send(data)
            })
        
    }
    
}
