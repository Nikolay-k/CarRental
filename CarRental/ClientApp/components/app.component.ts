import { Component } from "@angular/core";

@Component({
    selector: "app",
    template: `
        <nav-bar></nav-bar>
        <div class="container">
            <router-outlet></router-outlet>
            <hr />
            <footer>
                <div>&copy; {{currentYear}} - CarRental</div>
            </footer>
        </div>
        `
})
export class AppComponent {
    readonly currentYear = new Date().getFullYear();
}