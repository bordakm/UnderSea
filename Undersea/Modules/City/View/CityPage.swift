//
//  CityPage.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 09..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

extension City {

    struct CityPage: View {
        
        @State var selectedTab = CityTabs.buildings
        
        var tabView: some View {
            switch selectedTab {
            case .buildings:
                return AnyView(Buildings.setup())
            case .upgrades:
                return AnyView(Upgrades.setup())
            case .army:
                return AnyView(Army.setup())
            }
        }
        
        var body: some View {
            NavigationView {
                VStack {
                    
                    HStack {
                        Group {
                            Button(action: {
                                self.selectedTab = .buildings
                            }) {
                                Text("Épületek")
                            }
                            Button(action: {
                                self.selectedTab = .upgrades
                            }) {
                                Text("Fejlesztések")
                            }
                            Button(action: {
                                self.selectedTab = .army
                            }) {
                                Text("Sereg")
                            }
                        }
                        .frame(minWidth: 0.0, maxWidth: .infinity, minHeight: 0.0, maxHeight: 50.0, alignment: .top)
                        .foregroundColor(Color.white)
                        .font(Fonts.get(.osBold))
                    }.padding(.top, 30.0)
                    
                    tabView
                    
                }
                .frame(minWidth: 0.0, maxWidth: .infinity, minHeight: 0.0, maxHeight: .infinity, alignment: .top)
                .navigationBarTitle("Városom", displayMode: .inline)
                .background(Colors.deepBlue)
                .navigationBarColor(Colors.darkBlueUI)
            }
            .navigationViewStyle(StackNavigationViewStyle())
        }
    }
    
}
