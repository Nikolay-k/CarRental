import { Injectable } from "@angular/core";
import { NgbDateAdapter, NgbDateStruct, NgbDate } from "@ng-bootstrap/ng-bootstrap";

@Injectable()
export class NgbDateCustomAdapter implements NgbDateAdapter<string> {
    fromModel(value: string): NgbDateStruct {
        const d = new Date(value);
        return new NgbDate(d.getFullYear(), d.getMonth() + 1, d.getDate());
    }

    toModel(date: NgbDateStruct): string {
        if (!date)
            return "";

        const d = new Date(date.year, date.month - 1, date.day);
        const dString = new Date(d.getTime() - (d.getTimezoneOffset() * 60000)).toISOString().split("T")[0];
        return dString;
    }
}