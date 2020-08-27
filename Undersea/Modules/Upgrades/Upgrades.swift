//
//  Upgrades.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 28..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import SwiftUI

struct Upgrades {
    
    typealias DataModelType = UpgradeDTO
    typealias ViewModelType = ViewModel
    
    static func setup() -> UpgradesListView {
        
        let interactor = Interactor()
        let presenter = Presenter()
        
        var view = UpgradesListView(viewModel: presenter.viewModel, usecaseHandler: interactor.handleUsecase(_:))
        
        interactor.setPresenter = { return presenter }
        
        presenter.bind(loadingSubject: interactor.loadingSubject.eraseToAnyPublisher())
        presenter.bind(dataListSubject: interactor.dataSubject.eraseToAnyPublisher())
        presenter.bind(dataSubject: interactor.buyDataSubject.eraseToAnyPublisher())
        
        view.setInteractor = { return interactor }
        
        return view
        
    }
    
}
