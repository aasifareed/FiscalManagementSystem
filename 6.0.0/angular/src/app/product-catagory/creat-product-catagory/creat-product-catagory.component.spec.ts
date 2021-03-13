import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatProductCatagoryComponent } from './creat-product-catagory.component';

describe('CreatProductCatagoryComponent', () => {
  let component: CreatProductCatagoryComponent;
  let fixture: ComponentFixture<CreatProductCatagoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreatProductCatagoryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreatProductCatagoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
