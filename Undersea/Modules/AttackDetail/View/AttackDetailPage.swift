//
//  AttackDetailPage.swift
//  Undersea
//
//  Created by Vekety Robin on 2020. 07. 14..
//  Copyright © 2020. Vekety Robin. All rights reserved.
//

import SwiftUI


extension AttackDetail {

    struct AttackDetailPage: View {
        
        @Environment(\.presentationMode)
        var presentationMode: Binding<PresentationMode>
        
        lazy var interactor: Interactor = setInteractor()
        var setInteractor: (()->Interactor)!
        
        @ObservedObject var viewModel: ViewModelType
        
        var usecaseHandler: ((AttackDetail.Usecase) -> Void)?
        
        @State var sliderValue = 0.0
        
        var body: some View {
            VStack(alignment: .leading, spacing: 30.0) {
                VStack(alignment: .leading) {
                    Text("2. Lépés")
                        .font(Fonts.get(.osBold))
                        .foregroundColor(Color.white)
                    Text("Állítsd be, kiket küldesz harcba:")
                        .font(Fonts.get(.osRegular))
                        .foregroundColor(Color.white)
                }
                ForEach(viewModel.animalList) { animal in
                    AttackDetailAnimalCell(animal: animal, usecaseHandler: self.usecaseHandler)
                }
                Spacer()
                SeaButton(title: "Megtámadom") {
                    self.usecaseHandler?(.attack)
                }
                .frame(minWidth: 0, maxWidth: .infinity, alignment: .center)
            }
            .frame(maxWidth: .infinity, maxHeight: .infinity, alignment: .topLeading)
            .padding()
            .background(Colors.deepBlue)
            .navigationBarTitle("Támadás", displayMode: .inline)
            .navigationBarColor(Colors.darkBlueUI)
            .alert(isPresented: self.$viewModel.errorModel.alert) {
                Alert(title: Text(self.viewModel.errorModel.title), message: Text(self.viewModel.errorModel.message), dismissButton: .default(Text("Rendben")))
            }
            .onAppear {
                self.usecaseHandler?(.load)
            }
            .onReceive(viewModel.shouldPopBack) { _ in
                self.presentationMode.wrappedValue.dismiss()
            }
            .onReceive(SignalRService.shared.incomingSignalSubject) { _ in
                self.usecaseHandler?(.load)
            }
            
        }
        
    }
    
}

/*
struct AttackDetailPage_Previews: PreviewProvider {
    static var previews: some View {
        AttackDetail.AttackDetailPage()
    }
}
*/
