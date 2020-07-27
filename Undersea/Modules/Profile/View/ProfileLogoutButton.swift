//
//  ProfileLogoutButton.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 21..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

struct ProfileLogoutButton: View {
    
    let action: () -> Void
    
    var body: some View {
        Button(action: action) {
            Text("Kijelentkezés")
                .frame(minWidth: 0.0, maxWidth: .infinity, minHeight: 0.0, maxHeight: 50.0, alignment: .leading)
                .foregroundColor(Colors.loginGradientEnd)
                .font(Fonts.get(.bRegular))
                .padding(.horizontal)
        }
        .frame(minWidth: 0.0, maxWidth: .infinity, alignment: .leading)
    }
}

struct ProfileLogoutButton_Previews: PreviewProvider {
    static var previews: some View {
        ProfileLogoutButton(action: {})
    }
}
