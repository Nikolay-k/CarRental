import { HttpService } from './../services/http.service';
import { GetFormResponseModel } from './../models/getform.responsemodel';
import { ResultResponseModel } from './../models/result.responsemodel';

export abstract class GetFormComponent<TModel, TBag> {
    constructor(protected readonly httpService: HttpService) { }

    protected getUrl = '';
    protected getQuery = '';
    model = {} as TModel;
    bag = {} as TBag;
    result = new ResultResponseModel();

    protected OnInit(): void {
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
