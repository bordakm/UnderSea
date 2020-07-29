//
//  ProfilePageViewModel.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 21..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

struct ProfilePageViewModel {
    
    var userName: String
    var cityName: String
    
}

extension ProfilePageViewModel {
    
    init?(data: DTOProtocol) {
        
        if let dataModel = data as? ProfilePageDTO {
            self.init(userName: dataModel.userName, cityName: dataModel.countryName)
        } else {
            return nil
        }

    }
    
}
