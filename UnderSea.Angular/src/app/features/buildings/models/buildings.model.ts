export interface IBuildingsViewModel {
    name: string;
    count: number;
    price: number;
    description?: string | undefined;
    imageUrl?: string | undefined;
    remainingRounds?: number;
}

export interface ICatsViewModel{
    type: string;
    text: string;
    status: {
        verified: boolean;
        sentCount: number;
    };
}
