//
//  AnimalViewModel.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 22..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import SwiftUI
import CocoaLumberjack

extension AttackDetail {

    struct AnimalViewModel: Identifiable {
        
        var id: Int
        var name: String
        var imageName: String
        var available: Double
        var sending: Double = 0.0
        
    }

}

extension AttackDetail.AnimalViewModel {
    
    init?(data: DTOProtocol) {
        
        if let animal = data as? AttackDetailPageDTO {
            switch animal.id {
            case 1:
                self.init(id: animal.id, name: animal.name, imageName: "shark", available: Double(animal.availableCount))
            case 2:
                self.init(id: animal.id, name: animal.name, imageName: "seal", available: Double(animal.availableCount))
            case 3:
                self.init(id: animal.id, name: animal.name, imageName: "seahorse", available: Double(animal.availableCount))
            default:
                DDLogDebug("Unknown unit id \(animal.id)")
                return nil
            }
            
        } else {
            return nil
        }
    
    }
    
}
