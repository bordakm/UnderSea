//
//  RegisterPage.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 08..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

extension Register {

    struct RegisterPage: View {
        
        lazy var interactor: Interactor = setInteractor()
        var setInteractor: (()->Interactor)!
        
        var usecaseHandler: ((Register.Usecase) -> Void)?
        
        @State private var userName: String = ""
        @State private var password: String = ""
        @State private var passwordRepeat: String = ""
        @State private var cityName: String = ""
        
        @State private var alertPresented = false
        
        //@State private var pushLogin = false
        
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
                        SeaInputField(placeholder: "Jelszo", inputText: self.$password, isSecure: true)
                        SeaInputField(placeholder: "Jelszo megerositese", inputText: self.$passwordRepeat, isSecure: true)
                        SeaInputField(placeholder: "A varosod neve, amit epitesz", inputText: self.$cityName)
                        
                        SeaButton(title: "Regisztracio", action: {
                            if self.password == self.passwordRepeat {
                                self.usecaseHandler?(.register(self.userName, self.cityName, self.password))
                            } else {
                                self.alertPresented = true
                            }
                        }).alert(isPresented: self.$alertPresented) {
                            Alert(title: Text("Hiba!"), message: Text("A jelszavak nem egyeznek meg!"), dismissButton: .default(Text("Rendben")))
                        }
                            
                        Button(action: {
                            RootPageManager.shared.currentPage = RootPage.login
                        }) {
                            Text("Belepes")
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
    
/*struct RegisterPage_Previews: PreviewProvider {
    static var previews: some View {
        RegisterPage()
    }
}*/
