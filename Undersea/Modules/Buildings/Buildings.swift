//
//  Buildings.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 28..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import SwiftUI

struct Buildings {
    
    typealias DataModelType = BuildingDTO
    typealias ViewModelType = ViewModel
    
    static func setup() -> BuildingListView {
        
        let interactor = Interactor()
        let presenter = Presenter()
        
        var view = BuildingListView(viewModel: presenter.viewModel, usecaseHandler: interactor.handleUsecase(_:))
        
        interactor.setPresenter = { return presenter }
        
        presenter.bind(dataSubject: interactor.dataSubject.eraseToAnyPublisher())
        presenter.bind(buyDataSubject: interactor.buyDataSubject.eraseToAnyPublisher())
        
        view.setInteractor = { return interactor }
        
        return view
        
    }
    
}
