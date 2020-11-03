import { Component, Input } from '@angular/core';
import { ResultResponseModel } from './../models/result.responsemodel';

@Component({
    selector: 'app-form-response',
    templateUrl: './formresponse.component.html'
})
export class FormResponseComponent {
    @Input() model = new ResultResponseModel();
}
