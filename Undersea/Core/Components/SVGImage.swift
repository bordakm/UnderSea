//
//  SVGImage.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 09..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import Foundation
import SwiftUI
import Macaw

struct SVGImage: UIViewRepresentable {
    
    typealias UIViewType = SVGView
    private var svgName: String
    
    init(svgName: String) {
        self.svgName = svgName
    }
    
    init(svgPath: URL) {
        self.svgName = svgPath.deletingPathExtension().lastPathComponent
    }

    func makeUIView(context: Context) -> SVGView {
        let svgView = SVGView()
        svgView.backgroundColor = .clear
        svgView.fileName = self.svgName
        svgView.contentMode = .scaleAspectFit
        return svgView
    }

    func updateUIView(_ uiView: SVGView, context: Context) { }

}
