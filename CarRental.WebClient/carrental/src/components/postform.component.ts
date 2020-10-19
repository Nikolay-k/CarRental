import { Directive, OnInit } from '@angular/core';
import { HttpService } from './../services/http.service';
import { GetFormResponseModel } from './../models/getform.responsemodel';
import { PostFormResponseModel } from './../models/postform.responsemodel';
import { ResultResponseModel } from './../models/result.responsemodel';

@Directive()
export abstract class PostFormComponent<TModel, TBag, TPostFormResponseModel extends PostFormResponseModel> implements OnInit {
    constructor(private readonly httpService: HttpService) { }

    protected getUrl = '';
    protected getQuery = '';
    protected postUrl = '';
    model = {} as TModel;
    bag = {} as TBag;
    result = new ResultResponseModel();
    protected onPostFormResponseReceived?: ((responseModel: TPostFormResponseModel) => void);

    protected createDefaultPostFormResponseModel(): TPostFormResponseModel {
        return new PostFormResponseModel() as TPostFormResponseModel;
    }

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

    onSubmit(): void {
        this.httpService.postForm<TPostFormResponseModel>(this.postUrl, this.model)
            .subscribe(response => {
                const responseModel = Object.assign(this.createDefaultPostFormResponseModel(), response);
                responseModel.result = Object.assign(new ResultResponseModel(), response.result);

                this.result = responseModel.result;

                if (this.onPostFormResponseReceived) {
                    this.onPostFormResponseReceived(responseModel);
                }
            });
    }
}
