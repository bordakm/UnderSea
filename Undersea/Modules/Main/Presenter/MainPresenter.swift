//
//  MainPresenter.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 13..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine
import CocoaLumberjack

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
            
            var statList: [StatusBarItem] = []
            
            for unit in dtoStatBar.units {
                switch unit.id {
                case 1:
                    statList.append(.shark(unit.availableCount, unit.allCount))
                case 2:
                    statList.append(.seal(unit.availableCount, unit.allCount))
                case 3:
                    statList.append(.seahorse(unit.availableCount, unit.allCount))
                default:
                    DDLogDebug("Unknown unit id \(unit.id)")
                }
            }
            
            statList.append(.pearl(resources.pearlCount, resources.pearlProductionCount))
            statList.append(.coral(resources.coralCount, resources.coralProductionCount))
            
            for building in dtoStatBar.buildings {
                switch building.typeId {
                case 1:
                    statList.append(.reefcastle(building.count))
                case 2:
                    statList.append(.flowRegulator(building.count))
                default:
                    DDLogDebug("Unknown building id \(building.typeId)")
                }
            }
            
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

