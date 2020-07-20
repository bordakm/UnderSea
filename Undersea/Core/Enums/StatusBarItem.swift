//
//  StatusBarItem.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 13..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

enum StatusBarItem {
    
    case shark(Int, Int)
    case seal(Int, Int)
    case seahorse(Int, Int)
    case pearl(Int, Int)
    case coral(Int, Int)
    case reefcastle(Int)
    case flowRegulator(Int)
    
}

extension StatusBarItem {
    
    var id: Int {
        switch self {
        case .shark:
            return 1
        case .seal:
            return 2
        case .seahorse:
            return 3
        case .pearl:
            return 0
        case .coral:
            return 0
        case .reefcastle:
            return 1
        case .flowRegulator:
            return 2
        }
    }
    
    var imageName: String {
        
        switch self {
        case .shark:
            return "shark"
        case .seal:
            return "seal"
        case .seahorse:
            return "seahorse"
        case .pearl:
            return "pearl"
        case .coral:
            return "coral"
        case .reefcastle:
            return "reefcastle"
        case .flowRegulator:
            return "flowRegulator"
        }
        
    }
    
    var label: String {
        
        switch self {
            
        case .shark(let p1, let p2):
            return "\(p1)/\(p2)"
        case .seal(let p1, let p2):
            return "\(p1)/\(p2)"
        case .seahorse(let p1, let p2):
            return "\(p1)/\(p2)"
        case .pearl(let p1, let p2):
            return "\(p1)\n\(p2)/kör"
        case .coral(let p1, let p2):
            return "\(p1)\n\(p2)/kör"
        case .reefcastle(let p):
            return "\(p)"
        case .flowRegulator(let p):
            return "\(p)"
        }
        
    }
    
}
