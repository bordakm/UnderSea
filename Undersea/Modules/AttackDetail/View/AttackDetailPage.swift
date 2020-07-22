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
                    AttackDetailAnimalCell(animal: animal)
                }
            }
            .frame(maxWidth: .infinity, maxHeight: .infinity, alignment: .topLeading)
            .padding()
            .background(Colors.backgroundColor)
            .navigationBarTitle("Támadás", displayMode: .inline)
            .navigationBarColor(Colors.navBarBackgroundColor)
            .onAppear {
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
