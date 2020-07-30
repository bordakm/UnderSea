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
        @EnvironmentObject var loadingObserver: LoadingObserver
        
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
        
        var userButton: some View {
            
            NavigationLink(destination: Profile.setup()) {
                SVGImage(svgPath: R.file.userImageSvg()!)
            }.frame(width: 30.0, height: 30.0)
            
        }
        
        var background: some View {
            
            ZStack {
                Image(Images.mainBg.rawValue)
                    .resizable().scaledToFill()
                if self.viewModel.mainPageModel?.builtStructures.contains(.sonarCannon) ?? false {
                    Image(uiImage: R.image.sonarCannon_layer()!).resizable().scaledToFit()
                }
                if self.viewModel.mainPageModel?.builtStructures.contains(.reefcastle) ?? false {
                    Image(uiImage: R.image.reefCastle_layer()!).resizable().scaledToFit()
                }
                if self.viewModel.mainPageModel?.builtStructures.contains(.alchemy) ?? false {
                    Image(uiImage: R.image.alchemy_layer()!).resizable().scaledToFit()
                }
                if self.viewModel.mainPageModel?.builtStructures.contains(.flowRegulator) ?? false {
                    Image(uiImage: R.image.flowManager_layer()!).resizable().scaledToFit()
                }
            }
            
        }
        
        var body: some View {
            GeometryReader { geometry in
                NavigationView {
                    ZStack(alignment: .bottom) {
                        VStack {
                            
                            Button(action: {
                                RootPageManager.shared.leaderboardVisible = true
                            }){
                                Text(self.viewModel.mainPageModel?.roundAndRank ?? "...")
                                    .font(Fonts.get(.bRegular))
                                    .foregroundColor(Colors.darkBlue)
                                    .padding(10.0)
                            }
                            .frame(height: 40.0)
                            .background(Color.white)
                            .clipShape(RoundedRectangle(cornerRadius: 13.0))
                            .shadow(color: Colors.lightBlue, radius: 6.0, x: 0.0, y: 3.0)
                            .padding(.top, 15.0)
                            
                            Spacer()
                            
                        }
                        
                        self.slideInMenu
                            .onPreferenceChange(SizePreferenceKey.self, perform: {
                                self.slideInSize = $0
                                self.slideInOffset = $0.height
                            })
                            .offset(y: self.slideInOffset)
                        
                    }
                    .background(self.background)
                    .navigationBarTitle("", displayMode: .inline)
                    .navigationBarItems(leading: SVGImage(svgPath: R.file.underseaLogoSvg()!).frame(width: 70.0, height: 40.0),
                                        trailing: self.userButton)
                    .navigationBarColor(Colors.darkBlueUI)
                    
                }
                .navigationViewStyle(StackNavigationViewStyle())
                .alert(isPresented: self.$viewModel.errorModel.alert) {
                    Alert(title: Text(self.viewModel.errorModel.title), message: Text(self.viewModel.errorModel.message), dismissButton: .default(Text("Rendben")))
                }
                .onAppear {
                    self.usecaseHandler?(.load)
                }
                .onReceive(SignalRService.shared.incomingSignalSubject) { _ in
                    self.usecaseHandler?(.load)
                }
                .onReceive(self.viewModel.isLoading) { (loading) in
                    var tempFrame = geometry.frame(in: CoordinateSpace.global)
                    tempFrame.origin.y -= geometry.safeAreaInsets.top
                    self.loadingObserver.rect = tempFrame
                    self.loadingObserver.isLoading = loading
                }
            }
        }
    }
}
