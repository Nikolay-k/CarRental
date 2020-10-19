import { Directive, OnInit } from '@angular/core';
import { HttpService } from './../services/http.service';
import { GetFormResponseModel } from './../models/getform.responsemodel';
import { ResultResponseModel } from './../models/result.responsemodel';

@Directive()
export abstract class GetFormComponent<TModel, TBag> implements OnInit {
    constructor(protected readonly httpService: HttpService) { }

    protected getUrl = '';
    protected getQuery = '';
    model = {} as TModel;
    bag = {} as TBag;
    result = new ResultResponseModel();

    ngOnInit(): void {
        if (this.getUrl) {
            this.httpService.getForm<GetFormResponseModel<TModel, TBag>>(this.getUrl, this.getQuery)
                .subscribe(response => {
                    const responseModel = Object.assign(new GetFormResponseModel<TModel, TBag>(), response);
                    responseModel.result = Object.assign(new ResultResponseModel(), response.result);

                    this.model = responseModel.model;
                    this.bag = responseModel.bag;
                    this.result = responseModel.result;
                });
        }
    }
}
