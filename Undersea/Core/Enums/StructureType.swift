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
    
}

extension StructureType {
    
    var imageName: String {
        
        switch self {
        case .reefcastle:
            return "us_image_reefcastle"
        case .flowRegulator:
            return "us_image_flowRegulator"
        }
        
    }
    
}
