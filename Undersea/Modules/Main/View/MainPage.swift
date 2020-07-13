//
//  MainPage.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 09..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

struct MainPage: View {
    
    @State private var slideInSize: CGSize = .zero
    @State private var slideInOffset: CGFloat = 0.0
    
    var slideInMenu: some View {
        SlideInMenu.setup(action: {
            withAnimation(.easeInOut) {
                if self.slideInOffset == 0.0 {
                    self.slideInOffset = self.slideInSize.height
                } else {
                    self.slideInOffset = 0.0
                }
            }
        })
    }
    
    var body: some View {
        NavigationView {
            ZStack(alignment: .bottom) {
                VStack {
                    RoundedRectangle(cornerRadius: 5.0)
                        .fill(Color.black)
                        .frame(width: 80.0, height: 30.0)
                        .padding(Edge.Set.top, 10.0)
                    GeometryReader { geometry in
                        ZStack {
                            Text("Epuletek")
                        }
                        .frame(height: geometry.size.height)
                    }
                }
                
                slideInMenu
                    .onPreferenceChange(SizePreferenceKey.self, perform: {
                        self.slideInSize = $0
                        self.slideInOffset = $0.height
                    })
                    .offset(y: self.slideInOffset)
                
            }
            .background(Image("mainBackground")
                .resizable()
                .scaledToFill())
            .navigationBarTitle("", displayMode: .inline)
            .navigationBarItems(leading: SVGImage(svgName: "underseaLogo").frame(width: 70.0, height: 40.0),
                                trailing: SVGImage(svgName: "userImage").frame(width: 30.0, height: 30.0))
            .navigationBarColor(Colors.navBarTintColor)
        }
    }
}

/*struct MainPage_Previews: PreviewProvider {
    static var previews: some View {
        MainPage()
    }
}*/
