//
//  UpgradeModel+Extension.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 28..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import CocoaLumberjack

extension Upgrades.UpgradeModel {
    
    init(upgradeData: UpgradeDTO) {
        self.id = upgradeData.id
        self.name = upgradeData.name
        self.description = upgradeData.description
        self.remainingRounds = upgradeData.remainingRounds
        self.isPurchased = upgradeData.isPurchased
        switch upgradeData.id {
        case 1:
            self.imageName = R.image.alchemy_upgrade.name
        case 2:
            self.imageName = R.image.coralWall_upgrade.name
        case 3:
            self.imageName = R.image.mudHarvester_upgrade.name
        case 4:
            self.imageName = R.image.mudTractor_upgrade.name
        case 5:
            self.imageName = R.image.sonarCannon_upgrade.name
        case 6:
            self.imageName = R.image.fighting_upgrade.name
        default:
            DDLogDebug("Unknown upgrade id \(upgradeData.id)")
            self.imageName = ""
        }
    }
    
    init?(data: DTOProtocol) {
        
        if let upgradeData = data as? UpgradeDTO {
            self.init(upgradeData: upgradeData)
        } else {
            return nil
        }
        
    }
    
}
