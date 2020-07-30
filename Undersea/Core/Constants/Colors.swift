//
//  Colors.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 08..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import SwiftUI

struct Colors {
    
    // MARK: - Cyan
    
    static let cyanLight = Color(hex: "#9FFFF0")
    static let cyanLightUI = UIColor(hex: "#9FFFF0")
    static let cyan = Color(hex: "#6BEEE9")
    static let cyanDark = Color(hex: "#0FCFDE")
    
    // MARK: - Blue
    
    static let lightBlue = Color(hex: "#3B7DBD")
    static let blueColor = Color(hex: "#3F68AE")
    static let darkBlue = Color(hex: "#1C3E76")
    static let darkBlueUI = UIColor(hex: "#1C3E76")
    static let deepBlue = Color(hex: "#03255F")
    static let deepBlueUI = UIColor(hex: "#03255F")
    static let nightlyBlue = Color(hex: "#001234")
    static let nightlyBlueUI = UIColor(hex: "#001234")
    
    // MARK: - Grey
    
    static let greyTransparent = Color(Color.RGBColorSpace.sRGB, white: 0.5, opacity: 0.32)
    static let greyTransparentUI = UIColor(red: 122.0/255.0, green: 122.0/255.0, blue: 122.0/255.0, alpha: 0.32)
    
    // MARK: - White
    
    static let whiteSemiTransparent = Color(Color.RGBColorSpace.sRGB, white: 1.0, opacity: 0.65)
    static let whiteTransparent = Color.init(Color.RGBColorSpace.sRGB, white: 1.0, opacity: 0.39)
    static let whiteFullyTransparent = Color.init(Color.RGBColorSpace.sRGB, white: 1.0, opacity: 0.12)
    
}
