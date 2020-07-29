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
    
    static func setup(defenderId: Int) -> AttackDetailPage {
        
        let interactor = Interactor(defenderId: defenderId)
        let presenter = Presenter()
        
        var view = AttackDetailPage(viewModel: presenter.viewModel, usecaseHandler: interactor.handleUsecase(_:))
        
        interactor.setPresenter = { return presenter }
        
        presenter.bind(dataListSubject: interactor.dataSubject.eraseToAnyPublisher())
        presenter.bind(attackSentSubject: interactor.attackSentSubject.eraseToAnyPublisher())
        
        view.setInteractor = { return interactor }
        
        return view
        
        
    }
    
}
