//
//  RootPageController.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 09..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

struct RootPageController: View {
    
    @ObservedObject var observedPages = RootPageManager.shared
    
    private let tabs: [CustomTabItem] = [CustomTabItem(page: .main), CustomTabItem(page: .city),
                                         CustomTabItem(page: .attack), CustomTabItem(page: .units)]
    
    var tabBar: some View {
        
        LoadingController {
        
            CustomTabBar(tabItems: self.tabs, selected: self.$observedPages.currentSubPage)
                .sheet(isPresented: self.$observedPages.leaderboardVisible) {
                    Leaderboard.setup()
            }
            
        }

    }
    
    var body: some View {
        switch observedPages.currentPage {
        case .login:
            return AnyView(Login.setup())
        case .register:
            return AnyView(Register.setup())
        case .main:
            return AnyView(tabBar)
        case .loading:
            return AnyView(LoadScreen())
        }
    }
}

struct RootPageController_Previews: PreviewProvider {
    static var previews: some View {
        RootPageController()
    }
}
