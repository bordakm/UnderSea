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
        @EnvironmentObject var loadingObserver: LoadingObserver
        
        var usecaseHandler: ((Teams.Usecase) -> Void)?
        
        var body: some View {
            GeometryReader { geometry in
                
                NavigationView {
                    List {
                        
                        ForEach(self.viewModel.teams) { team in
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
                                    .background(Colors.blueColor)
                            }.listRowInsets(EdgeInsets(top: 0.0, leading: 16.0, bottom: 0.0, trailing: 16.0))
                        }
                        
                    }
                    .navigationBarTitle("Csapataim", displayMode: .inline)
                    .background(Colors.deepBlue)
                    .navigationBarColor(Colors.darkBlueUI)
                    .pullToRefresh(isShowing: self.$viewModel.isRefreshing) {
                        self.usecaseHandler?(.load)
                    }
                    .alert(isPresented: self.$viewModel.errorModel.alert) {
                        Alert(title: Text(self.viewModel.errorModel.title), message: Text(self.viewModel.errorModel.message), dismissButton: .default(Text("Rendben")))
                    }
                }
                .navigationViewStyle(StackNavigationViewStyle())
                .onAppear {
                    self.usecaseHandler?(.load)
                }
                .onReceive(SignalRService.shared.incomingSignalSubject) { _ in
                    self.usecaseHandler?(.load)
                }
                .onReceive(self.viewModel.isLoading) { (loading) in
                    self.loadingObserver.rect = geometry.frame(in: CoordinateSpace.global)
                    self.loadingObserver.isLoading = loading
                }
            }
        }
    }
    
}

/*struct TeamsPage_Previews: PreviewProvider {
    static var previews: some View {
        TeamsPage()
    }
}*/
