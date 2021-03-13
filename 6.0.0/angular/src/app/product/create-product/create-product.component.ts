import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { AppConsts } from '@shared/AppConsts';
import { CreateProductDto, GetProductCatagoryForDropDownDto, ProductServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';


@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css']
})
export class CreateProductComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  product = new CreateProductDto();
  productCatagories: GetProductCatagoryForDropDownDto[] = [];

  @Output() onSave = new EventEmitter<any>();

  fileName: any;
  productId = 0;
  imageSrc: string;
  uploadUrl: string;
  filesToUpload: File;


  constructor(
    injector: Injector,
    public _productService: ProductServiceProxy,
    public bsModalRef: BsModalRef,
    private _httpClient: HttpClient,
  ) {
    super(injector);
    this.uploadUrl = AppConsts.remoteServiceBaseUrl + '/api/File/UploadProductFiles';
  }

  ngOnInit() {
    this._productService.getProdcutCatagories().subscribe((result: GetProductCatagoryForDropDownDto[]) => {
      this.productCatagories = result;
    });
  }

  save(): void {
    this.saving = true;
    this._productService
      .create(this.product)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(res => {
        this.productId = res;
        if (this.productId > 0) {
          this.uploadFilesToServer();
        }

        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      });
  }



  uploadFile(event) {
    this.filesToUpload = event.target.files[0];
    this.fileName = event.target.files[0].name;

    // tslint:disable-next-line: prefer-const
    let reader = new FileReader();

    // tslint:disable-next-line: no-shadowed-variable
    reader.onload = (event: any) => {
      this.imageSrc = event.target.result;
    };

    reader.readAsDataURL(event.target.files[0]);
    // observe percentage changes
  }



  uploadFilesToServer() {
    const formData: FormData = new FormData();

    formData.append(this.filesToUpload.name, this.filesToUpload);

    formData.append('fileName', this.fileName);
    formData.append('productId', this.productId.toString());

    this._httpClient
      .post<any>(this.uploadUrl, formData)
      .pipe(finalize(() => { }))
      .subscribe(response => {
        if (response.success) {
          this.notify.success(this.l('File successfully uploaded to server.'));
        } else if (response.error != null) {
          this.notify.error(this.l('Upload failed.'));
        }
      });
  }



}
