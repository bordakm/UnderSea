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
    
    var isSecure = false
    
    var textField: AnyView {
        if self.isSecure {
            return AnyView(SecureField(self.placeholder, text: self.$inputText)
                .keyboardType(self.keyboardType))
        } else {
            return AnyView(TextField(self.placeholder, text: self.$inputText, onEditingChanged: self.onEditingChanged)
                .keyboardType(self.keyboardType))
        }
    }
    
    var body: some View {
        ZStack {
            GeometryReader() { geometry in
                self.textField
                    .padding(Edge.Set.horizontal, 16.0)
                    .frame(width: geometry.size.width, height: geometry.size.height, alignment: .leading)
                    .font(Fonts.get(.osRegular, 15))
                    .foregroundColor(Colors.nightlyBlue)
                    .accentColor(Colors.nightlyBlue)
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
