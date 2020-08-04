﻿import { Component } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { HttpService } from "./../../services/http.service";
import { PostFormComponent } from "./../postform.component";
import { OrderViewModel, OrderViewBag } from "./../../models/order/order.viewmodel";
import { PostFormResponseModel } from "./../../models/postform.responsemodel"

@Component({
    templateUrl: "./../../templates/Order/OrderEditComponent.{culture}.html"
})
export class OrderEditComponent extends PostFormComponent<OrderViewModel, OrderViewBag, PostFormResponseModel> {
    constructor(
        private readonly route: ActivatedRoute,
        private readonly router: Router,
        httpService: HttpService) {
        super(httpService);

        this.getUrl = "/api/Orders";
        const id = this.route.snapshot.paramMap.get("id");
        this.getQuery = `/${id}`;
        this.postUrl = "/api/Orders";
        this.model = new OrderViewModel();
        this.bag = new OrderViewBag();
        this.onPostFormResponseReceived = () => this.postFormResponseReceivedHandler();
    }

    private postFormResponseReceivedHandler(): void {
        if (this.result.success) {
            this.router.navigate(["/orders"]);
        }
    }
}