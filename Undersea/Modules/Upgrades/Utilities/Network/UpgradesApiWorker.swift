//
//  UpgradesApiWorker.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 28..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

import Combine

extension Upgrades {
 
    class ApiWorker: BaseApiWorker<ApiService> {
        
        func getUpgrades() -> AnyPublisher<[DataModelType], Error> {
            return execute(target: .getUpgrades)
        }
        
        func buyUpgrade(data: BuyUpgradeDTO) -> AnyPublisher<DataModelType, Error> {
            return execute(target: .buyUpgrade(data))
        }
        
    }

}
