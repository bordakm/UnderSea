//
//  View+Extension.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 10..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

//soruce: https://filipmolcik.com/navigationview-dynamic-background-color-in-swiftui/

import SwiftUI

extension View {
 
    func navigationBarColor(_ backgroundColor: UIColor?) -> some View {
        self.modifier(NavigationBarModifier(backgroundColor: backgroundColor))
    }

}
