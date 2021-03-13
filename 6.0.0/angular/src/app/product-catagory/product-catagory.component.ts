import { Component, Injector, OnInit } from '@angular/core';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { GetProductCatagoryForViewDto, GetProductCatagoryForViewDtoPagedResultDto, ProductCatagoryServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { CreatProductCatagoryComponent } from './creat-product-catagory/creat-product-catagory.component';
import { EditProductCatagoryComponent } from './edit-product-catagory/edit-product-catagory.component';

class PagedProductCatagoryRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  selector: 'app-product-catagory',
  templateUrl: './product-catagory.component.html',
  styleUrls: ['./product-catagory.component.css']
})
export class ProductCatagoryComponent extends PagedListingComponentBase<GetProductCatagoryForViewDto> {
  productCatagories: GetProductCatagoryForViewDto[] = [];
  sorting = '';
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;



  sortDir = 1; // 1= 'ASE' -1= DSC
  sortDirection = 'ASC';

  constructor(
    injector: Injector,
    private _productCatagoryService: ProductCatagoryServiceProxy,
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
    this.showCreateOrEditVehicleDialog();
  }

  edit(vehicle: GetProductCatagoryForViewDto): void {
    this.showCreateOrEditVehicleDialog(vehicle.id);
  }


  protected list(
    request: PagedProductCatagoryRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._productCatagoryService
      .getAll(
        request.keyword,
        this.sorting,
        request.skipCount,
        request.maxResultCount
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: GetProductCatagoryForViewDtoPagedResultDto) => {

        result.items.forEach(element => {
          element.imagePath = 'data:image/jpeg;base64,' + element.fileInByte;
        });

        this.productCatagories = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  protected delete(productCatagory: GetProductCatagoryForViewDto): void {
    abp.message.confirm(
      this.l('Product Catagory Delete Warning Message', productCatagory.name),
      undefined,
      (result: boolean) => {
        if (result) {
          this._productCatagoryService.delete(productCatagory.id).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }


  private showCreateOrEditVehicleDialog(id?: number): void {
    let createOrEditUserDialog: BsModalRef;
    if (!id) {
      createOrEditUserDialog = this._modalService.show(
        CreatProductCatagoryComponent,
        {
          class: 'modal-lg',
          backdrop: 'static',
          keyboard: false
        }
      );
    } else {
      createOrEditUserDialog = this._modalService.show(
        EditProductCatagoryComponent,
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
