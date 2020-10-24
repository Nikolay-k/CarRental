import { Component, OnInit } from '@angular/core';
import { HttpService } from './../../services/http.service';
import { GetFormComponent } from './../getform.component';
import { OrderListViewModel } from './../../models/order/order.viewmodel';
import { ResultResponseModel } from './../../models/result.responsemodel';

@Component({
    templateUrl: './orderlist.component.html'
})
export class OrderListComponent extends GetFormComponent<OrderListViewModel, never> implements OnInit {
    constructor(
        httpService: HttpService) {
        super(httpService);

        this.getUrl = '/api/Orders';
        this.model = new OrderListViewModel();
    }

    ngOnInit(): void {
        this.OnInit();
    }

    private getOrderIndexById(orderId: number): number {
        for (let i = 0; i < this.model.orders.length; i++) {
            if (this.model.orders[i].id === orderId) {
                return i;
            }
        }
        return -1;
    }

    deleteOrder(orderId: number): void {
        this.httpService.deleteForm<ResultResponseModel>('/api/Orders', `/${orderId}`)
            .subscribe(response => {
                const responseModel = Object.assign(new ResultResponseModel(), response);
                this.result = responseModel;
            });

        if (this.result.success) {
            const orderIndex = this.getOrderIndexById(orderId);
            if (orderIndex < 0) {
                return;
            }

            this.model.orders.splice(orderIndex, 1);
        }
    }
}
