//
//  Fonts.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 14..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import SwiftUI

enum Fonts {
    
    case osRegular
    case osBold
    case bRegular
    
}

extension Fonts {
    
    static func get(_ type: Fonts, _ size: CGFloat = 16.0) -> Font {
        
        var selectedFont: Font
        
        switch type {
        case .osRegular:
            selectedFont = Font.custom("OpenSans-Regular", size: size)
        case .osBold:
            selectedFont = Font.custom("OpenSans-Bold", size: size)
        case .bRegular:
            selectedFont = Font.custom("Baloo-Regular", size: size)
        }
        
        return selectedFont
        
    }
    
}
