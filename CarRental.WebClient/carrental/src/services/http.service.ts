import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
};

@Injectable()
export class HttpService {
    constructor(private readonly httpClient: HttpClient) { }

    getForm<TResponseModel>(url: string, query: any): Observable<TResponseModel> {
        return this.httpClient
            .get<TResponseModel>(url + query);
    }

    postForm<TResponseModel>(url: string, model: any): Observable<TResponseModel> {
        return this.httpClient
            .post<TResponseModel>(url, model, httpOptions);
    }

    deleteForm<TResponseModel>(url: string, query: any): Observable<TResponseModel> {
        return this.httpClient
            .delete<TResponseModel>(url + query, httpOptions);
    }
}
