import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SubgroupDetailsComponent } from './subgroup-details.component';

describe('SubgroupDetailsComponent', () => {
  let component: SubgroupDetailsComponent;
  let fixture: ComponentFixture<SubgroupDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SubgroupDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SubgroupDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
