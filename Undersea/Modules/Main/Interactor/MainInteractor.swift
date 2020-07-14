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
        
        private lazy var presenter: Presenter = setPresenter()
        var setPresenter: (() -> Presenter)!
        
        private let worker = Main.ApiWorker()
        let dataSubject = CurrentValueSubject<DataModelType?, Error>(nil)
        private var subscription: AnyCancellable?
     
        func handleUsecase(_ event: Main.Usecase) {
            
            switch event {
            case .load:
                loadData()
            }
            
        }
        
        private func loadData() {
            
            subscription = worker.getMain()
                .receive(on: DispatchQueue.global())
                .sink(receiveCompletion: { (result) in
                    switch result {
                    case .failure(_):
                        self.sendTestData()
                        self.dataSubject.send(completion: result)
                    default:
                        print("-- Interactor: load data finished")
                        break
                    }
                }, receiveValue: { data in
                    self.dataSubject.send(data)
                })
            
        }
        
        private func sendTestData() {
            
            let resources = MainPageDTO.StatusBarDTO.ResourcesDTO(pearlCount: 230, pearlProductionCount: 3886, coralCount: 230, coralProductionCount: 12)
            
            let structures = MainPageDTO.StructuresDTO(flowManager: true, reefCastle: true, mudTractor: false, mudHarvester: false, coralWall: false, sonarCannon: false, underwaterMartialArts: false, alchemy: false)
            
            let statusBar = MainPageDTO.StatusBarDTO(combatSeaHorseCount: 5, laserSharkCount: 0, stromSealCount: 5, flowManagerCount: 0, reefCastleCount: 1, roundCount: 4, scoreboardPosition: 23, resources: resources)
            
            let testData: DataModelType = MainPageDTO(statusBar: statusBar, countryName: "Teszt varos", structures: structures)
            
            dataSubject.send(testData)
            
        }
        
    }
    
}
