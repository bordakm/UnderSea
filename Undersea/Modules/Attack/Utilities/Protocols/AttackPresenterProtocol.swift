//
//  AttackPresenterProtocol.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 30..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

protocol AttackPresenterProtocol : ListPresenterProtocol {
    func bind(loadMoreSubject: AnyPublisher<Bool, Never>)
}
