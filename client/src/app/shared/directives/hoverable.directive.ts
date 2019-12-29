import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
   selector: 'hoverable'
})
export class HoverableDirective {

   constructor(private el: ElementRef) {
   }

   @HostListener('mouseenter')
   onMouseEnter() {
      (this.el.nativeElement as HTMLElement).style.backgroundColor = '#444444';
   }
}
