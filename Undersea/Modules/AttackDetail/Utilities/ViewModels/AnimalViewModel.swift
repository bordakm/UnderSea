//
//  AnimalViewModel.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 22..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import SwiftUI

extension AttackDetail {

    struct AnimalViewModel: Identifiable {
        
        var id: Int
        var name: String
        var imageName: String
        var available: Double
        var sending: Double = 0.0
        
    }

}
