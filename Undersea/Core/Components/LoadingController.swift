//
//  LoadingController.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 29..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

class LoadingObserver: ObservableObject {
    @Published var isLoading = false
}

struct LoadingController<Content>: View where Content: View {
    
    @ObservedObject
    var loadingObserver = LoadingObserver()
    
    var content: () -> Content
    
    var body: some View {
        GeometryReader { geometry in
            ZStack(alignment: .center) {

                self.content()
                    .environmentObject(self.loadingObserver)

                VStack {
                    Text("Loading...")
                    ActivityIndicator(isAnimating: self.$loadingObserver.isLoading, style: .medium, color: UIColor.white)
                }
                .frame(width: geometry.size.width / 2,
                       height: geometry.size.height / 5)
                .background(Color.secondary.colorInvert())
                .foregroundColor(Color.primary)
                .cornerRadius(20)
                .opacity(self.loadingObserver.isLoading ? 1 : 0)

            }
        }
    }
}

/*struct LoadingController_Previews: PreviewProvider {
    static var previews: some View {
        LoadingController()
    }
}*/
