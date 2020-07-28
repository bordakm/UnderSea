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
        
        @ObservedObject var viewModel: ViewModelType
        
        var usecaseHandler: ((Login.Usecase) -> Void)?
        
        @State private var frameOfInterest: CGRect?
        
        @State private var userName: String = ""
        @State private var userPassword: String = ""
        
        var body: some View {
            
            GeometryReader { geometry in
                    VStack {
                        SVGImage(svgPath: R.file.underseaLogoSvg()!)
                            .frame(width: geometry.size.width * 0.5, height: geometry.size.width * 0.15)
                        VStack {
                            
                            Text("Belépés")
                                .font(Fonts.get(.bRegular, 20.0))
                                .foregroundColor(Colors.loginTitleColor)
                            
                            SeaInputField(placeholder: "Felhasználónév", inputText: self.$userName)
                            SeaInputField(placeholder: "Jelszó", inputText: self.$userPassword, isSecure: true)
                            
                            SeaButton(title: "Belépés", action: {
                                self.usecaseHandler?(.login(self.userName, self.userPassword))
                            })
                            .alert(isPresented: self.$viewModel.errorModel.alert) {
                                Alert(title: Text(self.viewModel.errorModel.title), message: Text(self.viewModel.errorModel.message), dismissButton: .default(Text("Rendben")))
                            }
                                
                            Button(action: {
                                RootPageManager.shared.currentPage = RootPage.register
                            }) {
                                Text("Regisztráció")
                                    .font(Fonts.get(.bRegular))
                                    .foregroundColor(Colors.loginBtnTextColor)
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
                            return Colors.whiteTransparent
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

/*struct LoginPage_Previews: PreviewProvider {
    static var previews: some View {
        LoginPage()
    }
}*/
