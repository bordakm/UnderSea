//
//  UserManager.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 15..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine
import KeychainAccess
import SwiftJWT

class UserManager {
    
    let loggedInUser = CurrentValueSubject<UserDTO?, Never>(nil)
    private let worker = BaseApiWorker<UserManager.ApiService>()
    private var subscription: AnyCancellable?
    
    private(set) var accessToken: JWT<UnderseaClaim>?
    //private var date: Date = Date().addingTimeInterval(-3600000000)
    
    static let shared: UserManager = UserManager()
    private init() {}
    
    func login(_ data: LoginDTO) -> AnyPublisher<UserDTO, Error> {
        
        let publisher: AnyPublisher<UserDTO, Error> = worker.execute(target: .login(data))
        
        subscription = publisher
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
                
                guard let accessToken: JWT<UnderseaClaim> = try? JWT(jwtString: data.accessToken) else {
                    print("Access token decode failure")
                    return
                }
                
                print(data)
                
                self.accessToken = accessToken
                //self.date = accessToken.claims.exp
                //print(self.date)
                let keychain = Keychain(service: "hu.encosoft.Undersea")
                keychain["accessToken"] = data.accessToken
                keychain["refreshToken"] = data.refreshToken
                
                self.loggedInUser.send(data)
            
            })
        
        return publisher
        
    }
    
    func register(_ data: RegisterDTO) -> AnyPublisher<UserDTO, Error> {
        
        let publisher: AnyPublisher<UserDTO, Error> = worker.execute(target: .register(data))
        
        subscription = publisher
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
        
        return publisher
        
    }
    
    func logout() {
        
        let _: AnyPublisher<EmptyResponse, Error> = worker.execute(target: .logout)
        loggedInUser.send(nil)
        
    }
    
    func updateToken() {
        
        let data = RenewDTO(refreshToken: loggedInUser.value?.refreshToken ?? "")
        subscription = worker.execute(target: .renew(data))
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
                
                guard let accessToken: JWT<UnderseaClaim> = try? JWT(jwtString: data.accessToken) else {
                    self.loggedInUser.send(nil)
                    print("Access token decode failure")
                    return
                }
                
                print(data)
                
                self.accessToken = accessToken
                let keychain = Keychain(service: "hu.encosoft.Undersea")
                keychain["accessToken"] = data.accessToken
                keychain["refreshToken"] = data.refreshToken
                
                self.loggedInUser.send(data)
            
            })
        
    }
    
}
