//
//  ProfilePage.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 20..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

extension Profile {

    struct ProfilePage: View {
        
        lazy var interactor: Interactor = setInteractor()
        var setInteractor: (()->Interactor)!
        
        @ObservedObject var viewModel: ViewModelType
        
        var usecaseHandler: ((Profile.Usecase) -> Void)?
        
        var body: some View {
            
            GeometryReader { geometry in
                
                VStack(alignment: .leading, spacing: 0) {
                    
                    ProfileHeader(userName: self.viewModel.profilePageModel?.userName ?? "")
                    .frame(minWidth: 0.0, maxWidth: .infinity)
                    
                    Divider()
                        .background(Colors.separatorColor)
                        .padding(.horizontal)
                    
                    ProfileCityCell(cityName: self.viewModel.profilePageModel?.cityName ?? "")
                        .padding(.horizontal)
                    
                    Divider()
                        .background(Colors.separatorColor)
                        .padding(.horizontal)
                    
                    ProfileLogoutButton(action: {
                        self.usecaseHandler?(.logout)
                    })
                    
                    Divider()
                        .background(Colors.separatorColor)
                        .padding(.horizontal)
                    
                }
                .frame(width: geometry.size.width, height: geometry.size.height, alignment: .top)
                .alert(isPresented: self.$viewModel.errorModel.alert) {
                    Alert(title: Text(self.viewModel.errorModel.title), message: Text(self.viewModel.errorModel.message), dismissButton: .default(Text("Rendben")))
                }
                
            }
            .background(Colors.backgroundColor)
            .navigationBarTitle("Profil", displayMode: .inline)
            .navigationBarColor(Colors.navBarBackgroundColor)
            .onAppear {
                self.usecaseHandler?(.load)
            }
            .onReceive(SignalRService.shared.incomingSignalSubject) { _ in
                self.usecaseHandler?(.load)
            }
            
        }
    }
}

/*
struct ProfilePage_Previews: PreviewProvider {
    static var previews: some View {
        ProfilePage()
    }
}*/
