//
//  ArmyApiWorker.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 28..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

extension Army {
 
    class ApiWorker: BaseApiWorker<ApiService> {
        
        func getArmy() -> AnyPublisher<[DataModelType], Error> {
            return execute(target: .getArmy)
        }
        
        func buyUnits(data: [BuyUnitsDTO]) -> AnyPublisher<[BuyUnitsDTO], Error> {
            return execute(target: .buyUnits(data))
        }
        
    }

}
