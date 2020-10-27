import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GetTransactiontypesComponent } from './get-transactiontypes.component';

describe('GetTransactiontypesComponent', () => {
  let component: GetTransactiontypesComponent;
  let fixture: ComponentFixture<GetTransactiontypesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GetTransactiontypesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GetTransactiontypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
