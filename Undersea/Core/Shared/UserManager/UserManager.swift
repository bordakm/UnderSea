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
import CocoaLumberjack

class UserManager {
    
    // MARK: - Properties
    
    let loggedInUser = CurrentValueSubject<TokenDTO?, Never>(nil)
    
    private(set) var refreshSubject: PassthroughSubject<TokenDTO, Error>?
    private let worker = BaseApiWorker<UserManager.ApiService>()
    private var subscription: AnyCancellable?
    
    // MARK: - Shared
    
    static let shared: UserManager = UserManager()
    
    private init() {}
    
    // MARK: - API Functions
    
    func login(_ data: LoginDTO) -> AnyPublisher<TokenDTO, Error> {
        
        let publisher: AnyPublisher<TokenDTO, Error> = worker.execute(target: .login(data))
        
        subscription = publisher
            .receive(on: DispatchQueue.global())
            .sink(receiveCompletion: { (result) in
                switch result {
                case .failure(_):
                    self.invalidateTokens()
                default:
                    print("-- UserManager: load data finished")
                    break
                }
            }, receiveValue: { (data: TokenDTO) in
                
                self.loggedInUser.send(data)
                self.setKeychainTokens(data)
            
            })
        
        return publisher
        
    }
    
    func register(_ data: RegisterDTO) -> AnyPublisher<TokenDTO, Error> {
        
        let publisher: AnyPublisher<TokenDTO, Error> = worker.execute(target: .register(data))
        
        subscription = publisher
            .receive(on: DispatchQueue.global())
            .sink(receiveCompletion: { (result) in
                switch result {
                case .failure(_):
                    self.invalidateTokens()
                default:
                    print("-- UserManager: load data finished")
                    break
                }
            }, receiveValue: { (data: TokenDTO) in
                
                self.loggedInUser.send(data)
                self.setKeychainTokens(data)
                
            })
        
        return publisher
        
    }
    
    func logout() {
        
        let _: AnyPublisher<EmptyResponse, Error> = worker.execute(target: .logout)
        self.invalidateTokens()
        
    }
    
    func updateToken() {
        
        let data = RenewDTO(refreshToken: loggedInUser.value?.refreshToken ?? "")
        refreshSubject = PassthroughSubject()
        subscription = worker.directExecute(target: .renew(data))
            .receive(on: DispatchQueue.global())
            .sink(receiveCompletion: { (result) in
                switch result {
                case .failure(_):
                    self.invalidateTokens()
                default:
                    print("-- UserManager: load data finished")
                    break
                }
                
                self.refreshSubject?.send(completion: result)
                self.refreshSubject = nil
                
            }, receiveValue: { (data: TokenDTO) in
                
                self.setKeychainTokens(data)
                self.loggedInUser.send(data)
                self.refreshSubject?.send(data)
            
            })
        
    }
    
    // MARK: - Helper Functions
    
    func autoLogin() {
        
        let keychain = Keychain(service: KeychainKeys.serviceKey.rawValue)
        
        guard
            let accessToken = keychain[KeychainKeys.accessToken.rawValue],
            let refreshToken = keychain[KeychainKeys.refreshToken.rawValue]
            else {
                return
        }
        
        do {
            let tokenData = try TokenDTO(refreshToken, accessToken)
            if tokenData.isExpired {
                loggedInUser.send(tokenData)
            } else {
                updateToken()
            }
        } catch {
            DDLogDebug("Invalid access token format")
            invalidateTokens()
        }
        
    }
    
    func isExpired() -> Bool {
        
        return loggedInUser.value?.isExpired ?? false
        
    }
    
    // MARK: - Private Functions
    
    private func invalidateTokens() {
        
        loggedInUser.send(nil)
        setKeychainTokens(nil)
        
    }
    
    private func setKeychainTokens(_ data: TokenDTO?) {
        
        let keychain = Keychain(service: KeychainKeys.serviceKey.rawValue)
        keychain[KeychainKeys.accessToken.rawValue] = data?.accessToken
        keychain[KeychainKeys.refreshToken.rawValue] = data?.refreshToken
        
    }
    
}

// MARK: - Constants
extension UserManager {
    
    enum KeychainKeys: String {
        
        case serviceKey = "hu.encosoft.Undersea"
        case accessToken
        case refreshToken
        
    }
    
}
