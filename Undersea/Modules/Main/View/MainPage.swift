//
//  MainPage.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 09..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

extension Main {

    struct MainPage: View {
        
        @State private var slideInSize: CGSize = .zero
        @State private var slideInOffset: CGFloat = 0.0
        
        lazy var interactor: Interactor = setInteractor()
        var setInteractor: (()->Interactor)!
        
        @ObservedObject var viewModel: ViewModelType
        
        var usecaseHandler: ((Main.Usecase) -> Void)?
        
        var slideInMenu: some View {
            SlideInMenuView(statList: viewModel.mainPageModel?.statList ?? [], action: {
                withAnimation(.easeInOut) {
                    if self.slideInOffset == 0.0 {
                        self.slideInOffset = self.slideInSize.height
                    } else {
                        self.slideInOffset = 0.0
                    }
                }
            })
        }
        
        var body: some View {
            NavigationView {
                ZStack(alignment: .bottom) {
                    VStack {
                        
                        Button(action: {
                            //ToDo: push to rank page
                            print("push to rank page")
                        }){
                            Text(viewModel.mainPageModel?.roundAndRank ?? "...")
                                .font(Font.custom("Baloo2-Regular", size: 16))
                                .foregroundColor(Colors.darkBlue)
                                .padding(10.0)
                        }
                        .frame(height: 40.0)
                        .background(Color.white)
                        .clipShape(RoundedRectangle(cornerRadius: 13.0))
                        .shadow(color: Colors.loginShadowColor, radius: 6.0, x: 0.0, y: 3.0)
                        .padding(.top, 15.0)
                        
                        GeometryReader { geometry in
                            ZStack {
                                Text("Epuletek")
                                    .foregroundColor(Color.white)
                            }
                            .frame(height: geometry.size.height)
                        }
                    }
                    
                    slideInMenu
                        .onPreferenceChange(SizePreferenceKey.self, perform: {
                            self.slideInSize = $0
                            self.slideInOffset = $0.height
                        })
                        .offset(y: self.slideInOffset)
                    
                }
                .background(Image("mainBackground")
                    .resizable()
                    .scaledToFill())
                .navigationBarTitle("", displayMode: .inline)
                .navigationBarItems(leading: SVGImage(svgName: "underseaLogo").frame(width: 70.0, height: 40.0),
                                    trailing: SVGImage(svgName: "userImage").frame(width: 30.0, height: 30.0))
                .navigationBarColor(Colors.navBarTintColor)
            }.onAppear {
                self.usecaseHandler?(.load)
            }
        }
    }

}

/*struct MainPage_Previews: PreviewProvider {
    static var previews: some View {
        MainPage()
    }
}*/
