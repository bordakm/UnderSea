//
//  BuildingsListView.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 28..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

extension Buildings {

    struct BuildingListView: View {
        
        @State
        private var selected = false
        
        lazy var interactor: Interactor = setInteractor()
        var setInteractor: (()->Interactor)!
        
        @ObservedObject var viewModel: ViewModelType
        
        let usecaseHandler: ((Buildings.Usecase) -> Void)?
        
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
                
                    ForEach(viewModel.buildingList) { building in
                        
                        Button(action: {
                                
                            self.usecaseHandler?(.buyBuilding(building.id))
                            
                        }) {
                            
                            ZStack(alignment: .topLeading) {
                                
                                if building.remainingRounds > 0 {
                                
                                    Text("még \(building.remainingRounds) kör")
                                        .font(Fonts.get(.osBold, 14))
                                        .foregroundColor(Colors.cyanLight)
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
                        .overlay(RoundedRectangle(cornerRadius: 16.0).stroke(lineWidth: 1.0).fill(Colors.whiteFullyTransparent))
                        .padding(.bottom, 5.0)
                        
                    }
                    
                    if (viewModel.buildingList.count == 0) {
                        HStack{
                            Spacer()
                        }
                    }
                    
                    Spacer(minLength: 16.0)
                    
                }.padding(.top, 10)
                
                //Image(uiImage: R.image.fighting()!)
            }
            .alert(isPresented: self.$viewModel.errorModel.alert) {
                Alert(title: Text(self.viewModel.errorModel.title), message: Text(self.viewModel.errorModel.message), dismissButton: .default(Text("Rendben")))
            }
            .onAppear {
                self.usecaseHandler?(.loadBuildings)
            }.onReceive(SignalRService.shared.incomingSignalSubject) { _ in
                self.usecaseHandler?(.loadBuildings)
            }
        }
    }
}
