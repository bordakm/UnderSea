//
//  RootPageController.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 09..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

struct RootPageController: View {
    
    @ObservedObject var observedPages = ObservableRootPage.shared
    
    private let tabs: [CustomTabItem] = [
        CustomTabItem(view: AnyView(Main.setup()), title: "Kezdőlap", imageName: "main"),
        CustomTabItem(view: AnyView(City.setup()), title: "Városom", imageName: "city"),
        CustomTabItem(view: AnyView(Attack.setup()), title: "Támadás", imageName: "attack"),
        CustomTabItem(view: AnyView(Teams.setup()), title: "Csapataim", imageName: "teams")
    ]
    
    var body: some View {
        switch observedPages.currentPage {
        case .login:
            return AnyView(Login.setup())
        case .register:
            return AnyView(Register.setup())
        case .main:
            return AnyView(CustomTabBar(tabItems: tabs))
        }
    }
}

struct RootPageController_Previews: PreviewProvider {
    static var previews: some View {
        RootPageController()
    }
}
