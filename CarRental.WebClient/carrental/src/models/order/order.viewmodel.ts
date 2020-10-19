import { SelectItemViewModel } from './../selectitem.viewmodel';

export class OrderViewModel {
    id = 0;
    userId = 0;
    userName = '';
    carId = 0;
    carName = '';
    rentalStartDate = '';
    rentalEndDate = '';
    comment = '';
}

export class OrderViewBag {
    users: SelectItemViewModel[] = [];
    cars: SelectItemViewModel[] = [];
}

export class OrderListViewModel {
    orders: OrderViewModel[] = [];
}
