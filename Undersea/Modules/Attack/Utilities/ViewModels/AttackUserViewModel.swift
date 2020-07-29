//
//  AttackPageViewModel.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 15..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

extension Attack {

    struct UserViewModel: Identifiable {
        
        let id: Int
        let place: Int
        let userName: String
        
    }

}

extension Attack.UserViewModel {
    
    init?(data: DTOProtocol) {
        
        if let data = data as? AttackPageDTO {
            self.init(id: data.id, place: data.place, userName: data.userName)
        } else {
            return nil
        }
        
    }
    
}
