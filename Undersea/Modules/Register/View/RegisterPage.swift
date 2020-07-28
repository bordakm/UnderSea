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
        
        @ObservedObject var viewModel: ViewModelType
        
        var usecaseHandler: ((Register.Usecase) -> Void)?
        
        @State private var userName: String = ""
        @State private var password: String = ""
        @State private var passwordRepeat: String = ""
        @State private var cityName: String = ""
        
        @State private var alertPresented = false
        @State private var frameOfInterest: CGRect?
        
        //@State private var pushLogin = false
        
        var body: some View {
            
            GeometryReader { geometry in
                VStack {
                    SVGImage(svgPath: R.file.underseaLogoSvg()!)
                        .frame(width: geometry.size.width * 0.5, height: geometry.size.width * 0.15)
                    VStack {
                        
                        Text("Belépés")
                            .font(Fonts.get(.bRegular, 20.0))
                            .foregroundColor(Colors.nightlyBlue)
                        
                        SeaInputField(placeholder: "Felhasználónév", inputText: self.$userName)
                        SeaInputField(placeholder: "Jelszó", inputText: self.$password, isSecure: true)
                        SeaInputField(placeholder: "Jelszó megerősítése", inputText: self.$passwordRepeat, isSecure: true)
                        SeaInputField(placeholder: "A városod neve, amit építesz", inputText: self.$cityName)
                        
                        SeaButton(title: "Regisztráció", action: {
                            if self.password == self.passwordRepeat {
                                self.usecaseHandler?(.register(self.userName, self.cityName, self.password))
                            } else {
                                self.alertPresented = true
                            }
                        })
                        .alert(isPresented: self.$alertPresented) {
                            Alert(title: Text("Hiba!"), message: Text("A jelszavak nem egyeznek meg!"), dismissButton: .default(Text("Rendben")))
                        }
                        .alert(isPresented: self.$viewModel.errorModel.alert) {
                            Alert(title: Text(self.viewModel.errorModel.title), message: Text(self.viewModel.errorModel.message), dismissButton: .default(Text("Rendben")))
                        }
                            
                        Button(action: {
                            RootPageManager.shared.currentPage = RootPage.login
                        }) {
                            Text("Belépés")
                                .font(Fonts.get(.bRegular))
                                .foregroundColor(Colors.nightlyBlue)
                        }
                    
                    }
                    .frame(width: 280.0)
                    .padding()
                    .background(GeometryReader { gp -> Color in
                        let frame = gp.frame(in: .global)
                        DispatchQueue.main.async {
                            if self.frameOfInterest == nil {
                                self.frameOfInterest = frame
                            }
                        }
                        return Colors.whiteSemiTransparent
                    })
                    .cornerRadius(16.0)
                    
                }.padding(.top, geometry.safeAreaInsets.top)
                .keyboardAdaptive(frameOfInterest: self.frameOfInterest ?? CGRect.zero)
                
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
