import { Directive } from "@angular/core";
import { NG_VALUE_ACCESSOR, DefaultValueAccessor } from "@angular/forms";

@Directive({
    selector: "input[trim], textarea[trim]",
    providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: TrimDirective, multi: true }],
    host: {
        "(input)": "inputHandler($event.target.value)",
        "(blur)": "blurHandler($event.target.value)"
    }
})
export class TrimDirective extends DefaultValueAccessor {
    inputHandler(value: string): void {
        this.writeValue(value);
        this.onChange(value);
    }

    blurHandler(value: string): void {
        value = value.trim();
        this.writeValue(value);
        this.onChange(value);
        this.onTouched();
    }
}