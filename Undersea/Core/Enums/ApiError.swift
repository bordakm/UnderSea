//
//  ApiError.swift
//  CleanTemplate
//
//  Created by Horti Tamás on 2020. 06. 30..
//  Copyright © 2020. Horti Tamás. All rights reserved.
//

import Foundation

enum ApiError: Error {
    case other(_ code: Int, _ message: String?)
}

extension ApiError: LocalizedError {
    
    var errorDescription: String? {
        switch self {
        case .other(_, let message):
            return message
        }
    }

    var failureReason: String? {
        switch self {
        case .other(let code, let message):
            return String(format: "HTTP error: %d - %@", code, message ?? "")
        }
    }
    
}
