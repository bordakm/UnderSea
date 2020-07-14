//
//  AttackDetailPage.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 14..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

struct Animal: Identifiable {
    
    var id = UUID()
    var name: String
    var image: String
    var available: Float
    @State var sending: Float
    
}

struct AttackDetailPage: View {
    
    private var animals: [Animal] = [Animal(name: "Lézercápa", image: "shark", available: 45, sending: 0), Animal(name: "Rohamfóka", image: "seal", available: 45, sending: 0), Animal(name: "Csatacsikó", image: "shark", available: 45, sending: 0)]
    
    var body: some View {
        VStack(alignment: .leading) {
            Text("2. Lépés")
                .font(Fonts.get(.osBold))
                .foregroundColor(Color.white)
            Text("Állítsd be, kiket küldesz harcba:")
                .font(Fonts.get(.osRegular))
                .foregroundColor(Color.white)
            ForEach(animals) { animal in
                HStack {
                    SVGImage(svgName: animal.image)
                    VStack {
                        Text("\(animal.name): \(animal.sending)/\(animal.available)")
                        Slider(value: animal.$sending, in: 0...animal.available)
                    }
                }
            }
        }
        .frame(maxWidth: .infinity, maxHeight: .infinity, alignment: .topLeading)
        .background(Colors.backgroundColor)
        .navigationBarTitle("Támadás", displayMode: .inline)
        .navigationBarColor(Colors.navBarBackgroundColor)
    }
}

struct AttackDetailPage_Previews: PreviewProvider {
    static var previews: some View {
        AttackDetailPage()
    }
}
