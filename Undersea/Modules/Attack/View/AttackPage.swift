//
//  AttackPage.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 09..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

extension Attack {

    struct AttackPage: View {
        
        @State private var userName: String = ""
        
        lazy var interactor: AttackInteractor = setInteractor()
        var setInteractor: (()->AttackInteractor)!
        
        @ObservedObject var viewModel: ViewModelType
        @EnvironmentObject var loadingObserver: LoadingObserver
        @State var shouldNavigate = false
        @State var selectedId: Int?
        
        var usecaseHandler: ((Attack.Usecase) -> Void)?
        
        func getDetails() -> AnyView {
            return AnyView(AttackDetail.setup(defenderId: selectedId))
        }
        
        private var loadingIndicator: some View {
            VStack {
                ActivityIndicator(isAnimating: $viewModel.isLoadingMore, style: .medium, color: UIColor.white)
            }.frame(minWidth: 0.0, maxWidth: .infinity, alignment: .center)
        }
        
        var body: some View {
            GeometryReader { geometry in
                NavigationView {
                    VStack {
                        
                        NavigationLink(destination: self.getDetails(), isActive: self.$shouldNavigate/*Binding<Bool>(get: {
                            self.shouldNavigate
                        }, set: {
                            self.shouldNavigate = $0
                        })*/) {
                            EmptyView()
                        }
                        
                        VStack(alignment: .leading) {
                            Text("1. Lépés")
                                .font(Fonts.get(.osBold))
                                .foregroundColor(Color.white)
                            Text("Jelöld ki, kit szeretnél megtámadni:")
                                .font(Fonts.get(.osRegular))
                                .foregroundColor(Color.white)
                        }
                        .frame(maxWidth: .infinity, alignment: .leading)
                        .padding(.top, 20.0)
                        .padding(.leading, 20.0)
                        
                        SeaInputField(placeholder: "Felhasználónév", inputText: self.$userName, backgroundColor: Colors.whiteTransparent, keyboardType: UIKeyboardType.webSearch, onEditingChanged: { editing in
                            if !editing {
                                self.usecaseHandler?(.load(self.userName))
                            }
                        }).padding(.horizontal)
                        
                        List {
                            ForEach(self.viewModel.userList) { user in
                                VStack(spacing: 0.0) {
                                    Button(action: {
                                        self.selectedId = user.id
                                        self.shouldNavigate = true
                                    }) {
                                        Text(user.userName)
                                            .foregroundColor(Color.white)
                                            .padding(.vertical)
                                            .onAppear(perform: {
                                                if self.viewModel.userList.last?.id == user.id {
                                                    self.usecaseHandler?(.loadMore(self.userName))
                                                }
                                            })
                                    }
                                    Divider()
                                        .background(Colors.blueColor)
                                }
                                .listRowInsets(EdgeInsets(top: 0.0, leading: 16.0, bottom: 0.0, trailing: 16.0))
                            }
                            
                            if self.viewModel.isLoadingMore {
                                self.loadingIndicator
                            }
                            
                        }
                        .pullToRefresh(isShowing: self.$viewModel.isRefreshing) {
                            self.usecaseHandler?(.load(self.userName))
                        }
                    }
                    .navigationBarTitle("Támadás", displayMode: .inline)
                    .background(Colors.deepBlue)
                    .navigationBarColor(Colors.darkBlueUI)
                    .alert(isPresented: self.$viewModel.errorModel.alert) {
                        Alert(title: Text(self.viewModel.errorModel.title), message: Text(self.viewModel.errorModel.message), dismissButton: .default(Text("Rendben")))
                    }
                }
                .navigationViewStyle(StackNavigationViewStyle())
                .onAppear {
                    self.usecaseHandler?(.load(self.userName))
                }
                .onReceive(SignalRService.shared.incomingSignalSubject) { _ in
                    self.usecaseHandler?(.load(self.userName))
                }
                .onReceive(self.viewModel.isLoading) { (loading) in
                    self.loadingObserver.rect = geometry.frame(in: CoordinateSpace.global)
                    self.loadingObserver.isLoading = loading
                }
            }
        }
    }
}
