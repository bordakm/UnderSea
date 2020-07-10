//
//  RegisterPage.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 08..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

struct RegisterPage: View {
    
    @State private var userName: String = ""
    @State private var password: String = ""
    @State private var passwordRepeat: String = ""
    @State private var cityName: String = ""
    @State private var pushLogin = false
    
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
                SeaInputField(placeholder: "Jelszo", inputText: $password)
                SeaInputField(placeholder: "Jelszo megerositese", inputText: $passwordRepeat)
                SeaInputField(placeholder: "A varosod neve, amit epitesz", inputText: $cityName)
                
                SeaButton(title: "Regisztracio", action: {
                    print("Btn clicked")
                })
                
                //NavigationLink(destination: Login.setup(), isActive: $pushLogin) {
                    
                    Button(action: {
                        //self.pushLogin.toggle()
                        //SceneDelegate.setCurrentPage(newPage: RootPage.login)
                        ObservableRootPage.shared.currentPage = RootPage.login
                    }) {
                        Text("Belepes")
                            .font(Font.custom("Baloo2-Regular", size: 16))
                            .foregroundColor(Colors.loginBtnTextColor)
                    }
                    
                //}
            
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
    }
}

struct RegisterPage_Previews: PreviewProvider {
    static var previews: some View {
        RegisterPage()
    }
}
