//
//  AttackPageViewModel.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 15..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

struct AttackPageViewModel {
    
    let users: [User]
    
}

extension AttackPageViewModel {
    
    struct User: Identifiable {
        
        let id: Int
        let name: String
        
    }
    
}
