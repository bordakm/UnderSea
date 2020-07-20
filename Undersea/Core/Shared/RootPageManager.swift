//
//  RootPageManager.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 15..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

class RootPageManager : ObservableObject {
    
    @Published var currentPage = RootPage.login
    private var subscription: AnyCancellable?
    
    private init() {
        
        subscription = UserManager.shared.loggedInUser
            .receive(on: DispatchQueue.main)
            .sink(receiveValue: { (data) in
                if data == nil {
                    self.currentPage = .login
                } else if self.currentPage == .login {
                    self.currentPage = .main
                }
            })
        
    }
    
    static let shared: RootPageManager = RootPageManager()
    
}
