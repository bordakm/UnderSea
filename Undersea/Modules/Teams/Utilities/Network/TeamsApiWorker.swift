//
//  TeamsApiWorker.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 22..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

extension Teams {
 
    class ApiWorker: BaseApiWorker<ApiService> {
        
        func getTeams() -> AnyPublisher<[TeamsPageDTO], Error> {
            return execute(target: .getTeams)
        }
        
    }

}
