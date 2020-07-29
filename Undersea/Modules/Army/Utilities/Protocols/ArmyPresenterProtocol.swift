//
//  ArmyPresenterProtocol.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 29..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

protocol ArmyPresenterProtocol : PresenterProtocol {
    func bind<S, T>(dataListSubject: AnyPublisher<[S], Error>, buyDataSubject: AnyPublisher<[T], Error>) where S : DTOProtocol, T : DTOProtocol
}
