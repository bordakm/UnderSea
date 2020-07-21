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
    
    class Presenter {
        
        private var subscriptions: [Profile.Event: AnyCancellable] = [:]
        
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
        
        private func populateViewModel(dataModel: DataModelType?) {
            
            guard let dataModel = dataModel
                else {
                    return
            }
            
            let viewModel = ProfilePageViewModel(userName: dataModel.userName, cityName: dataModel.countryName)
            
            self.viewModel.set(viewModel: viewModel)
            
        }
        
    }
    
}
