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
                        self.viewModel.set(alertMessage: error.localizedDescription)
                    default:
                        print("-- Presenter: finished")
                        break
                    }
                    
                }, receiveValue: { (data) in

                    self.populateViewModel(dataModel: data)
                    
                })
            
        }
        
        /*func bind(loadingSubject: AnyPublisher<Bool, Never>) {
            subscriptions[.nextPageLoading] = loadingSubject
                .receive(on: DispatchQueue.main)
                .sink(receiveValue: { [weak self] (isLoading) in
                    self?.viewModel.isLoading = isLoading
                })
        }*/
        
        private func populateViewModel(dataModel: DataModelType?) {
            
            guard let dataModel = dataModel
                else {
                    return
            }
            
            let animalList = dataModel.map { animal in
                return AnimalViewModel(name: animal.name, available: Double(animal.availableCount))
            }
            
            self.viewModel.set(animalList: animalList)
            
        }
        
    }
    
}
