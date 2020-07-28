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
    let page: TabPage
    
    init(page: TabPage) {
        self.view = page.view
        self.title = page.title
        self.imageName = page.imageName
        self.page = page
    }
    
}

struct CustomTabBar: View {
    
    let tabItems: [CustomTabItem]
    
    @Binding
    var selected: TabPage
    
    private let tabHeight: CGFloat = 56.0
    
    var body: some View {
        GeometryReader { geometry in
            VStack(spacing: 0) {
                self.tabItems.filter({ $0.page == self.selected }).first?.view //[self.selectedTab].view
                ZStack {
                    LinearGradient(gradient: Gradient(colors: [Colors.cyanDark, Colors.cyan, Colors.cyanLight]), startPoint: .bottom, endPoint: .top)
                        .frame(width: geometry.size.width, height: self.tabHeight + geometry.safeAreaInsets.bottom)
                    TabButtons(tabItems: self.tabItems, selected: self.$selected)
                        .padding(.bottom, geometry.safeAreaInsets.bottom)
                        .frame(width: geometry.size.width, height: self.tabHeight)
                }
            }
        }
        .edgesIgnoringSafeArea(.bottom)
    }
}

/*struct CustomTabBar_Previews: PreviewProvider {
    static var previews: some View {
        let tab1 = CustomTabItem(view: AnyView(Text("First page")), title: "First", imageName: "star")
        let tab2 = CustomTabItem(view: AnyView(Text("Second page")), title: "Second", imageName: "star")
        return CustomTabBar(tabItems: [tab1, tab2])
    }
}*/

struct TabButtons: View {
    
    @State var tabItems: [CustomTabItem]
    @Binding var selected: TabPage
    
    var body: some View {
        HStack {
            Spacer()
            ForEach(self.tabItems) { tabItem in
                VStack(spacing: 4.0) {
                    SVGImage(svgName: tabItem.imageName)
                        .frame(width: 20.0, height: 20.0)
                    Text(tabItem.title)
                        .font(.system(size: 11))
                        .foregroundColor(Colors.nightlyBlue)
                }.gesture(
                    TapGesture().onEnded({ _ in
                        self.selected = tabItem.page
                    })
                ).opacity(self.selected == tabItem.page ? 1.0 : 0.5)
                Spacer()
            }
        }
    }
    
    /*private func index(of tabItem: CustomTabItem) -> Int {
        return self.tabItems.firstIndex(where: { (item) -> Bool in
            return tabItem.id == item.id
        }) ?? 0
    }*/
    
}
