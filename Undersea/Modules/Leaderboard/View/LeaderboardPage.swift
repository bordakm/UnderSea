//
//  LeaderboardPage.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 21..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

extension Leaderboard {

    struct LeaderboardPage: View {
        
        lazy var interactor: Interactor = setInteractor()
        var setInteractor: (()->Interactor)!
        
        @ObservedObject var viewModel: ViewModelType
        
        var usecaseHandler: ((Leaderboard.Usecase) -> Void)?
        
        @State private var userName: String = ""
        @State private var isLoading = false
        
        private var closeButton: some View {
            LeaderboardCloseButton(action: {
                RootPageManager.shared.leaderboardVisible = false
            })
        }
        
        private var attackButton: some View {
            LeaderboardAttackButton(action: {
                RootPageManager.shared.currentSubPage = TabPage.attack
                RootPageManager.shared.leaderboardVisible = false
            })
        }
        
        private var loadingIndicator: some View {
            /*Rectangle()
                .fill(Color.white)
                .frame(width: 20.0, height: 20.0, alignment: .center)*/
            ActivityIndicator(isAnimating: $viewModel.isLoading, style: .medium, color: UIColor.white)
        }
        
        var body: some View {
            NavigationView {
                VStack {
                    SeaInputField(placeholder: "Felhasznalonev", inputText: $userName, backgroundColor: Colors.searchFieldBackground, keyboardType: UIKeyboardType.webSearch, onEditingChanged: { editing in
                        if !editing {
                            self.usecaseHandler?(.search(self.userName))
                        }
                    })
                        .padding([.horizontal, .top])
                    
                    List {
                        
                        ForEach(viewModel.userList) { user in
                            Text(user.userName)
                                .foregroundColor(Color.white)
                                .padding(.vertical)
                                .onAppear(perform: {
                                    if self.viewModel.userList.last?.id == user.id {
                                        self.usecaseHandler?(.loadMore(self.userName))
                                    }
                                })
                        }
                        
                        if viewModel.isLoading {
                            loadingIndicator
                        }
                    }
                }
                .navigationBarTitle("Ranglista", displayMode: .inline)
                .navigationBarItems(leading: closeButton, trailing: attackButton)
                .background(Colors.backgroundColor)
                .navigationBarColor(Colors.navBarBackgroundColor)
            }
            .onAppear {
                self.usecaseHandler?(.load)
            }
        }
    }
}

/*struct LeaderboardPage_Previews: PreviewProvider {
    static var previews: some View {
        LeaderboardPage()
    }
}*/
