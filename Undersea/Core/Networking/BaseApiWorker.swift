//
//  BaseApiWorker.swift
//  CleanTemplate
//
//  Created by Horti Tamás on 2020. 06. 30..
//  Copyright © 2020. Horti Tamás. All rights reserved.
//

import Foundation
import Moya
import Combine

protocol ApiWorkerProtocol {
    associatedtype ApiServiceType: TargetType
    
    var provider: MoyaProvider<ApiServiceType> { get }
}

class BaseApiWorker<ApiServiceType: TargetType>: ApiWorkerProtocol {
    
    // MARK: - Properties
    
    internal let provider: MoyaProvider<ApiServiceType> = ServerProxy.getProvider()
    internal var subscriptions: Set<AnyCancellable> = []
    
    // MARK: - Functions
    
    func execute<ResponseType: Decodable>(target: ApiServiceType) -> AnyPublisher<ResponseType, Error> {
        cancelActiveRequests()
        
        return Future<ResponseType, Error> { promise in
            self.provider.request(target) { (result: Result<Response, MoyaError>) in
                sleep(5)
                switch result {
                    case let .success(response):
                        if (200..<300).contains(response.statusCode) {
                            do {
                                let decoder = JSONDecoder()
                                let result = try decoder.decode(ResponseType.self, from: response.data)
                                promise(.success(result))
                            } catch {
                                promise(.failure(error))
                            }
                        } else {
                            promise(.failure(ApiError.other(response.statusCode, String(data: response.data, encoding: .utf8))))
                        }
                    case let .failure(error):
                        promise(.failure(error))
                }
            }
        }
        .eraseToAnyPublisher()
    }
    
    internal func cancelActiveRequests() {
        subscriptions.forEach { (subscription) in
            subscription.cancel()
        }
    }
}
