import { ResultResponseModel } from "./../models/result.responsemodel";

export class GetFormResponseModel<TModel, TBag> {
    model = {} as TModel;
    bag = {} as TBag;
    result = new ResultResponseModel();
}