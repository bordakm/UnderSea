//
//  CityApiWorker.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 23..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

extension City {
 
    class ApiWorker: BaseApiWorker<ApiService> {
        
        func getBuildings() -> AnyPublisher<[BuildingDTO], Error> {
            return execute(target: .getBuildings)
        }
        
        func buyBuildings(data: BuyBuildingDTO) -> AnyPublisher<BuildingDTO, Error> {
            return execute(target: .buyBuilding(data))
        }
        
        func getArmy() -> AnyPublisher<[UnitDTO], Error> {
            return execute(target: .getArmy)
        }
        
        func buyUnits(data: [BuyUnitsDTO]) -> AnyPublisher<[BuyUnitsDTO], Error> {
            return execute(target: .buyUnits(data))
        }
        
    }

}
