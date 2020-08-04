import { Directive, Renderer2, ElementRef } from "@angular/core";

@Directive({
    selector: "input.has-input-group",
    host: {
        "(focus)": "focusHandler()",
        "(blur)": "blurHandler()"
    }
})
export class HasInputGroupDirective {
    constructor(
        private readonly renderer: Renderer2,
        hostElement: ElementRef) {
        const parentElement = renderer.parentNode(hostElement.nativeElement);
        if (parentElement.classList.contains("input-group"))
            this.inputGroupElement = parentElement;
    }

    private readonly inputGroupElement: any;

    focusHandler(): void {
        if (this.inputGroupElement)
            this.renderer.addClass(this.inputGroupElement, "input-group-focus");
    }

    blurHandler(): void {
        if (this.inputGroupElement)
            this.renderer.removeClass(this.inputGroupElement, "input-group-focus");
    }
}