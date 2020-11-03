import { Component, OnInit } from '@angular/core';
import { HttpService } from './../../services/http.service';
import { GetFormComponent } from './../getform.component';
import { CarListViewModel } from './../../models/car/car.viewmodel';

@Component({
    templateUrl: './carlist.component.html'
})
export class CarListComponent extends GetFormComponent<CarListViewModel, never> implements OnInit {
    constructor(
        httpService: HttpService) {
        super(httpService);

        this.getUrl = 'cars';
        this.model = new CarListViewModel();
    }

    ngOnInit(): void {
        this.OnInit();
    }
}
