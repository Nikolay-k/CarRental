import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from "@angular/forms";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";

import { AppRoutingModule } from "./app-routing.module";

import { HttpService } from "./../services/http.service";
import { NgbDateAdapter, NgbDateParserFormatter } from "@ng-bootstrap/ng-bootstrap";
import { NgbDateCustomAdapter } from "./../services/ngbdatecustomadapter";
import { NgbDateCustomParserFormatter } from "./../services/ngbdatecustomparserformatter";

import { AppComponent } from "./../components/app.component";
import { NavBarComponent } from "./../components/navbar.component";
import { FormResponseComponent } from "./../components/formresponse.component";
import { UserListComponent } from "./../components/user/userlist.component";
import { CarListComponent } from "./../components/car/carlist.component";
import { OrderListComponent } from "./../components/order/orderlist.component";
import { OrderEditComponent } from "./../components/order/orderedit.component";

import { TrimDirective } from "./../directives/trim.directive";
import { HasInputGroupDirective } from "./../directives/hasinputgroup.directive";

@NgModule({
    imports: [
        BrowserModule,
        HttpClientModule,
        FormsModule,
        NgbModule,
        AppRoutingModule
    ],
    providers: [
        HttpService,
        { provide: NgbDateAdapter, useClass: NgbDateCustomAdapter },
        { provide: NgbDateParserFormatter, useClass: NgbDateCustomParserFormatter }
    ],
    declarations: [
        AppComponent,
        NavBarComponent,
        FormResponseComponent,
        UserListComponent,
        CarListComponent,
        OrderListComponent,
        OrderEditComponent,
        TrimDirective,
        HasInputGroupDirective
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }