import { SelectItemViewModel } from "./../../models/selectitem.viewmodel";

export class OrderViewModel {
    id: number = 0;
    userId: number = 0;
    userName: string = "";
    carId: number = 0;
    carName: string = "";
    rentalStartDate: string = "";
    rentalEndDate: string = "";
    comment: string = "";
}

export class OrderViewBag {
    users: SelectItemViewModel[] = [];
    cars: SelectItemViewModel[] = [];
}

export class OrderListViewModel {
    orders: OrderViewModel[] = [];
}