//
//  SlideInMenuView.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 10..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

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
        if nextValue() != .zero {
            value = nextValue()
        }
    }
    
    typealias Value = CGSize
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
    
    let statList: [StatusBarItem]
    let action: () -> Void
    
    @State
    private var detailHidden = true
    
    var body: some View {
        VStack(spacing: 0) {
            Button(action: {
                withAnimation {
                    self.detailHidden.toggle()
                }
                self.action()
            }) {
                ZStack {
                    Rectangle()
                        .fill(Color.white)
                        .frame(height: 20.0)
                    /*Rectangle()
                        .fill(Color.black)
                        .frame(width: 10.0, height: 10.0)*/
                    Image(systemName: Images.chevronUp.rawValue)
                        .foregroundColor(Color.black)
                        .rotationEffect(.degrees(detailHidden ? 0.0 : 180.0))
                }
            }
            VStack(spacing: 10) {
                HStack(alignment: .top, spacing: 20.0) {
                    ForEach(0 ..< (self.statList.count / 2), id:\.self) { index in
                        VStack {
                            SVGImage(svgName: self.statList[index].imageName).scaledToFit().frame(height: 40.0)
                            Text(self.statList[index].label).multilineTextAlignment(TextAlignment.center)
                        }.frame(minWidth: 0, maxWidth: .infinity, alignment: .center)
                    }
                }
                HStack(alignment: .top, spacing: 20.0) {
                    ForEach((self.statList.count / 2) ..< self.statList.count, id:\.self) { index in
                        VStack {
                            SVGImage(svgName: self.statList[index].imageName).scaledToFit().frame(height: 40.0)
                            Text(self.statList[index].label).multilineTextAlignment(TextAlignment.center)
                        }.frame(minWidth: 0, maxWidth: .infinity, alignment: .center)
                    }
                }
            }
            .padding(20)
            .clipped()
            .modifier(SizeModifier())
        }
        .background(Colors.whiteSemiTransparent)
    }
}

/*struct SlideInMenuView_Previews: PreviewProvider {
    static var previews: some View {
        SlideInMenuView()
    }
}*/
