export interface IBuildingsDto{
    id: number;
    name: string;
    description: string;
    count: number;
    price: number;
    imageUrl: string;
    remainingRounds: number;
}

export interface ICatsDto{
    type: string;
    text: string;
    status: {
        verified: boolean;
        sentCount: number;
    };
}