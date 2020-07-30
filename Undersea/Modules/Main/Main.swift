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
    typealias ViewModelType = ViewModel
    
    static func setup() -> MainPage {
        
        let interactor = Interactor()
        let presenter = Presenter()
        
        var view = MainPage(viewModel: presenter.viewModel, usecaseHandler: interactor.handleUsecase(_:))
        
        interactor.setPresenter = { return presenter }
        
        presenter.bind(dataSubject: interactor.dataSubject.eraseToAnyPublisher())
        presenter.bind(loadingSubject: interactor.loadingSubject.eraseToAnyPublisher())
        
        view.setInteractor = { return interactor }
        
        return view
        
    }
    
}
