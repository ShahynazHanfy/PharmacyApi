import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GroupSubgroupComponent } from './group-subgroup.component';

describe('GroupSubgroupComponent', () => {
  let component: GroupSubgroupComponent;
  let fixture: ComponentFixture<GroupSubgroupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GroupSubgroupComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GroupSubgroupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
