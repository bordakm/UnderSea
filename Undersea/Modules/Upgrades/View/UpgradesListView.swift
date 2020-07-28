//
//  UpgradesListView.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 28..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI

extension Upgrades {

    struct UpgradesListView: View {
        
        @State
        private var selected = false
        
        lazy var interactor: Interactor = setInteractor()
        var setInteractor: (()->Interactor)!
        
        @ObservedObject var viewModel: ViewModelType
        
        let usecaseHandler: ((Upgrades.Usecase) -> Void)?
        
        var body: some View {
            VStack(spacing: 0) {
                
                VStack(alignment: .leading) {
                    Text("Jelöld ki, amelyiket szeretnéd megvenni.")
                        .font(Fonts.get(.osBold))
                        .foregroundColor(Color.white)
                    Text("Minden fejlesztés 15 kört vesz igénybe, egyszerre csak egy dolog fejleszthető és minden csak egyszer fejleszthető ki (nem lehet két kombájn).")
                        .font(Fonts.get(.osRegular))
                        .foregroundColor(Color.white)
                }.padding()
                
                ScrollView(.vertical, showsIndicators: true) {
                    
                    Color.clear.frame(height: 5.0)
                
                    ForEach(viewModel.upgradeList) { upgrade in
                        
                        Button(action: {
                                
                            self.usecaseHandler?(.buyUpgrade(upgrade.id))
                            
                        }) {
                            
                            ZStack(alignment: .topLeading) {
                            
                                VStack {
                                
                                    Image(upgrade.imageName)
                                        .renderingMode(.original)
                                        .frame(maxWidth: 200.0, maxHeight: 100.0)
                                    
                                    Text(upgrade.name)
                                        .frame(maxWidth: 280.0)
                                        .font(Fonts.get(.osBold))
                                        .foregroundColor(Color.white)
                                    
                                    Text(upgrade.description)
                                        .font(Fonts.get(.osRegular))
                                        .foregroundColor(Color.white)
                                        .multilineTextAlignment(.center)
                                        .fixedSize(horizontal: false, vertical: true)
                                
                                }
                                .padding()
                                
                                if upgrade.isPurchased {
                                    
                                    Image(systemName: "checkmark.circle.fill")
                                        .resizable()
                                        .frame(width: 20.0, height: 20.0)
                                        .foregroundColor(Colors.cyanLight)
                                        .padding()
                                    
                                } else if upgrade.remainingRounds > 0 {
                                
                                    Text("még \(upgrade.remainingRounds) kör")
                                        .font(Fonts.get(.osBold, 14))
                                        .foregroundColor(Colors.cyanLight)
                                        .padding()
                                
                                }
                            
                            }
                            
                        }
                        .frame(width: 310.0)
                        .overlay(RoundedRectangle(cornerRadius: 16.0).stroke(lineWidth: 1.0).fill(Colors.whiteFullyTransparent))
                        .padding(.bottom, 5.0)
                        
                    }
                    
                    if (viewModel.upgradeList.count == 0) {
                        HStack{
                            Spacer()
                        }
                    }
                    
                    Spacer(minLength: 30.0)
                    
                }.padding(.top, 10)
                
            }
            .alert(isPresented: self.$viewModel.errorModel.alert) {
                Alert(title: Text(self.viewModel.errorModel.title), message: Text(self.viewModel.errorModel.message), dismissButton: .default(Text("Rendben")))
            }
            .onAppear {
                self.usecaseHandler?(.loadUpgrades)
            }
            .onReceive(SignalRService.shared.incomingSignalSubject) { _ in
                self.usecaseHandler?(.loadUpgrades)
            }
        }
    }
    
}
