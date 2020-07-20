//
//  ProfileHeader.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 20..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

struct ProfileHeader: View {
    var body: some View {
        VStack(alignment: .center) {
            SVGImage(svgPath: R.file.userImageSvg()!)
                .frame(width: 90.0, height: 90.0, alignment: .center)
            Text("username")
                .foregroundColor(Color.white)
                .font(Fonts.get(.bRegular))
        }
        .padding(.top, 40.0)
        .padding(.bottom, 20.0)
    }
}

struct ProfileHeader_Previews: PreviewProvider {
    static var previews: some View {
        ProfileHeader()
    }
}
