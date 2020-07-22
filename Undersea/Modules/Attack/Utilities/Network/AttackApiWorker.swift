//
//  MainApiWorker.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 15..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

extension Attack {
 
    class ApiWorker: BaseApiWorker<ApiService> {
        
        func getAttack(_ userName: String? = nil, page: Int = 1) -> AnyPublisher<[AttackPageDTO], Error> {
            return execute(target: .getAttack(userName, page: page))
        }
        
    }
    
}
