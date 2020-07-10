//
//  CustomTabBar.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 09..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

struct CustomTabItem: Identifiable {
    
    let id = UUID()
    let view: AnyView
    let title: String
    let imageName: String
    
}

struct CustomTabBar: View {
    
    let tabItems: [CustomTabItem]
    
    @State
    private var selectedTab = 0
    private let tabHeight: CGFloat = 56.0
    
    var body: some View {
        GeometryReader { geometry in
            VStack {
                self.tabItems[self.selectedTab].view
                ZStack {
                    LinearGradient(gradient: Gradient(colors: [Colors.loginGradientStart, Colors.loginGradientMid, Colors.loginGradientEnd]), startPoint: .bottom, endPoint: .top)
                        .frame(width: geometry.size.width, height: self.tabHeight + geometry.safeAreaInsets.bottom)
                    TabButtons(tabItems: self.tabItems, selectedTab: self.$selectedTab)
                        .padding(.bottom, geometry.safeAreaInsets.bottom)
                        .frame(width: geometry.size.width, height: self.tabHeight)
                }
            }
        }
        .edgesIgnoringSafeArea(.bottom)
    }
}

struct CustomTabBar_Previews: PreviewProvider {
    static var previews: some View {
        let tab1 = CustomTabItem(view: AnyView(Text("First page")), title: "First", imageName: "star")
        let tab2 = CustomTabItem(view: AnyView(Text("Second page")), title: "Second", imageName: "star")
        return CustomTabBar(tabItems: [tab1, tab2])
    }
}

struct TabButtons: View {
    
    @State var tabItems: [CustomTabItem]
    @Binding var selectedTab: Int
    
    var body: some View {
        HStack {
            Spacer()
            ForEach(self.tabItems) { tabItem in
                VStack(spacing: 4.0) {
                    SVGImage(svgName: tabItem.imageName)
                        .frame(width: 20.0, height: 20.0)
                    Text(tabItem.title)
                        .font(.system(size: 11))
                        .foregroundColor(Colors.tabTintColor)
                }.gesture(
                    TapGesture().onEnded({ _ in
                        self.selectedTab = self.index(of: tabItem)
                    })
                ).opacity(self.selectedTab == self.index(of: tabItem) ? 1.0 : 0.5)
                Spacer()
            }
        }
    }
    
    private func index(of tabItem: CustomTabItem) -> Int {
        return self.tabItems.firstIndex(where: { (item) -> Bool in
            return tabItem.id == item.id
        }) ?? 0
    }
    
}
