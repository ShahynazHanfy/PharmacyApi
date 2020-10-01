import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GetSubgroupsComponent } from './get-subgroups.component';

describe('GetSubgroupsComponent', () => {
  let component: GetSubgroupsComponent;
  let fixture: ComponentFixture<GetSubgroupsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GetSubgroupsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GetSubgroupsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
