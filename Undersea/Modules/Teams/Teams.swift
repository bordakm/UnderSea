//
//  Teams.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 09..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import SwiftUI

struct Teams {
    
    typealias DataModelType = [TeamsPageDTO]
    typealias ViewModelType = ViewModel
    
    static func setup() -> TeamsPage {
        
        let interactor = Interactor()
        let presenter = Presenter()
        
        var view = TeamsPage(viewModel: presenter.viewModel, usecaseHandler: interactor.handleUsecase(_:))
        
        interactor.setPresenter = { return presenter }
        
        presenter.bind(dataSubject: interactor.dataSubject.eraseToAnyPublisher())
        
        view.setInteractor = { return interactor }
        
        return view
        
        
    }
    
}
