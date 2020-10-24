import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpService } from './../../services/http.service';
import { PostFormComponent } from './../postform.component';
import { OrderViewModel, OrderViewBag } from './../../models/order/order.viewmodel';
import { PostFormResponseModel } from './../../models/postform.responsemodel';

@Component({
    templateUrl: './orderedit.component.html'
})
export class OrderEditComponent extends PostFormComponent<OrderViewModel, OrderViewBag, PostFormResponseModel> implements OnInit {
    constructor(
        private readonly route: ActivatedRoute,
        private readonly router: Router,
        httpService: HttpService) {
        super(httpService);

        this.getUrl = 'orders';
        const id = this.route.snapshot.paramMap.get('id');
        this.getQuery = `/${id}`;
        this.postUrl = 'orders';
        this.model = new OrderViewModel();
        this.bag = new OrderViewBag();
        this.onPostFormResponseReceived = () => this.postFormResponseReceivedHandler();
    }

    ngOnInit(): void {
        this.OnInit();
    }

    private postFormResponseReceivedHandler(): void {
        if (this.result.success) {
            this.router.navigate(['/orders']);
        }
    }
}
