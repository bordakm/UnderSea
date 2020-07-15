//
//  LoginUsecases.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 15..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

extension Register {
    
    enum Usecase {
        case register(_ username: String, _ countryName: String, _ password: String)
    }
    
}
