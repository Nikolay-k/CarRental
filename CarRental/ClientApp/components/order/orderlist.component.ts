import { Component } from "@angular/core";
import { HttpService } from "./../../services/http.service";
import { GetFormComponent } from "./../getform.component";
import { OrderListViewModel } from "./../../models/order/order.viewmodel";
import { ResultResponseModel } from "./../../models/result.responsemodel";

@Component({
    templateUrl: "./../../templates/Order/OrderListComponent.{culture}.html"
})
export class OrderListComponent extends GetFormComponent<OrderListViewModel, never> {
    constructor(
        httpService: HttpService) {
        super(httpService);

        this.getUrl = "/api/Orders";
        this.model = new OrderListViewModel();
    }

    private getOrderIndexById(orderId: number): number {
        for (let i = 0; i < this.model.orders.length; i++) {
            if (this.model.orders[i].id === orderId) {
                return i;
            }
        }
        return -1;
    }

    deleteOrder(orderId: number) {
        this.httpService.deleteForm<ResultResponseModel>("/api/Orders", `/${orderId}`)
            .subscribe(response => {
                var responseModel = Object.assign(new ResultResponseModel(), response);
                this.result = responseModel;
            });

        if (this.result.success) {
            const orderIndex = this.getOrderIndexById(orderId);
            if (orderIndex < 0)
                return;

            this.model.orders.splice(orderIndex, 1);
        }
    }
}