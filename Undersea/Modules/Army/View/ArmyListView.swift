//
//  ArmyListView.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 28..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

extension Army {

    struct ArmyListView: View {
        
        @State
        private var selected = false
        
        lazy var interactor: Interactor = setInteractor()
        var setInteractor: (()->Interactor)!
        
        @ObservedObject var viewModel: ViewModelType
        
        let usecaseHandler: ((Army.Usecase) -> Void)?
        
        var body: some View {
            VStack {
                
                Text("Jelöld ki, amelyiket szeretnéd")
                    .frame(minWidth: 0, maxWidth: .infinity, alignment: .leading)
                    .font(Fonts.get(.osBold))
                    .foregroundColor(Color.white)
                    .multilineTextAlignment(.leading)
                
                ScrollView(.vertical, showsIndicators: true) {
                
                    ForEach(viewModel.unitList) { unit in
                            
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
                                    
                                    self.usecaseHandler?(.changeUnitAmount(unit.id, false))
                                    
                                }) {
                                    Image(systemName: Images.minusCircle.rawValue)
                                        .resizable()
                                        .frame(width: 25.0, height: 25.0, alignment: .center)
                                }
                                .accentColor(Colors.cyanLight)
                                
                                Text("\(unit.selectedAmount)")
                                    .font(Fonts.get(.osBold))
                                    .foregroundColor(Color.white)
                                
                                Button(action: {
                                    
                                    self.usecaseHandler?(.changeUnitAmount(unit.id, true))
                                    
                                }) {
                                    Image(systemName: Images.plusCircle.rawValue)
                                        .resizable()
                                        .frame(width: 25.0, height: 25.0, alignment: .center)
                                }
                                .accentColor(Colors.cyanLight)
                                
                            }
                            
                            Divider()
                                .background(Colors.blueColor)
                        
                        }
                        .padding()
                        
                    }
                    
                    SeaButton(title: "Megveszem", action: {
                        self.usecaseHandler?(.buyUnits)
                    })
                        .padding(.bottom, 30.0)
                    
                    if (viewModel.unitList.count == 0) {
                        HStack{
                            Spacer()
                        }
                    }
                    
                }
            }
            .padding([.horizontal, .top])
            .alert(isPresented: self.$viewModel.errorModel.alert) {
                Alert(title: Text(self.viewModel.errorModel.title), message: Text(self.viewModel.errorModel.message), dismissButton: .default(Text("Rendben")))
            }
            .onAppear {
                self.usecaseHandler?(.load)
            }
            .onReceive(SignalRService.shared.incomingSignalSubject) { _ in
                self.usecaseHandler?(.load)
            }
        }
    }
}

