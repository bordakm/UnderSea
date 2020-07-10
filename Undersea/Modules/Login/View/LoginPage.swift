//
//  LoginPage.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 08..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

struct LoginPage: View {
    
    @State private var userName: String = ""
    @State private var userPassword: String = ""
    @State private var pushRegister = false
    
    var body: some View {
        VStack {
            VStack(spacing: 0) {
                Rectangle().frame(height: 10)
                Text("UNDERSEA")
                    .font(Font.custom("Baloo2-Regular", size: 37))
                    .foregroundColor(Colors.underseaTitleColor)
            }
            VStack {
                
                Text("Belepes")
                    .font(Font.custom("Baloo2-Regular", size: 20))
                    .foregroundColor(Colors.loginTitleColor)
                
                SeaInputField(placeholder: "Felhasznalonev", inputText: $userName)
                SeaInputField(placeholder: "Jelszo", inputText: $userPassword)
                
                SeaButton(title: "Belepes", action: {
                    ObservableRootPage.shared.currentPage = RootPage.main
                })
                    
                Button(action: {
                    ObservableRootPage.shared.currentPage = RootPage.register
                }) {
                    Text("Regisztracio")
                        .font(Font.custom("Baloo2-Regular", size: 16))
                        .foregroundColor(Colors.loginBtnTextColor)
                }
                
            }
            .padding()
            .background(Color(Color.RGBColorSpace.sRGB, white: 1.0, opacity: 0.65))
            .cornerRadius(16.0)
            Spacer()
        }
        /*.navigationBarTitle("")
        .navigationBarHidden(true)*/
        //.statusBar(hidden: true)
        .background(Colors.darkBlue)
        .edgesIgnoringSafeArea(.vertical)
    }
}

struct LoginPage_Previews: PreviewProvider {
    static var previews: some View {
        LoginPage()
    }
}
