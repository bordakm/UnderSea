//
//  BuildingListView.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 23..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

extension City {

    struct BuildingListView: View {
        
        @State
        private var selected = false
        
        var usecaseHandler: ((City.Usecase) -> Void)?
        
        var buildingList: [CityPageViewModel.Building]
        
        var body: some View {
            VStack(spacing: 0) {
                
                VStack(alignment: .leading) {
                    Text("Jelöld ki, amelyiket szeretnéd megvenni.")
                        .font(Fonts.get(.osBold))
                        .foregroundColor(Color.white)
                    Text("Egyszerre csak egy épület épülhet!")
                        .font(Fonts.get(.osRegular))
                        .foregroundColor(Color.white)
                }
                .frame(minWidth: 0, maxWidth: .infinity, alignment: .leading)
                .padding()
                
                ScrollView(.vertical, showsIndicators: true) {
                    
                    Color.clear.frame(height: 5.0)
                
                    ForEach(buildingList) { building in
                        
                        Button(action: {
                                
                            self.usecaseHandler?(.buyBuilding(building.id))
                            
                        }) {
                            
                            ZStack(alignment: .topLeading) {
                                
                                if building.remainingRounds > 0 {
                                
                                    Text("még \(building.remainingRounds) kör")
                                        .font(Fonts.get(.osBold, 14))
                                        .foregroundColor(Colors.underseaTitleColor)
                                        .padding()
                                
                                }
                            
                                VStack {
                                
                                    Image(building.imageName)
                                        .resizable()
                                        .frame(width: 100.0, height: 100.0)
                                    
                                    Group {
                                        Text(building.name)
                                        Text(building.description)
                                    }
                                    .frame(maxWidth: 280.0)
                                    .font(Fonts.get(.osBold))
                                    .foregroundColor(Color.white)
                                    .multilineTextAlignment(.center)
                                    .fixedSize(horizontal: false, vertical: true)
                                    
                                    Group {
                                        Text("\(building.count) db")
                                        Text("\(building.price) Gyongy / db")
                                    }
                                    .font(Fonts.get(.osRegular))
                                    .foregroundColor(Color.white)
                                
                                }
                                .padding()
                            
                            }
                            
                        }
                        .overlay(RoundedRectangle(cornerRadius: 16.0).stroke(lineWidth: 1.0).fill(Colors.borderColor))
                        .padding(.bottom, 5.0)
                        
                    }
                    
                    if (buildingList.count == 0) {
                        HStack{
                            Spacer()
                        }
                    }
                    
                    Spacer(minLength: 16.0)
                    
                }.padding(.top, 10)
                
                //Image(uiImage: R.image.fighting()!)
            }.onAppear {
                self.usecaseHandler?(.loadBuildings)
            }
        }
    }
}

/*struct BuildingListView_Previews: PreviewProvider {
    static var previews: some View {
        BuildingListView()
    }
}*/
