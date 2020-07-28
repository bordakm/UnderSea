//
//  BuildingsApiWorker.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 28..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

extension Buildings {
 
    class ApiWorker: BaseApiWorker<ApiService> {
        
        func getBuildings() -> AnyPublisher<[BuildingDTO], Error> {
            return execute(target: .getBuildings)
        }
        
        func buyBuildings(data: BuyBuildingDTO) -> AnyPublisher<BuildingDTO, Error> {
            return execute(target: .buyBuilding(data))
        }
        
    }

}
