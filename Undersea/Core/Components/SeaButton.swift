//
//  SeaButton.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 08..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

struct SeaButton: View {
    
    let title: String
    let action: () -> Void
    
    var body: some View {
        Button(action: action) {
            
            ZStack {
                LinearGradient(gradient: Gradient(colors: [Colors.loginGradientStart, Colors.loginGradientMid, Colors.loginGradientEnd]), startPoint: .leading, endPoint: .trailing)
                Text(title)
                    .font(Font.custom("Baloo2-Regular", size: 16))
                    .foregroundColor(Colors.loginBtnTextColor)
            }
            
        }.background(Color.clear)
        .frame(width: 150.0, height: 40.0, alignment: .center)
        .clipShape(Capsule())
        .shadow(color: Colors.loginShadowColor, radius: 6.0, x: 0.0, y: 3.0)
    }
}

struct SeaButton_Previews: PreviewProvider {
    static var previews: some View {
        SeaButton(title: "Belepes", action: {
            print("Btn click");
        })
    }
}
