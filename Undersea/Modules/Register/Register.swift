//
//  Register.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 08..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import SwiftUI

struct Register {
    
    typealias DataModelType = UserDTO
    typealias ViewModelType = ViewModel
    
    static func setup() -> RegisterPage {
        
        let interactor = Interactor()
        let presenter = Presenter()
        
        var view = RegisterPage(usecaseHandler: interactor.handleUsecase(_:))
        
        interactor.setPresenter = { return presenter }
        
        presenter.bind(dataSubject: interactor.dataSubject.eraseToAnyPublisher())
        
        view.setInteractor = { return interactor }
        
        return view;
    }
    
}
