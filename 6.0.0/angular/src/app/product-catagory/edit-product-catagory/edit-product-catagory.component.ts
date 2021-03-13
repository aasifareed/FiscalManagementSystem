import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { EditProductCatagoryDto, ProductCatagoryServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-edit-product-catagory',
  templateUrl: './edit-product-catagory.component.html',
  styleUrls: ['./edit-product-catagory.component.css']
})
export class EditProductCatagoryComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  productCatagory = new EditProductCatagoryDto();

  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _productCatagoryService: ProductCatagoryServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._productCatagoryService.getEntityById(this.id).subscribe((result) => {
      this.productCatagory = result;
    });
  }

  save(): void {
    this.saving = true;

    this._productCatagoryService
      .update(this.productCatagory)
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
