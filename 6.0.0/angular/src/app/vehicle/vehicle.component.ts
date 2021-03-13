import { Component, Injector, OnInit } from '@angular/core';
import { PagedListingComponentBase, PagedRequestDto, PagedResultDto } from '@shared/paged-listing-component-base';
import { GetVehicleForViewDto, GetVehicleForViewDtoPagedResultDto, VehicleServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { CreateVehicleDialogComponent } from './create-vehicle/create-vehicle-dialog/create-vehicle-dialog.component';
import { EditVehicleDialogComponent } from './edit-vehicle/edit-vehicle-dialog/edit-vehicle-dialog.component';


class PagedVehicleRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  styleUrls: ['./vehicle.component.scss']
})

export class VehicleComponent extends PagedListingComponentBase<GetVehicleForViewDto> {
  vehicles: GetVehicleForViewDto[] = [];
  sorting = '';
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;



  sortDir = 1; // 1= 'ASE' -1= DSC
  sortDirection = 'ASC';

  constructor(
    injector: Injector,
    private _vehicleService: VehicleServiceProxy,
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

  createVehicle(): void {
    this.showCreateOrEditVehicleDialog();
  }

  editVehicle(vehicle: GetVehicleForViewDto): void {
    this.showCreateOrEditVehicleDialog(vehicle.id);
  }
  protected delete(entity: GetVehicleForViewDto): void {
    throw new Error('Method not implemented.');
  }

  protected list(
    request: PagedVehicleRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._vehicleService
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
      .subscribe((result: GetVehicleForViewDtoPagedResultDto) => {
        this.vehicles = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  protected deleteVehicle(vehicle: GetVehicleForViewDto): void {
    abp.message.confirm(
      this.l('Vehicle Delete Warning Message', vehicle.carName),
      undefined,
      (result: boolean) => {
        if (result) {
          this._vehicleService.delete(vehicle.id).subscribe(() => {
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
        CreateVehicleDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditUserDialog = this._modalService.show(
        EditVehicleDialogComponent,
        {
          class: 'modal-lg',
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
