//
//  Login.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 08..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import SwiftUI

struct Login {
    
    typealias DataModelType = TokenDTO
    typealias ViewModelType = ViewModel
    
    static func setup() -> LoginPage {
        
        let interactor = Interactor()
        let presenter = Presenter()
        
        var view = LoginPage(viewModel: presenter.viewModel, usecaseHandler: interactor.handleUsecase(_:))
        
        interactor.setPresenter = { return presenter }
        
        presenter.bind(loadingSubject: interactor.loadingSubject.eraseToAnyPublisher())
        presenter.bind(dataSubject: interactor.dataSubject.eraseToAnyPublisher())
        
        view.setInteractor = { return interactor }
        
        return view;
    }
    
}

