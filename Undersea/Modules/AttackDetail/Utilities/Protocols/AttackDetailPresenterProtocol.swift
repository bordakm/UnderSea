//
//  AttackDetailPresenterProtocol.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 29..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

protocol AttackDetailPresenterProtocol : ListPresenterProtocol {
    func bind<S: DTOProtocol>(attackSentSubject: AnyPublisher<[S], Error>)
}
