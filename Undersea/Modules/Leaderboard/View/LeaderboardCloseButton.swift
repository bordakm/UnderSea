//
//  LeaderboardCloseButton.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 21..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

struct LeaderboardCloseButton: View {
    
    var action: () -> Void
    
    var body: some View {
        Button(action: action) {
            Image(systemName: Images.chevronDown.rawValue)
        }.frame(width: 40.0, height: 40.0, alignment: .center)
    }
}

/*struct LeaderboardCloseButton_Previews: PreviewProvider {
    static var previews: some View {
        LeaderboardCloseButton()
    }
}*/
