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
        
        lazy var interactor: Interactor = setInteractor()
        var setInteractor: (()->Interactor)!
        
        @ObservedObject var viewModel: ViewModelType
        
        var usecaseHandler: ((City.Usecase) -> Void)?
        
        @State var selectedTab = CityTabs.buildings
        
        var tabView: some View {
            switch selectedTab {
            case .buildings:
                return AnyView(BuildingListView(usecaseHandler: usecaseHandler, buildingList: viewModel.cityPageViewModel.buildings ?? []))
            case .upgrades:
                return AnyView(EmptyView())
            case .army:
                return AnyView(ArmyListView(usecaseHandler: usecaseHandler, units: viewModel.cityPageViewModel.units ?? []))
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
                .background(Colors.backgroundColor)
                .navigationBarColor(Colors.navBarBackgroundColor)
            }
        }
    }
    
}

/*struct CityPage_Previews: PreviewProvider {
    static var previews: some View {
        City.CityPage()
    }
}*/
