//
//  PresenterProtocol.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 29..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine

protocol PresenterProtocol {

    func bind(loadingSubject: AnyPublisher<Bool, Never>)
    
}
