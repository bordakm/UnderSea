//
//  KeyboardAdaptive.swift
//  Undersea
//
//  Created by Horti Tamás on 2020. 07. 22..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI
import Combine

struct KeyboardAdaptive: ViewModifier {
    
    @State private var bottomPadding: CGFloat = 0
    let frameOfInterest: CGRect
    
    func body(content: Content) -> some View {
        GeometryReader { geometry in
            content
                .padding(.bottom, self.bottomPadding)
                .onReceive(Publishers.keyboardHeight) { keyboardHeight in
                    let keyboardTop = geometry.frame(in: .global).height - keyboardHeight
                    let frameOfInterestBottom = self.frameOfInterest.maxY
                    if keyboardTop < frameOfInterestBottom {
                        self.bottomPadding = keyboardHeight
                    } else {
                        self.bottomPadding = 0
                    }
                }
                .animation(.easeOut(duration: 0.16))
        }
    }
}

extension View {
    
    func keyboardAdaptive(frameOfInterest: CGRect) -> some View {
        ModifiedContent(content: self, modifier: KeyboardAdaptive(frameOfInterest: frameOfInterest))
    }
    
}

extension Publishers {

    static var keyboardHeight: AnyPublisher<CGFloat, Never> {

        let willShow = NotificationCenter.default.publisher(for: UIApplication.keyboardWillShowNotification)
            .map { $0.keyboardHeight }
        
        let willHide = NotificationCenter.default.publisher(for: UIApplication.keyboardWillHideNotification)
            .map { _ in CGFloat(0) }
        
        return Publishers.MergeMany(willShow, willHide)
            .eraseToAnyPublisher()
    }
}

extension Notification {
    
    var keyboardHeight: CGFloat {
        return (userInfo?[UIResponder.keyboardFrameEndUserInfoKey] as? CGRect)?.height ?? 0
    }
    
}
