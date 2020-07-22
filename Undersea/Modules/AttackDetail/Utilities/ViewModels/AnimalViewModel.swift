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
        
        var id = UUID()
        var name: String
        var available: Double
        var sending: Double = 0.0
        
        var description: String {
            get {
                return "\(name): \(Int(available))/\(Int(round(sending)))"
            }
        }
        
    }

}
