//
//  ProfilePage.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 20..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

struct ProfilePage: View {
    
    var body: some View {
        
        GeometryReader { geometry in
            VStack(alignment: .leading, spacing: 0) {
                
                ProfileHeader()
                .frame(minWidth: 0.0, maxWidth: .infinity)
                
                Divider()
                    .background(Colors.separatorColor)
                    .padding(.horizontal)
                
                ProfileCityCell()
                    .padding(.horizontal)
                
                Divider()
                    .background(Colors.separatorColor)
                    .padding(.horizontal)
                
                //TODO: Fix button click area
                Button(action: {}) {
                    Text("Kijelentkezes")
                        .foregroundColor(Colors.loginGradientEnd)
                        .font(Fonts.get(.bRegular))
                        .padding(.horizontal)
                }
                .frame(minWidth: 0.0, maxWidth: .infinity, alignment: .leading)
                .padding(.vertical, 15.0)
                
                Divider()
                    .background(Colors.separatorColor)
                    .padding(.horizontal)
                
            }.frame(width: geometry.size.width, height: geometry.size.height, alignment: .top)
        }
        .background(Colors.backgroundColor)
        .navigationBarTitle("Profile", displayMode: .inline)
        .navigationBarColor(Colors.navBarBackgroundColor)
        
    }
}

struct ProfilePage_Previews: PreviewProvider {
    static var previews: some View {
        ProfilePage()
    }
}
