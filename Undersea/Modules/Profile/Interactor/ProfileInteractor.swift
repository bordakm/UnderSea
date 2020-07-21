//
//  ProfileInteractor.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 21..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

extension Profile {
    
    class Interactor {
        
        private lazy var presenter: Presenter = setPresenter()
        var setPresenter: (() -> Presenter)!
        
        private let worker = Profile.ApiWorker()
        let dataSubject = CurrentValueSubject<DataModelType?, Error>(nil)
        private var subscription: AnyCancellable?
     
        func handleUsecase(_ event: Profile.Usecase) {
            
            switch event {
            case .load:
                loadData()
            case .logout:
                UserManager.shared.logout()
            }
            
        }
        
        private func loadData() {
            
            subscription = worker.getProfile()
                .receive(on: DispatchQueue.global())
                .sink(receiveCompletion: { (result) in
                    switch result {
                    case .failure(_):
                        self.dataSubject.send(completion: result)
                    default:
                        print("-- Profile Interactor: load data finished")
                        break
                    }
                }, receiveValue: { data in
                    self.dataSubject.send(data)
                })
            
        }
        
    }
    
}
