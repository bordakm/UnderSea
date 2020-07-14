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
        
        GeometryReader { geometry in
                VStack {
                    SVGImage(svgName: "underseaLogo")
                        .frame(width: geometry.size.width * 0.5, height: geometry.size.width * 0.15)
                    VStack {
                        
                        Text("Belepes")
                            .font(Font.custom("Baloo2-Regular", size: 20))
                            .foregroundColor(Colors.loginTitleColor)
                        
                        SeaInputField(placeholder: "Felhasznalonev", inputText: self.$userName)
                        SeaInputField(placeholder: "Jelszo", inputText: self.$userPassword)
                        
                        SeaButton(title: "Belepes", action: {
                            ObservableRootPage.shared.currentPage = RootPage.main
                        })
                            
                        Button(action: {
                            ObservableRootPage.shared.currentPage = RootPage.register
                        }) {
                            Text("Regisztracio")
                                .font(Fonts.get(.bRegular))
                                .foregroundColor(Colors.loginBtnTextColor)
                        }
                        
                    }
                    .frame(width: 280.0)
                    .padding()
                    .background(Color(Color.RGBColorSpace.sRGB, white: 1.0, opacity: 0.65))
                    .cornerRadius(16.0)
                }
        }
        .background(Image("loginBackground")
            .resizable()
            .scaledToFill())
        .edgesIgnoringSafeArea(.vertical)
    }
}

struct LoginPage_Previews: PreviewProvider {
    static var previews: some View {
        LoginPage()
    }
}
