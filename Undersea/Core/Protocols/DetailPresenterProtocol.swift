//
//  DetailPresenterProtocol.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 29..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

protocol DetailPresenterProtocol : PresenterProtocol {
    func bind<S: DTOProtocol>(dataSubject: AnyPublisher<S?, Error>)
}
