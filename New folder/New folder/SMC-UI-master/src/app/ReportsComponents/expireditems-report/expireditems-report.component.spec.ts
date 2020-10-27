import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExpireditemsReportComponent } from './expireditems-report.component';

describe('ExpireditemsReportComponent', () => {
  let component: ExpireditemsReportComponent;
  let fixture: ComponentFixture<ExpireditemsReportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExpireditemsReportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExpireditemsReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
