//
//  Unit+Extension.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 23..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import CocoaLumberjack

extension City.CityPageViewModel.Unit {
    
    init(unitData: UnitDTO, selected: Int) {
        self.id = unitData.id
        self.name = unitData.name
        self.price = unitData.price
        self.count = unitData.count
        self.attackScore = unitData.attackScore
        self.defenseScore = unitData.defenseScore
        self.pearlCostPerTurn = unitData.pearlCostPerTurn
        self.coralCostPerTurn = unitData.coralCostPerTurn
        switch unitData.id {
        case 1:
            self.imageURL = R.file.sharkSvg()!
        case 2:
            self.imageURL = R.file.sealSvg()!
        case 3:
            self.imageURL = R.file.seahorseSvg()!
        default:
            DDLogDebug("Unknown building id \(unitData.id)")
            self.imageURL = URL(fileURLWithPath: "")
        }
        self.selectedAmount = selected
    }
    
}
