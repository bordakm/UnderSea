//
//  CityPage.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 09..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

struct CityPage: View {
    var body: some View {
        NavigationView {
            Text("City page").navigationBarTitle("City", displayMode: .inline)
        }
    }
}

struct CityPage_Previews: PreviewProvider {
    static var previews: some View {
        CityPage()
    }
}
