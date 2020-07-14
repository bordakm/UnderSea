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
                VStack(alignment: .leading) {
                    Text("1. Lépés")
                        .font(Fonts.get(.osBold))
                        .foregroundColor(Color.white)
                    Text("Jelöld ki, kit szeretnél megtámadni:")
                        .font(Fonts.get(.osRegular))
                        .foregroundColor(Color.white)
                }
                .frame(maxWidth: .infinity, alignment: .leading)
                .padding(.top, 20.0)
                .padding(.leading, 20.0)
                SeaInputField(placeholder: "Felhasznalonev", inputText: $userName, backgroundColor: Colors.searchFieldBackground)
                    .padding(.horizontal)
                List(userList) { item in
                    NavigationLink(destination: AttackDetailPage()) {
                        Text(item.name)
                            .foregroundColor(Color.white)
                            .padding(.vertical)
                    }
                }
            }
            .navigationBarTitle("Támadás", displayMode: .inline)
            .background(Colors.backgroundColor)
            .navigationBarColor(Colors.navBarBackgroundColor)
        }
    }
}

struct AttackPage_Previews: PreviewProvider {
    static var previews: some View {
        AttackPage()
    }
}
