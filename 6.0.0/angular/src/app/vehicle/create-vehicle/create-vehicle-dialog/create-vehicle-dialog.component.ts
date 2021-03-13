import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { AbpValidationError } from '@shared/components/validation/abp-validation.api';
import { CreateVehicleDto, VehicleServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-create-vehicle-dialog',
  templateUrl: './create-vehicle-dialog.component.html',
  styleUrls: ['./create-vehicle-dialog.component.css']
})
export class CreateVehicleDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  vehicle = new CreateVehicleDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _vehicleService: VehicleServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.vehicle.isActive = true;
  }

  save(): void {
    this.saving = true;
    this._vehicleService
      .create(this.vehicle)
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
