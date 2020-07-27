//
//  ErrorAlertModel.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 27..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

struct ErrorAlertModel {
    
    var title: String
    var message: String
    var alert = true
    
    init(title: String = "Hiba történt!", message: String, show: Bool = true) {

        self.title = title
        self.message = message
        self.alert = show
        
    }
    
    init(error: Error) {
        
        title = "Ismeretlen hiba történt!"
        message = "\(error.localizedDescription)"
        
        guard let errorData = error.localizedDescription.data(using: .utf8) else {
            return
        }
        
        guard let array = try? JSONSerialization.jsonObject(with: errorData, options: .mutableContainers) as? [AnyObject] else {
            return
        }
        
        guard let jsonDict = array.first as? [String: AnyObject] else {
            return
        }
        
        if let description = jsonDict["description"] {

            title = "Hiba!"
            message = "\(description)"
            
        }
        
        if let code = jsonDict["code"] {
        
            if code.isEqual(to: "PasswordTooShort") {
                message = "Túl rövid jelszó!"
            }
            
        }
        
    }
    
}
