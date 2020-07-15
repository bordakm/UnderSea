//
//  Dictionary+Extension.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 15..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

extension Dictionary where Key == String, Value == Any? {
    
    func rejectNil() -> [String: Any] {
        var destination = [String: Any]()
        for (key, nillableValue) in self {
            if let value: Any = nillableValue {
                destination[key] = value
            }
        }
 
        return destination
    }
    
}
 
extension Optional where Wrapped == [String: Any?] {
    func rejectNil() -> [String: Any] {
        return (self ?? [:]).rejectNil()
    }
}
 
extension Dictionary {
    mutating func merge(dict: [Key: Value]) {
        for (key, value) in dict {
            updateValue(value, forKey: key)
        }
    }
}
