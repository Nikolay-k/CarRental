export class CarViewModel {
    id: number = 0;
    brand: string = "";
    model: string = "";
    class: string = "";
    issueYear: number = 0;
    registrationNumber: string = "";
}

export class CarListViewModel {
    cars: CarViewModel[] = [];
}