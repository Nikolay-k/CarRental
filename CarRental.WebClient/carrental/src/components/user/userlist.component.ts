import { Component, OnInit } from '@angular/core';
import { HttpService } from './../../services/http.service';
import { GetFormComponent } from './../getform.component';
import { UserListViewModel } from './../../models/user/user.viewmodel';

@Component({
    templateUrl: './userlist.component.html'
})
export class UserListComponent extends GetFormComponent<UserListViewModel, never> implements OnInit {
    constructor(
        httpService: HttpService) {
        super(httpService);

        this.getUrl = 'users';
        this.model = new UserListViewModel();
    }

    ngOnInit(): void {
        this.OnInit();
    }
}
