//
//  TeamsPage.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 09..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

struct TeamsPage: View {
    var body: some View {
        NavigationView {
            Text("Teasm page").navigationBarTitle("Teams", displayMode: .inline)
        }
    }
}

struct TeamsPage_Previews: PreviewProvider {
    static var previews: some View {
        TeamsPage()
    }
}
