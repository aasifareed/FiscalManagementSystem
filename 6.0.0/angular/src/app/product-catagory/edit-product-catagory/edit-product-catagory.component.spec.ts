import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditProductCatagoryComponent } from './edit-product-catagory.component';

describe('EditProductCatagoryComponent', () => {
  let component: EditProductCatagoryComponent;
  let fixture: ComponentFixture<EditProductCatagoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditProductCatagoryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditProductCatagoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
