//
//  SlideInMenu.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 10..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import SwiftUI

struct SlideInMenu {
    
    static func setup(action: @escaping () -> Void) -> SlideInMenuView {
        return SlideInMenuView(action: action)
    }
    
}
