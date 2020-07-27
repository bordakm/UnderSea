//
//  City.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 09..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import SwiftUI

struct City {
    
    typealias ViewModelType = ViewModel
    
    static func setup() -> CityPage {
        
        let interactor = Interactor()
        let presenter = Presenter()
        
        var view = CityPage(viewModel: presenter.viewModel, usecaseHandler: interactor.handleUsecase(_:))
        
        interactor.setPresenter = { return presenter }
        
        presenter.bind(buildingDataSubject: interactor.buildingDataSubject.eraseToAnyPublisher())
        presenter.bind(buyBuildingDataSubject: interactor.buyBuildingDataSubject.eraseToAnyPublisher())
        
        presenter.bind(upgradeDataSubject: interactor.upgradeDataSubject.eraseToAnyPublisher())
        presenter.bind(buyUpgradeDataSubject: interactor.buyUpgradeDataSubject.eraseToAnyPublisher())
        
        presenter.bind(armyDataSubject: interactor.armyDataSubject.eraseToAnyPublisher(), buyUnitDataSubject: interactor.buyUnitDataSubject.eraseToAnyPublisher())
        
        
        view.setInteractor = { return interactor }
        
        return view
        
    }
    
}
