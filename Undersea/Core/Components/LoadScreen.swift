//
//  LoadScreen.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 27..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

struct LoadScreen: View {
    var body: some View {
        GeometryReader { geometry in
            VStack {
                EmptyView()
            }
        }.background(Image(uiImage: R.image.loginBackground()!)
            .resizable()
            .scaledToFill())
        .edgesIgnoringSafeArea(.vertical)
    }
}

struct LoadScreen_Previews: PreviewProvider {
    static var previews: some View {
        LoadScreen()
    }
}
