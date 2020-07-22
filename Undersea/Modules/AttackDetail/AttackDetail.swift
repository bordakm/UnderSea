//
//  AttackDetail.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 22..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

struct AttackDetail {
    
    typealias DataModelType = [AttackDetailPageDTO]
    typealias ViewModelType = ViewModel
    
    static func setup() -> AttackDetailPage {
        
        let interactor = Interactor()
        let presenter = Presenter()
        
        var view = AttackDetailPage(viewModel: presenter.viewModel, usecaseHandler: interactor.handleUsecase(_:))
        
        interactor.setPresenter = { return presenter }
        
        presenter.bind(dataSubject: interactor.dataSubject.eraseToAnyPublisher())
        //presenter.bind(loadingSubject: interactor.loadingSubject.eraseToAnyPublisher())
        
        view.setInteractor = { return interactor }
        
        return view
        
        
    }
    
}
