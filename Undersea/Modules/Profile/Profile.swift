//
//  Profile.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 20..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

struct Profile {
    
    typealias DataModelType = ProfilePageDTO
    typealias ViewModelType = ViewModel
    
    static func setup() -> ProfilePage {
        
        let interactor = Interactor()
        let presenter = Presenter()
        
        var view = ProfilePage(viewModel: presenter.viewModel, usecaseHandler: interactor.handleUsecase(_:))
        
        interactor.setPresenter = { return presenter }
        
        presenter.bind(loadingSubject: interactor.loadingSubject.eraseToAnyPublisher())
        presenter.bind(dataSubject: interactor.dataSubject.eraseToAnyPublisher())
        
        view.setInteractor = { return interactor }
        
        return view
        
    }
    
}
