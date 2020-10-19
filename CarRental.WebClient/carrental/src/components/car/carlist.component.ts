import { Component } from '@angular/core';
import { HttpService } from './../../services/http.service';
import { GetFormComponent } from './../getform.component';
import { CarListViewModel } from './../../models/car/car.viewmodel';

@Component({
    templateUrl: './carlist.component.html'
})
export class CarListComponent extends GetFormComponent<CarListViewModel, never> {
    constructor(
        httpService: HttpService) {
        super(httpService);

        this.getUrl = '/api/Cars';
        this.model = new CarListViewModel();
    }
}
