import { Component } from "@angular/core";
import { HttpService } from "./../../services/http.service";
import { GetFormComponent } from "./../getform.component";
import { UserListViewModel } from "./../../models/user/user.viewmodel";

@Component({
    templateUrl: "./../../templates/User/UserListComponent.{culture}.html"
})
export class UserListComponent extends GetFormComponent<UserListViewModel, never> {
    constructor(
        httpService: HttpService) {
        super(httpService);

        this.getUrl = "/api/Users";
        this.model = new UserListViewModel();
    }
}