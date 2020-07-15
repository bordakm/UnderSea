//
//  RootPageManager.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 15..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

class RootPageManager : ObservableObject {
    
    @Published var currentPage = RootPage.login
    
    private init() {}
    
    static let shared: RootPageManager = RootPageManager()
    
}
