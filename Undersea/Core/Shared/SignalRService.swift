//
//  SignalRService.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 27..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import Combine
import SwiftSignalRClient
import CocoaLumberjack

struct Signal {}

class SignalRService {
    
    private var connection: HubConnection?
    var incomingSignalSubject = PassthroughSubject<Signal, Never>()
    
    private init() {
        
        guard let url = URL(string: "http://underseat2lasttry.webtest.encosoft.internal/api/newround") else {
            DDLogDebug("-- ERROR: SignalR Service can not be initialized")
            connection = nil
            return
        }
        
        connection = HubConnectionBuilder(url: url).withLogging(minLogLevel: .error).withAutoReconnect().build()
        
        connection!.on(method: "NewRound", callback: {
            DDLogDebug("-- Incoming new round signal")
            self.incomingSignalSubject.send(Signal())
        })
        
        connection!.start()
        
    }
    
    static let shared: SignalRService = SignalRService()
    
}
