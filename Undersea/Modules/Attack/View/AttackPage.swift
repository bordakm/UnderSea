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
                    SeaInputField(placeholder: "Felhasznalonev", inputText: $userName, backgroundColor: Colors.searchFieldBackground)
                        .padding(.horizontal)
                    List(viewModel.attackPageModel?.users ?? []) { user in
                        NavigationLink(destination: AttackDetailPage()) {
                            Text(user.name)
                                .foregroundColor(Color.white)
                                .padding(.vertical)
                        }
                    }
                }
                .navigationBarTitle("Támadás", displayMode: .inline)
                .background(Colors.backgroundColor)
                .navigationBarColor(Colors.navBarBackgroundColor)
            }
            .onAppear {
                self.usecaseHandler?(.load)
            }
        }
    }
}

/*struct AttackPage_Previews: PreviewProvider {
    static var previews: some View {
        AttackPage()
    }
}*/
