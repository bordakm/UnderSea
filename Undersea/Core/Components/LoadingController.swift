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
    @Published var rect: CGRect = CGRect.zero {
        didSet {
            print("-- RECT: \(rect)")
        }
    }
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
                
                Rectangle()
                    .fill(Colors.greyTransparent)
                    .edgesIgnoringSafeArea(.all)
                    .frame(width: self.loadingObserver.rect.width, height: self.loadingObserver.rect.height)
                    //.position(self.loadingObserver.rect.origin)
                    .position(CGPoint(x: self.loadingObserver.rect.midX, y: self.loadingObserver.rect.midY))
                    //.offset(x: self.loadingObserver.rect.minX, y: self.loadingObserver.rect.minY - geometry.safeAreaInsets.top)
                    .opacity(self.loadingObserver.isLoading ? 1 : 0)

                VStack {
                    Text("Loading...")
                    ActivityIndicator(isAnimating: self.$loadingObserver.isLoading, style: .medium, color: Colors.nightlyBlueUI)
                }
                .frame(width: geometry.size.width / 2,
                       height: geometry.size.height / 5)
                .background(Colors.cyanDark)
                .foregroundColor(Colors.nightlyBlue)
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
