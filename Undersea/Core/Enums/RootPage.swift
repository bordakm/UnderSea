//
//  RootPages.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 09..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation

enum RootPage {
    case login
    case register
    case main
}

class ObservableRootPage : ObservableObject {
    @Published var currentPage = RootPage.login
    static let shared: ObservableRootPage = {
        return ObservableRootPage()
    }()
}
