//
//  TeamsPage.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 09..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI


extension Teams {

    struct TeamsPage: View {
        
        lazy var interactor: Interactor = setInteractor()
        var setInteractor: (()->Interactor)!
        
        @ObservedObject var viewModel: ViewModelType
        
        var usecaseHandler: ((Teams.Usecase) -> Void)?
        
        var body: some View {
            NavigationView {
                List {
                    
                    ForEach(viewModel.teams) { team in
                        VStack(alignment: .leading, spacing: 10.0) {
                            Text("\(team.name)")
                                .font(Fonts.get(.osBold))
                                .foregroundColor(Color.white)
                                .padding(.top, 10.0)
                            ForEach(team.units, id:\.self) { unit in
                                Text("\(unit)")
                                    .font(Fonts.get(.osRegular))
                                    .foregroundColor(Color.white)
                            }
                            Divider()
                                .background(Colors.separatorColor)
                        }.listRowInsets(EdgeInsets(top: 0.0, leading: 16.0, bottom: 0.0, trailing: 16.0))
                    }
                    
                }
                .navigationBarTitle("Csapataim", displayMode: .inline)
                .background(Colors.backgroundColor)
                .navigationBarColor(Colors.navBarBackgroundColor)
                .pullToRefresh(isShowing: $viewModel.isRefreshing) {
                    self.usecaseHandler?(.load)
                }
            }
            .onAppear {
                self.usecaseHandler?(.load)
            }
        }
    }
    
}

/*struct TeamsPage_Previews: PreviewProvider {
    static var previews: some View {
        TeamsPage()
    }
}*/
