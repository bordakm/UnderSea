//
//  MainInteractor.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 13..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

extension Main {
    
    class Interactor {
        
        private lazy var presenter: DetailPresenterProtocol = setPresenter()
        var setPresenter: (() -> DetailPresenterProtocol)!
        
        private let worker = Main.ApiWorker()
        let dataSubject = CurrentValueSubject<DataModelType?, Error>(nil)
        let loadingSubject = CurrentValueSubject<Bool, Never>(false)
        private var subscription: AnyCancellable?
     
        func handleUsecase(_ event: Main.Usecase) {
            
            switch event {
            case .load:
                loadData()
            }
            
        }
        
        private func loadData() {
            
            loadingSubject.send(true)
            subscription = worker.getMain()
                .receive(on: DispatchQueue.global())
                .sink(receiveCompletion: { (result) in
                    self.loadingSubject.send(false)
                    switch result {
                    case .failure(_):
                        self.dataSubject.send(completion: result)
                    default:
                        print("-- Interactor: load data finished")
                        break
                    }
                }, receiveValue: { data in
                    sleep(3)
                    self.dataSubject.send(data)
                })
            
        }
        
    }
    
}
