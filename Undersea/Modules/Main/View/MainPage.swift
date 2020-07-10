//
//  MainPage.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 09..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

struct MainPage: View {
    var body: some View {
        NavigationView {
            Text("Main page")
                .navigationBarTitle("Main", displayMode: .inline).navigationBarColor(Colors.navBarTintColor)
        }
    }
}

struct MainPage_Previews: PreviewProvider {
    static var previews: some View {
        MainPage()
    }
}
