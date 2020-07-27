//
//  ProfileCityCell.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 20..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

struct ProfileCityCell: View {
    
    var cityName: String
    
    var body: some View {
        VStack(alignment: .leading) {
            Text("Városom neve")
                .foregroundColor(Color.white)
                .font(Fonts.get(.osBold))
            Text(cityName)
                .foregroundColor(Color.white)
                .font(Fonts.get(.osRegular))
        }.padding(.vertical, 15.0)
    }
}

/*struct ProfileCityCell_Previews: PreviewProvider {
    static var previews: some View {
        ProfileCityCell()
    }
}*/
