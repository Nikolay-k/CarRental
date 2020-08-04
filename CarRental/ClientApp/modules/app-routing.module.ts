import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { UserListComponent } from "./../components/user/userlist.component";
import { CarListComponent } from "./../components/car/carlist.component";
import { OrderListComponent } from "./../components/order/orderlist.component";
import { OrderEditComponent } from "./../components/order/orderedit.component";

const appRoutes: Routes = [
    { path: "users", component: UserListComponent },
    { path: "cars", component: CarListComponent },
    { path: "orders", component: OrderListComponent },
    { path: "orders/:id", component: OrderEditComponent },
    { path: "", redirectTo: "/orders", pathMatch: "full" }
];

@NgModule({
    imports: [
        RouterModule.forRoot(appRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule { }