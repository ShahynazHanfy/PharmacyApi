import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GetBalancesComponent } from './get-balances.component';

describe('GetBalancesComponent', () => {
  let component: GetBalancesComponent;
  let fixture: ComponentFixture<GetBalancesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GetBalancesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GetBalancesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
