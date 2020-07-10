//
//  SlideInMenuView.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 10..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

struct Stat {
    var label: String
    var image: String
}

struct SlideInMenuView: View {
    private var statList = [Stat(label: "0/5", image: "shark"),
                            Stat(label: "5/10", image: "seal"),
                            Stat(label: "5/10", image: "seahorse"),
                            Stat(label: "230\n3886/kör", image: "pearl"),
                            Stat(label: "230\n12/kör", image: "coral"),
                            Stat(label: "1", image: "reefcastle"),
                            Stat(label: "0", image: "flowcontroller")]
    
    var body: some View {
        VStack {
            Rectangle()
                .fill(Color.black)
                .frame(height: 20.0)
            HStack(alignment: .top, spacing: 20.0) {
                ForEach(0 ..< (statList.count / 2), id:\.self) { index in
                    VStack {
                        SVGImage(svgName: self.statList[index].image).scaledToFit().frame(height: 40.0)
                        Text(self.statList[index].label).multilineTextAlignment(TextAlignment.center)
                    }
                }
            }
            HStack(alignment: .top, spacing: 20.0) {
                ForEach((statList.count / 2) ..< statList.count, id:\.self) { index in
                    VStack {
                        SVGImage(svgName: self.statList[index].image).scaledToFit().frame(height: 40.0)
                        Text(self.statList[index].label).multilineTextAlignment(TextAlignment.center)
                    }
                }
            }
        }
        .background(Color(Color.RGBColorSpace.sRGB, white: 0.0, opacity: 0.5))
    }
}

struct SlideInMenuView_Previews: PreviewProvider {
    static var previews: some View {
        SlideInMenuView()
    }
}
