//
//  ProfilePresenter.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 21..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine
import CocoaLumberjack

extension Profile {
    
    class Presenter : DetailPresenterProtocol {
        
        private var subscriptions: [Profile.Event: AnyCancellable] = [:]
        
        private(set) var viewModel: ViewModelType = ViewModelType()
        
        //bind(dataSubject: AnyPublisher<DataModelType?, Error>)
        func bind<S>(dataSubject: AnyPublisher<S?, Error>) where S : DTOProtocol {
         
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
        
        func bind(loadingSubject: AnyPublisher<Bool, Never>) {
        }
        
        private func populateViewModel<S>(dataModel: S?) where S : DTOProtocol {
            
            guard let dataModel = dataModel else {
                return
            }
            
            guard let viewModel = ProfilePageViewModel(data: dataModel) else {
                return
            }
            
            self.viewModel.set(viewModel: viewModel)
            
        }
        
        func presentError(_ error: Error) {
            
            viewModel.errorModel = ErrorAlertModel(error: error)
            
        }
        
        func presentError(message: String) {
            
            viewModel.errorModel = ErrorAlertModel(message: message)
            
        }
        
    }
    
}
