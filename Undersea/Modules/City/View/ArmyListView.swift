//
//  ArmyListView.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 24..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

extension City {

    struct ArmyListView: View {
        
        @State
        private var selected = false
               
        var usecaseHandler: ((City.Usecase) -> Void)?
               
        var units: [CityPageViewModel.Unit]
        
        var body: some View {
            VStack {
                
                Text("Jelöld ki, amelyiket szeretnéd")
                    .frame(minWidth: 0, maxWidth: .infinity, alignment: .leading)
                    .font(Fonts.get(.osBold))
                    .foregroundColor(Color.white)
                    .multilineTextAlignment(.leading)
                
                ScrollView(.vertical, showsIndicators: true) {
                
                    ForEach(units) { unit in
                            
                        VStack {
                        
                            SVGImage(svgPath: unit.imageURL)
                                .frame(width: 100.0, height: 100.0)
                            
                            Text(unit.name)
                                .frame(maxWidth: 280.0)
                                .font(Fonts.get(.osBold, 14))
                                .foregroundColor(Color.white)
                                .multilineTextAlignment(.center)
                                .fixedSize(horizontal: false, vertical: true)
                            
                            HStack {
                                Group {
                                    Text("Birtokodban:")
                                    Spacer()
                                    Text("\(unit.count) db")
                                }
                                .font(Fonts.get(.osRegular, 15))
                                .foregroundColor(Color.white)
                            }.padding(.top, 15)
                            
                            HStack {
                                Group {
                                    Text("Tamadas/vedekezes:")
                                    Spacer()
                                    Text("\(unit.attackScore)/\(unit.defenseScore)")
                                }
                                .font(Fonts.get(.osRegular, 15))
                                .foregroundColor(Color.white)
                            }
                            
                            HStack {
                                Group {
                                    Text("Zsold (/kor/peldany):")
                                    Spacer()
                                    Text("\(unit.pearlCostPerTurn) Gyongy")
                                }
                                .font(Fonts.get(.osRegular, 15))
                                .foregroundColor(Color.white)
                            }
                            
                            HStack {
                                Group {
                                    Text("Ellatmany (/kor/peldany):")
                                    Spacer()
                                    Text("\(unit.coralCostPerTurn) Korall")
                                }
                                .font(Fonts.get(.osRegular, 15))
                                .foregroundColor(Color.white)
                            }
                            
                            HStack {
                                Group {
                                    Text("Ar:")
                                    Spacer()
                                    Text("\(unit.price) Gyongy")
                                }
                                .font(Fonts.get(.osRegular, 15))
                                .foregroundColor(Color.white)
                            }
                            
                            HStack(spacing: 20.0) {
                                
                                Button(action: {
                                    
                                    if unit.selectedAmount > 0 {
                                        self.usecaseHandler?(.selectUnitAmount(unit.id, unit.selectedAmount - 1))
                                    }
                                    
                                }) {
                                    Image(systemName: "minus.circle.fill")
                                        .resizable()
                                        .frame(width: 25.0, height: 25.0, alignment: .center)
                                }
                                .accentColor(Colors.underseaTitleColor)
                                
                                Text("\(unit.selectedAmount)")
                                    .font(Fonts.get(.osBold))
                                    .foregroundColor(Color.white)
                                
                                Button(action: {
                                    
                                    /*if let index = self.units.firstIndex(where: { matchingUnit -> Bool in
                                        return matchingUnit.id == unit.id
                                    }) {
                                        //self.units[index].selectedAmount = unit.selectedAmount + 1
                                        self.usecaseHandler?(.selectUnitAmount(unit.id, unit.selectedAmount + 1))
                                    }*/
                                    
                                    self.usecaseHandler?(.selectUnitAmount(unit.id, unit.selectedAmount + 1))
                                    
                                }) {
                                    Image(systemName: "plus.circle.fill")
                                        .resizable()
                                        .frame(width: 25.0, height: 25.0, alignment: .center)
                                }
                                .accentColor(Colors.underseaTitleColor)
                                
                            }
                            
                            Divider()
                                .background(Colors.separatorColor)
                        
                        }
                        .padding()
                        
                    }
                    
                    SeaButton(title: "Megveszem", action: {
                        self.usecaseHandler?(.buyUnits)
                    })
                        .padding(.bottom, 30.0)
                    
                    if (units.count == 0) {
                        HStack{
                            Spacer()
                        }
                    }
                    
                }
            }.padding([.horizontal, .top])
            .onAppear {
                self.usecaseHandler?(.loadArmy)
            }
        }
    }
}

/*struct ArmyListView_Previews: PreviewProvider {
    static var previews: some View {
        ArmyListView()
    }
}
*/
