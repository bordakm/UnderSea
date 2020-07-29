//
//  AttackDetailPresenter.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 22..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine
import CocoaLumberjack

extension AttackDetail {
    
    class Presenter : AttackDetailPresenterProtocol {
        
        private var subscriptions: [AttackDetail.Event: AnyCancellable] = [:]
        
        private(set) var viewModel: ViewModelType = ViewModelType()
        
        
        //bind(dataSubject: AnyPublisher<DataModelType?, Error>)
        func bind<S>(dataListSubject: AnyPublisher<[S], Error>) where S : DTOProtocol {
         
            subscriptions[.dataLoaded] = dataListSubject
                .receive(on: DispatchQueue.main)
                .sink(receiveCompletion: { (result) in
                    
                    switch result {
                    case .failure(let error):
                        self.presentError(error)
                    default:
                        print("-- Presenter: finished")
                        break
                    }
                    
                }, receiveValue: { (data) in

                    self.populateViewModel(dataModel: data)
                    
                })
            
        }
        
        //bind(attackSentSubject: AnyPublisher<[SendAttackResponseDTO]?, Error>)
        func bind<S>(attackSentSubject: AnyPublisher<[S], Error>) where S : DTOProtocol {
         
            subscriptions[.attackSent] = attackSentSubject
                .receive(on: DispatchQueue.main)
                .sink(receiveCompletion: { (result) in
                    
                    switch result {
                    case .failure(let error):
                        self.presentError(error)
                    default:
                        print("-- Presenter: finished")
                        break
                    }
                    
                }, receiveValue: { (data) in

                    self.viewModel.shouldPopBack.send()
                    
                })
            
        }
        
        func bind(loadingSubject: AnyPublisher<Bool, Never>) {
        }
        
        private func populateViewModel<S>(dataModel: [S]?) where S : DTOProtocol {
            
            guard let dataModel = dataModel else {
                return
            }
            
            let animalList: [AnimalViewModel] = dataModel.compactMap { animalData in
                return AnimalViewModel(data: animalData)
            }
            
            self.viewModel.set(animalList: animalList)
            
        }
        
        func presentError(_ error: Error) {
            
            viewModel.errorModel = ErrorAlertModel(error: error)
            
        }
        
        func presentError(message: String) {
            
            viewModel.errorModel = ErrorAlertModel(message: message)
            
        }
        
    }
    
}
