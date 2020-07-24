//
//  CityUsecases.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 23..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

extension City {
    
    enum Usecase {
        case loadBuildings
        case buyBuilding(_ id: Int)
        case loadArmy
        case selectUnitAmount(_ id: Int, _ amount: Int)
        case buyUnits
    }
    
}
