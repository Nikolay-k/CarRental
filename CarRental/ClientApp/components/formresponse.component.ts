import { Component, Input } from "@angular/core";
import { ResultResponseModel } from "./../models/result.responsemodel";

@Component({
    selector: "form-response",
    templateUrl: "./../templates/FormResponseComponent.{culture}.html"
})
export class FormResponseComponent {
    @Input() model = new ResultResponseModel();
}
