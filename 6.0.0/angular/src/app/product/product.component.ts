import { Component, Injector, OnInit } from '@angular/core';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { GetProductForViewDto, GetProductForViewDtoPagedResultDto, ProductServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { CreateProductComponent } from './create-product/create-product.component';
import { EditProductComponent } from './edit-product/edit-product.component';


class PagedProductRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}
@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent extends PagedListingComponentBase<GetProductForViewDto> {
  products: GetProductForViewDto[] = [];
  sorting = '';
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;



  sortDir = 1; // 1= 'ASE' -1= DSC
  sortDirection = 'ASC';

  constructor(
    injector: Injector,
    private _productService: ProductServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }


  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }
  onSortClick(event: any, columnName: any) {
    const target = event.currentTarget,
      classList = target.classList;

    if (classList.contains('fa-chevron-up')) {
      classList.remove('fa-chevron-up');
      classList.add('fa-chevron-down');
      this.sortDir = -1;
      this.sortDirection = 'DESC';
    } else {
      classList.add('fa-chevron-up');
      classList.remove('fa-chevron-down');
      this.sortDir = 1;
      this.sortDirection = 'ASC';
    }
    this.sortArr(columnName);
  }

  sortArr(colName: any) {
    this.sorting = colName + ' ' + this.sortDirection;

    this.getDataPage(1);
  }

  create(): void {
    this.showCreateOrEditProductDialog();
  }

  edit(vehicle: GetProductForViewDto): void {
    this.showCreateOrEditProductDialog(vehicle.id);
  }



  protected list(
    request: PagedProductRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._productService
      .getAll(
        request.keyword,
        0,
        this.sorting,
        request.skipCount,
        request.maxResultCount
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: GetProductForViewDtoPagedResultDto) => {

        result.items.forEach(element => {
          element.imagePath = 'data:image/jpeg;base64,' + element.fileInByte;
        });

        this.products = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  protected delete(productCatagory: GetProductForViewDto): void {
    abp.message.confirm(
      this.l('Product Catagory Delete Warning Message', productCatagory.name),
      undefined,
      (result: boolean) => {
        if (result) {
          this._productService.delete(productCatagory.id).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }


  private showCreateOrEditProductDialog(id?: number): void {
    let createOrEditUserDialog: BsModalRef;
    if (!id) {
      createOrEditUserDialog = this._modalService.show(
        CreateProductComponent,
        {
          class: 'modal-lg',
          backdrop: 'static',
          keyboard: false
        }
      );
    } else {
      createOrEditUserDialog = this._modalService.show(
        EditProductComponent,
        {
          class: 'modal-lg',
          backdrop: 'static',
          keyboard: false,
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditUserDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

}
