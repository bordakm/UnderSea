//
//  ProfileApiWorker.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 21..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

extension Profile {
 
    class ApiWorker: BaseApiWorker<ApiService> {
        
        func getProfile() -> AnyPublisher<ProfilePageDTO, Error> {
            return execute(target: .getProfile)
        }
        
    }

}
