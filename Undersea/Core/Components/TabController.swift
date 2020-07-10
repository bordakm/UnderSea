//
//  TabController.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 09..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

struct TabController: View {
    
    
    
    var body: some View {
        
        TabView {
            
            Main.setup().tabItem {
                Text("Kezdolap")
            }
            
            City.setup().tabItem {
                Text("Varosom")
            }
            
            Attack.setup().tabItem {
                Text("Tamadas")
            }
            
            Teams.setup().tabItem {
                Text("Csapataim")
            }
            
        }
        .background(LinearGradient(gradient: Gradient(colors: [Colors.loginGradientStart, Colors.loginGradientMid, Colors.loginGradientEnd]), startPoint: .leading, endPoint: .trailing))
    }
}

struct TabController_Previews: PreviewProvider {
    static var previews: some View {
        TabController()
    }
}
