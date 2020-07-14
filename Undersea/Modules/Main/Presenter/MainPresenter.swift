//
//  MainPresenter.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 13..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

extension Main {
    
    class Presenter {
        
        private var subscriptions: [Main.Event: AnyCancellable] = [:]
        
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
            
            let dtoStatBar = dataModel.statusBar
            let resources = dtoStatBar.resources
            
            let statList: [StatusBarItem] = [.shark(dtoStatBar.laserSharkCount, 5), .seal(dtoStatBar.stromSealCount, 10), .seahorse(dtoStatBar.combatSeaHorseCount, 10), .pearl(resources.pearlCount, resources.pearlProductionCount), .coral(resources.coralCount, resources.coralProductionCount), .reefcastle(dtoStatBar.reefCastleCount), .flowRegulator(dtoStatBar.flowManagerCount)]
            
            var builtStructures: Set<StructureType> = Set<StructureType>()
            
            if dataModel.structures.reefCastle {
                builtStructures.insert(.reefcastle)
            }
            
            if dataModel.structures.flowManager {
                builtStructures.insert(.flowRegulator)
            }
            
            let roundAndRank = "\(dtoStatBar.roundCount). kör\t\(dtoStatBar.scoreboardPosition). hely"
            
            self.viewModel.set(viewModel: MainPageViewModel(roundAndRank: roundAndRank, statList: statList, builtStructures: builtStructures))
            
        }
        
    }
    
}

