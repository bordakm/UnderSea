//
//  MainApiWorker.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 13..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

extension Main {
 
    class ApiWorker: BaseApiWorker<ApiService> {
        
        func getMain() -> AnyPublisher<MainPageDTO, Error> {
            return execute(target: .getMain)
        }
        
    }

}
