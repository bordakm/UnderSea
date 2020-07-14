//
//  AttackPage.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 09..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

struct User : Identifiable {
    let id = UUID()
    let name: String
}

struct AttackPage: View {
    
    @State private var userName: String = ""
    @State private var userList: [User] = {
        var tmp = [User]()
        for i in 0..<10 {
            tmp.append(User(name: "User \(i)"))
        }
        print(tmp)
        return tmp
    }()
    
    var body: some View {
        NavigationView {
            VStack {
                Text("1. Lépés")
                Text("Jelöld ki, kit szeretnél megtámadni:")
                SeaInputField(placeholder: "Felhasznalonev", inputText: $userName)
                List(userList) { item in
                    Text(item.name)
                        .foregroundColor(Color.black)
                        .listRowBackground(Color.black)
                }
                .background(Colors.backgroundColor)
            }
            .navigationBarTitle("Támadás", displayMode: .inline)
            .background(Colors.backgroundColor)
            .navigationBarColor(Colors.navBarTintColor)
        }
    }
}

struct AttackPage_Previews: PreviewProvider {
    static var previews: some View {
        AttackPage()
    }
}
