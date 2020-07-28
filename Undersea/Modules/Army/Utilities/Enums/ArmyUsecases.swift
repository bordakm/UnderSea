//
//  ArmyUsecases.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 28..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

extension Army {
    
    enum Usecase {
        case load
        case changeUnitAmount(_ id: Int, _ inc: Bool)
        case buyUnits
    }
    
}
