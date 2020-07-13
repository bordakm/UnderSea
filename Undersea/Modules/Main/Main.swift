//
//  Main.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 09..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import SwiftUI

struct Main {
    
    typealias DataModelType = MainPageDTO
    typealias ViewModelType = String
    
    static func setup() -> MainPage {
        
        let Interactor = Interactor()
        let Presenter = Presenter()
        
        var test = ApiWorker().getMain()
        return MainPage()
    }
    
}
