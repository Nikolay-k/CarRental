import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Observable, Subject, throwError } from "rxjs";
import { catchError } from "rxjs/operators";
import { environment } from "./../environments/environment";

const httpOptions = {
    headers: new HttpHeaders({
        "Content-Type": "application/json"
    })
};

@Injectable()
export class HttpService {
    constructor(private readonly http: HttpClient) { }

    postForm<TResponseModel>(url: string, model: any): Observable<TResponseModel> {
        return this.http
            .post<TResponseModel>(environment.virtualPath + url, model, httpOptions)
            .pipe(catchError(this.handleError.bind(this)));
    }

    getForm<TResponseModel>(url: string, query: any): Observable<TResponseModel> {
        return this.http
            .get<TResponseModel>(environment.virtualPath + url + query)
            .pipe(catchError(this.handleError.bind(this)));
    }

    deleteForm<TResponseModel>(url: string, query: any): Observable<TResponseModel> {
        return this.http
            .delete<TResponseModel>(environment.virtualPath + url + query, httpOptions)
            .pipe(catchError(this.handleError.bind(this)));
    }

    private userUnauthorizedSubject = new Subject<never>();

    get userUnauthorized(): Observable<never> {
        return this.userUnauthorizedSubject.asObservable();
    }

    private handleError(error: HttpErrorResponse): Observable<never> {
        if (error.error instanceof ErrorEvent) {
            // A client-side or network error occurred. Handle it accordingly.
            console.error("An error occurred:", error.error.message);
        } else {
            if (error.status === 401) { //Unauthorized
                this.userUnauthorizedSubject.next();
                return new Observable<never>();
            }
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong,
            console.error(`Backend returned code ${error.status}, message: ${error.message}`);
        }

        return throwError("Something bad happened; please try again later.");
    };
}