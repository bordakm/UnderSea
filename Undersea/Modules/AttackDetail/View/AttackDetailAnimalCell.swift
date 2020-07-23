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
        
        let animal: AnimalViewModel
        @State
        private var selectValue: Double = 0
        var usecaseHandler: ((AttackDetail.Usecase) -> Void)?
        
        var body: some View {
            HStack(spacing: 20.0) {
                SVGImage(svgName: animal.imageName)
                    .frame(width: 60.0, height: 60.0, alignment: .center)
                VStack(alignment: .leading) {
                    Text("\(animal.name): \(Int(round(selectValue)))/\(Int(animal.available))")
                        .foregroundColor(Color.white)
                    Slider(value: Binding(
                        get: {
                            self.selectValue
                        },
                        set: {newValue in
                            self.selectValue = newValue
                            self.usecaseHandler?(.setSendCount(self.animal.id, Int(round(newValue))))
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
