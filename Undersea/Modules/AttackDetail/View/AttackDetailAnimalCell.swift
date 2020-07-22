//
//  AttackDetailAnimalCell.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 22..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

extension AttackDetail {

    struct AttackDetailAnimalCell: View {
        
        @State var animal: AnimalViewModel
        
        var body: some View {
            HStack(spacing: 20.0) {
                SVGImage(svgName: animal.name)
                    .frame(width: 60.0, height: 60.0, alignment: .center)
                VStack(alignment: .leading) {
                    Text(animal.description)
                        .foregroundColor(Color.white)
                    Slider(value: Binding(
                        get: {
                            self.animal.sending
                        },
                        set: {newValue in
                            self.animal.sending = newValue
                        }
                    ), in: 0...animal.available)
                        .accentColor(Colors.underseaTitleColor)
                        .introspectSlider { (slider) in
                            slider.thumbTintColor = Colors.underseaTitleUIColor
                            slider.maximumTrackTintColor = Colors.maximumTrackUIColor
                    }
                }
            }
        }
        
    }
    
}

/*struct AttackDetailAnimalCell_Previews: PreviewProvider {
    static var previews: some View {
        AttackDetail.AttackDetailAnimalCell()
    }
}*/
