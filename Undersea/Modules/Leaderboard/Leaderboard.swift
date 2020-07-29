//
//  Leaderboard.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 21..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

struct Leaderboard {
    
    typealias DataModelType = [LeaderboardPageDTO]
    typealias ViewModelType = ViewModel
    
    static func setup() -> LeaderboardPage {
        
        let interactor = Interactor()
        let presenter = Presenter()
        
        var view = LeaderboardPage(viewModel: presenter.viewModel, usecaseHandler: interactor.handleUsecase(_:))
        
        interactor.setPresenter = { return presenter }
        
        presenter.bind(dataListSubject: interactor.dataSubject.eraseToAnyPublisher())
        presenter.bind(loadingSubject: interactor.loadingSubject.eraseToAnyPublisher())
        
        view.setInteractor = { return interactor }
        
        return view
        
        
    }
    
}
