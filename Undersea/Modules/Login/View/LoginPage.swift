//
//  LoginPage.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 08..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

extension Login {

    struct LoginPage: View {
        
        lazy var interactor: Interactor = setInteractor()
        var setInteractor: (()->Interactor)!
        
        var usecaseHandler: ((Login.Usecase) -> Void)?
        
        @State private var userName: String = ""
        @State private var userPassword: String = ""
        
        var body: some View {
            
            GeometryReader { geometry in
                    VStack {
                        SVGImage(svgPath: R.file.underseaLogoSvg()!)
                            .frame(width: geometry.size.width * 0.5, height: geometry.size.width * 0.15)
                        VStack {
                            
                            Text("Belepes")
                                .font(Fonts.get(.bRegular, 20.0))
                                .foregroundColor(Colors.loginTitleColor)
                            
                            SeaInputField(placeholder: "Felhasznalonev", inputText: self.$userName)
                            SeaInputField(placeholder: "Jelszo", inputText: self.$userPassword, isSecure: true)
                            
                            SeaButton(title: "Belepes", action: {
                                self.usecaseHandler?(.login(self.userName, self.userPassword))
                            })
                                
                            Button(action: {
                                RootPageManager.shared.currentPage = RootPage.register
                            }) {
                                Text("Regisztracio")
                                    .font(Fonts.get(.bRegular))
                                    .foregroundColor(Colors.loginBtnTextColor)
                            }
                            
                        }
                        .frame(width: 280.0)
                        .padding()
                        .background(Colors.whiteTransparent)
                        .cornerRadius(16.0)
                        
                        Spacer()
                        
                    }.padding(.top, geometry.safeAreaInsets.top + 50.0)
            }
            .background(Image(uiImage: R.image.loginBackground()!)
                .resizable()
                .scaledToFill())
            .edgesIgnoringSafeArea(.vertical)
        }
    }
}

/*struct LoginPage_Previews: PreviewProvider {
    static var previews: some View {
        LoginPage()
    }
}*/
