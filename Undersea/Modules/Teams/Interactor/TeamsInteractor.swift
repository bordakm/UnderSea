//
//  TeamsInteractor.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 22..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

extension Teams {
    
    class Interactor {
        
        private lazy var presenter: ListPresenterProtocol = setPresenter()
        var setPresenter: (() -> ListPresenterProtocol)!
        
        private let worker = Teams.ApiWorker()
        let dataSubject = CurrentValueSubject<DataModelType, Error>(DataModelType())
        let loadingSubject = CurrentValueSubject<Bool, Never>(false)
        private var subscription: AnyCancellable?
     
        func handleUsecase(_ event: Teams.Usecase) {
            
            switch event {
            case .load:
                loadData()
            }
            
        }
        
        private func loadData() {
            
            loadingSubject.send(true)
            subscription = worker.getTeams()
                .receive(on: DispatchQueue.global())
                .sink(receiveCompletion: { (result) in
                    self.loadingSubject.send(false)
                    switch result {
                    case .failure(_):
                        self.dataSubject.send(completion: result)
                    default:
                        print("-- Profile Interactor: load data finished")
                        break
                    }
                }, receiveValue: { data in
                    sleep(2)
                    self.dataSubject.send(data)
                })
            
        }
        
    }
    
}
