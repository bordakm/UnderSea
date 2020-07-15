export interface IBuildingsViewModel {
    name: string;
    count: number;
    price: number;
    givenMembers?: number;
    bearedFood?: number;
    givenShelter?: number;
}

export interface ICatsViewModel{
    type: string;
    text: string;
    status: {
        verified: boolean;
        sentCount: number;
    };
}
