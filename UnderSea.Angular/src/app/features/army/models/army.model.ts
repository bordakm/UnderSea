export interface IArmyViewModel {
    id: number;
    name: string;
    count: number;
    price: number;
    attackScore: number;
    defenseScore: number;
    pearlCostPerTurn: number;
    coralCostPerTurn: number;
    imageUrl: string;
    purchaseCount?: number;
}

