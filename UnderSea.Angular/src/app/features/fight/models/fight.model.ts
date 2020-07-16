export interface IFightUnitsViewModel{
    cityName: string;
    units: ISimpleUnitViewModel[];
}

export interface ISimpleUnitViewModel{
    type: number;
    count: number;
}


