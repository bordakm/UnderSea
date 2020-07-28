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
                        .background(Colors.blueColor)
                        .padding(.horizontal)
                    
                    ProfileCityCell(cityName: self.viewModel.profilePageModel?.cityName ?? "")
                        .padding(.horizontal)
                    
                    Divider()
                        .background(Colors.blueColor)
                        .padding(.horizontal)
                    
                    ProfileLogoutButton(action: {
                        self.usecaseHandler?(.logout)
                    })
                    
                    Divider()
                        .background(Colors.blueColor)
                        .padding(.horizontal)
                    
                }
                .frame(width: geometry.size.width, height: geometry.size.height, alignment: .top)
                .alert(isPresented: self.$viewModel.errorModel.alert) {
                    Alert(title: Text(self.viewModel.errorModel.title), message: Text(self.viewModel.errorModel.message), dismissButton: .default(Text("Rendben")))
                }
                
            }
            .background(Colors.deepBlue)
            .navigationBarTitle("Profil", displayMode: .inline)
            .navigationBarColor(Colors.darkBlueUI)
            .onAppear {
                self.usecaseHandler?(.load)
            }
            .onReceive(SignalRService.shared.incomingSignalSubject) { _ in
                self.usecaseHandler?(.load)
            }
            
        }
    }
}
