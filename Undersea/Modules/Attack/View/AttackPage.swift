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
        
        lazy var interactor: Interactor = setInteractor()
        var setInteractor: (()->Interactor)!
        
        @ObservedObject var viewModel: ViewModelType
        
        var usecaseHandler: ((Attack.Usecase) -> Void)?
        
        private var loadingIndicator: some View {
            VStack {
                ActivityIndicator(isAnimating: $viewModel.isLoading, style: .medium, color: UIColor.white)
            }.frame(minWidth: 0.0, maxWidth: .infinity, alignment: .center)
        }
        
        var body: some View {
            NavigationView {
                VStack {
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
                    
                    SeaInputField(placeholder: "Felhasználónév", inputText: $userName, backgroundColor: Colors.searchFieldBackground, keyboardType: UIKeyboardType.webSearch, onEditingChanged: { editing in
                        if !editing {
                            self.usecaseHandler?(.load(self.userName))
                        }
                    }).padding(.horizontal)
                    
                    List {
                        ForEach(viewModel.userList) { user in
                            VStack(spacing: 0.0) {
                                NavigationLink(destination: AttackDetail.setup(defenderId: user.id)) {
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
                                    .background(Colors.separatorColor)
                            }
                            .listRowInsets(EdgeInsets(top: 0.0, leading: 16.0, bottom: 0.0, trailing: 16.0))
                        }
                        
                        if viewModel.isLoading {
                            loadingIndicator
                        }
                        
                    }
                    .pullToRefresh(isShowing: $viewModel.isRefreshing) {
                        self.usecaseHandler?(.load(self.userName))
                    }
                }
                .navigationBarTitle("Támadás", displayMode: .inline)
                .background(Colors.backgroundColor)
                .navigationBarColor(Colors.navBarBackgroundColor)
            }
            .navigationViewStyle(StackNavigationViewStyle())
            .onAppear {
                self.usecaseHandler?(.load(self.userName))
            }
            .onReceive(SignalRService.shared.incomingSignalSubject) { _ in
                self.usecaseHandler?(.load(self.userName))
            }
        }
    }
}

/*struct AttackPage_Previews: PreviewProvider {
    static var previews: some View {
        AttackPage()
    }
}*/
