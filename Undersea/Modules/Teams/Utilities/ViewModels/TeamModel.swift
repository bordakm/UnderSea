//
//  TeamModel.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 22..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

extension Teams {
    
    struct TeamModel: Identifiable {
        
        let id = UUID()
        let name: String
        let units: [String]
        
    }
    
}

extension Teams.TeamModel {
    
    init?(data: DTOProtocol) {
        
        if let data = data as? TeamsPageDTO {
            
            self.init(name: data.countryName, units: data.units.map { unit in
                return "\(unit.count) \(unit.name)"
            })
            
        } else {
            return nil
        }
        
    }
    
}
