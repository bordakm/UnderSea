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
    
    static var loadCount = 1
    
    static func setup(defenderId: Int?) -> AttackDetailPage {
        
        let interactor = AttackDetailInteractor(defenderId: defenderId)
        let presenter = AttackDetailPresenter()
        
        var view = AttackDetailPage(viewModel: presenter.viewModel, usecaseHandler: interactor.handleUsecase(_:))
        
        loadCount += 1
        print("-- DETAIL VIEW \(loadCount): \(view)")
        
        interactor.setPresenter = { return presenter }
        
        presenter.bind(loadingSubject: interactor.loadingSubject.eraseToAnyPublisher())
        presenter.bind(dataListSubject: interactor.dataSubject.eraseToAnyPublisher())
        presenter.bind(attackSentSubject: interactor.attackSentSubject.eraseToAnyPublisher())
        
        view.setInteractor = { return interactor }
        
        return view

    }
    
}
