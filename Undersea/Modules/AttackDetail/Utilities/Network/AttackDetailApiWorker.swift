//
//  AttackDetailApiWorker.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 22..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

extension AttackDetail {
 
    class ApiWorker: BaseApiWorker<ApiService> {
        
        func getUnits() -> AnyPublisher<[AttackDetailPageDTO], Error> {
            return execute(target: .getUnits)
        }
        
        func attack(_ data: SendAttackDTO) -> AnyPublisher<[SendAttackResponseDTO], Error> {
            return execute(target: .attack(data))
        }
        
    }

}
