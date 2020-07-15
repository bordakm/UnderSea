//
//  Encodable+Extension.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 15..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

extension Encodable {
    func getDictionary() -> [String: Any] {
        do {
            let data = try JSONEncoder().encode(self)
            guard let dictionary = try JSONSerialization.jsonObject(with: data, options: .allowFragments) as? [String: Any?] else {
                throw NSError()
            }
            return dictionary.rejectNil()
        } catch {
            return [:]
        }
    }
 
    func encodeArray(withKey key: String) -> [String: Any] {
        do {
            let data = try JSONEncoder().encode(self)
            guard let array = try JSONSerialization.jsonObject(with: data, options: .allowFragments) as? [Any?] else {
                throw NSError()
            }
            return [key: array]
        } catch {
            return [:]
        }
    }
}
