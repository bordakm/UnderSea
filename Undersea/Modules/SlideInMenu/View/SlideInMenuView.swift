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

struct EqualWidth: ViewModifier {

    @State var width: CGFloat = 0

    func body(content: Content) -> some View {
        
            content
        
    }
}

extension View {
    func equalWidth(with width: CGFloat) -> some View {
        self.modifier(EqualWidth(width: width))
    }
}

struct SizePreferenceKey: PreferenceKey {
    static var defaultValue: CGSize = .zero

    static func reduce(value: inout CGSize, nextValue: () -> CGSize) {
        value = nextValue()
    }
}

struct SizeModifier: ViewModifier {
    private var sizeView: some View {
        GeometryReader { geometry in
            Color.clear.preference(key: SizePreferenceKey.self, value: geometry.size)
        }
    }

    func body(content: Content) -> some View {
        content.background(sizeView)
    }
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
        VStack(spacing: 0) {
            Button(action: {
                
                }) {
                ZStack {
                    Rectangle()
                        .fill(Color.white)
                        .frame(height: 20.0)
                    Rectangle()
                        .fill(Color.black)
                        .frame(width: 10.0, height: 10.0)
                }
            }
            VStack(spacing: 10) {
                HStack(alignment: .top, spacing: 20.0) {
                    ForEach(0 ..< (self.statList.count / 2), id:\.self) { index in
                        VStack {
                            SVGImage(svgName: self.statList[index].image).scaledToFit().frame(height: 40.0)
                            Text(self.statList[index].label).multilineTextAlignment(TextAlignment.center)
                        }.frame(minWidth: 0, maxWidth: .infinity, alignment: .center)
                    }
                }
                HStack(alignment: .top, spacing: 20.0) {
                    ForEach((self.statList.count / 2) ..< self.statList.count, id:\.self) { index in
                        VStack {
                            SVGImage(svgName: self.statList[index].image).scaledToFit().frame(height: 40.0)
                            Text(self.statList[index].label).multilineTextAlignment(TextAlignment.center)
                        }.frame(minWidth: 0, maxWidth: .infinity, alignment: .center)
                    }
                }
            }
            .modifier(SizeModifier())
            .padding(20)
            .clipped()
            .onPreferenceChange(SizePreferenceKey.self, perform: {_ in
                
            })
        }
        .background(Color(Color.RGBColorSpace.sRGB, white: 1.0, opacity: 0.5))
    }
}

struct SlideInMenuView_Previews: PreviewProvider {
    static var previews: some View {
        SlideInMenuView()
    }
}
