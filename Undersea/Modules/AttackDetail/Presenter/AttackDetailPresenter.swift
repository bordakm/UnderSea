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
    
    class Presenter {
        
        private var subscriptions: [AttackDetail.Event: AnyCancellable] = [:]
        
        private(set) var viewModel: ViewModelType = ViewModelType()
        
        func bind(dataSubject: AnyPublisher<DataModelType?, Error>) {
         
            subscriptions[.dataLoaded] = dataSubject
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
        
        func bind(attackSentSubject: AnyPublisher<[SendAttackResponseDTO]?, Error>) {
         
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
        
        private func populateViewModel(dataModel: DataModelType?) {
            
            guard let dataModel = dataModel else {
                return
            }
            
            var animalList: [AnimalViewModel] = []
            for animal in dataModel {
                
                switch animal.id {
                case 1:
                    animalList.append(AnimalViewModel(id: animal.id, name: animal.name, imageName: "shark", available: Double(animal.availableCount)))
                case 2:
                    animalList.append(AnimalViewModel(id: animal.id, name: animal.name, imageName: "seal", available: Double(animal.availableCount)))
                case 3:
                    animalList.append(AnimalViewModel(id: animal.id, name: animal.name, imageName: "seahorse", available: Double(animal.availableCount)))
                default:
                    DDLogDebug("Unknown unit id \(animal.id)")
                }
                
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
