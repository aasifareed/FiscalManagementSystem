import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { EditProductDto, GetProductCatagoryForDropDownDto, ProductServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  product = new EditProductDto();
  productCatagories: GetProductCatagoryForDropDownDto[] = [];

  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _productService: ProductServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._productService.getEntityById(this.id).subscribe((result) => {
      this.product = result;
    });

    this._productService.getProdcutCatagories().subscribe((result: GetProductCatagoryForDropDownDto[]) => {
      this.productCatagories = result;
    });
  }

  save(): void {
    this.saving = true;

    this._productService
      .update(this.product)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      });
  }

}
