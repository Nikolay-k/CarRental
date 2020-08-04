import { Injectable } from "@angular/core";
import { NgbDateParserFormatter, NgbDateStruct } from "@ng-bootstrap/ng-bootstrap";

@Injectable()
export class NgbDateCustomParserFormatter implements NgbDateParserFormatter {
    parse(): NgbDateStruct {
        throw new Error("Not implemented");
    }

    format(date: NgbDateStruct): string {
        if (!date)
            return "";

        const d = new Date(date.year, date.month - 1, date.day);
        const options = { year: "numeric", month: "short", day: "numeric" };
        return d.toLocaleDateString(undefined, options);
    }
}