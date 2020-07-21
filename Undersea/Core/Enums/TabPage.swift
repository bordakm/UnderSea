//
//  MainPage.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 21..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import SwiftUI

enum TabPage {
    case main
    case city
    case attack
    case units
}

extension TabPage {
    
    var title: String {
        
        switch self {
        case .main:
            return "Kezdőlap"
        case .city:
            return "Városom"
        case .attack:
            return "Támadás"
        case .units:
            return "Csapataim"
        }
        
    }
    
    var imageName: String {
        
        switch self {
        case .main:
            return "main"
        case .city:
            return "city"
        case .attack:
            return "attack"
        case .units:
            return "teams"
        }
        
    }
    
    var view: AnyView {
        
        switch self {
        case .main:
            return AnyView(Main.setup())
        case .city:
            return AnyView(City.setup())
        case .attack:
            return AnyView(Attack.setup())
        case .units:
            return AnyView(Teams.setup())
        }
        
    }
    
}
