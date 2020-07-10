//
//  ContentView.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 07..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

struct ContentView: View {
    
    @State private var userName: String = ""
    @State private var password: String = ""
    
    var body: some View {
        VStack {
            VStack(spacing: 0) {
                Rectangle().frame(height: 10)
                Text("Undersea")
                    .font(Font.custom("Baloo2-Regular", size: 37))
            }
            VStack {
                Text("Belepes")
                TextField("Felhasznalonev", text: $userName)
                TextField("Jelszo", text: $password)
                Button(action: {}) {
                    Text("Belepes")
                }
                Button(action: {}) {
                    Text("Regisztracio")
                }
            }.padding()
            Spacer()
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
