export class CarViewModel {
    id = 0;
    brand = '';
    model = '';
    class = '';
    issueYear = 0;
    registrationNumber = '';
}

export class CarListViewModel {
    cars: CarViewModel[] = [];
}
