import { Component, AfterViewInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements AfterViewInit {
  title = 'Castle';

  ngAfterViewInit() {
    const navElements = document.querySelectorAll('.nav-item-link');
    this.componentIsActive(navElements);
    navElements.forEach(el => {
      el.addEventListener('click', () => this.removeClassActive());
      el.addEventListener('click', () => this.addClassActive(el));
    });
  }

  private removeClassActive(): void {
    document.querySelectorAll('.nav-item-link').forEach(el => {
      el.classList.remove('active');
// tslint:disable-next-line: deprecation
      if (el === event.target && !el.classList.contains('active')) {
        el.classList.add('active');
      }
    });
  }

  private componentIsActive(navItems): void {
    if (window.location.href.indexOf('notes') !== -1) {
      this.addClassActive(navItems[1]);
    } else {
      this.addClassActive(navItems[0]);
    }
  }

  private addClassActive(element): void {
    element.classList.add('active');
  }
}
