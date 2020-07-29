//
//  Attack.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 09..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import SwiftUI

struct Attack {
    
    typealias DataModelType = [AttackPageDTO]
    typealias ViewModelType = ViewModel
    
    static func setup() -> AttackPage {
        
        let interactor = Interactor()
        let presenter = Presenter()
        
        var view = AttackPage(viewModel: presenter.viewModel, usecaseHandler: interactor.handleUsecase(_:))
        
        interactor.setPresenter = { return presenter }
        
        presenter.bind(dataListSubject: interactor.dataSubject.eraseToAnyPublisher())
        presenter.bind(loadingSubject: interactor.loadingSubject.eraseToAnyPublisher())
        
        view.setInteractor = { return interactor }
        
        return view
        
    }
    
}
