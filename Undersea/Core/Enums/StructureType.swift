//
//  StructureType.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 13..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

enum StructureType {
    
    case reefcastle
    case flowRegulator
    case sonarCannon
    case alchemy
    
}

extension StructureType {
    
    var imageName: String {
        
        switch self {
        case .reefcastle:
            return "reefcastle"
        case .flowRegulator:
            return "flowManager"
        case .sonarCannon:
            return "sonarCannon"
        case .alchemy:
            return "alchemy"
        }
        
    }
    
}
