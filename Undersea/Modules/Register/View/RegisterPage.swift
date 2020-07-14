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
        
        GeometryReader { geometry in
            VStack {
                VStack(spacing: 0) {
                    Rectangle()
                        .fill(Colors.underseaTitleColor)
                        .frame(height: 10)
                    Text("UNDERSEA")
                        .font(Font.custom("Baloo2-Regular", size: 37))
                        .foregroundColor(Colors.underseaTitleColor)
                }
                VStack {
                    
                    Text("Belepes")
                        .font(Font.custom("Baloo2-Regular", size: 20))
                        .foregroundColor(Colors.loginTitleColor)
                    
                    SeaInputField(placeholder: "Felhasznalonev", inputText: self.$userName)
                    SeaInputField(placeholder: "Jelszo", inputText: self.$password)
                    SeaInputField(placeholder: "Jelszo megerositese", inputText: self.$passwordRepeat)
                    SeaInputField(placeholder: "A varosod neve, amit epitesz", inputText: self.$cityName)
                    
                    SeaButton(title: "Regisztracio", action: {
                        print("Btn clicked")
                    })
                        
                    Button(action: {
                        ObservableRootPage.shared.currentPage = RootPage.login
                    }) {
                        Text("Belepes")
                            .font(Font.custom("Baloo2-Regular", size: 16))
                            .foregroundColor(Colors.loginBtnTextColor)
                    }
                
                }
                .frame(width: 280.0)
                .padding()
                .background(Color(Color.RGBColorSpace.sRGB, white: 1.0, opacity: 0.65))
                .cornerRadius(16.0)
                Spacer()
            }.padding(Edge.Set.top, geometry.safeAreaInsets.top)
        }
        .background(Colors.darkBlue)
        .edgesIgnoringSafeArea(.vertical)
    }
}

struct RegisterPage_Previews: PreviewProvider {
    static var previews: some View {
        RegisterPage()
    }
}
