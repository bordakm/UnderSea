//
//  SeaInputField.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 08..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI
import Introspect

struct SeaInputField: View {
    
    let placeholder: String
    @Binding var inputText: String
    
    var backgroundColor = Color.white
    var keyboardType = UIKeyboardType.asciiCapable
    var onEditingChanged: (Bool) -> Void = { _ in }
    
    var body: some View {
        ZStack {
            GeometryReader() { geometry in
                // TODO: Placeholder szinenek beallitasara nincs beepitett megoldas meg SwiftUI-ban
                TextField(self.placeholder, text: self.$inputText, onEditingChanged: self.onEditingChanged)
                    .padding(Edge.Set.horizontal, 16.0)
                    .frame(width: geometry.size.width, height: geometry.size.height, alignment: .leading)
                    .font(Font.system(size: 15.0))
                    .keyboardType(self.keyboardType)
                    .foregroundColor(Colors.tabTintColor)
                    .accentColor(Colors.tabTintColor)
            }
        }
        .frame(height: 40.0, alignment: .leading)
        .background(backgroundColor)
        .clipShape(Capsule())
    }
    
    
    
}

struct SeaInputField_Previews: PreviewProvider {
    
    @State private static var testInput: String = ""
    
    static var previews: some View {
        SeaInputField(placeholder: "Placeholder", inputText: $testInput)
    }
}
