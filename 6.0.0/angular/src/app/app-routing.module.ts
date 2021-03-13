import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { UsersComponent } from './users/users.component';
import { TenantsComponent } from './tenants/tenants.component';
import { RolesComponent } from 'app/roles/roles.component';
import { ChangePasswordComponent } from './users/change-password/change-password.component';
import { VehicleComponent } from './vehicle/vehicle.component';
import { ProductCatagoryComponent } from './product-catagory/product-catagory.component';
import { ProductComponent } from './product/product.component';
import { OrderComponent } from './product/order/order.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: AppComponent,
                children: [
                    { path: 'home', component: HomeComponent, canActivate: [AppRouteGuard] },
                    { path: 'users', component: UsersComponent, data: { permission: 'Pages.Users' }, canActivate: [AppRouteGuard] },
                    { path: 'roles', component: RolesComponent, data: { permission: 'Pages.Roles' }, canActivate: [AppRouteGuard] },
                    { path: 'tenants', component: TenantsComponent, data: { permission: 'Pages.Tenants' }, canActivate: [AppRouteGuard] },
                    { path: 'about', component: AboutComponent },
                    { path: 'vehicle', component: VehicleComponent },
                    { path: 'product', component: ProductComponent, data: { permission: 'Pages.Product' }, canActivate: [AppRouteGuard] },
                    {
                        path: 'product-catagory', component: ProductCatagoryComponent,
                        data: { permission: 'Pages.ProductCatagory' }, canActivate: [AppRouteGuard]
                    },
                    { path: 'sale', component: OrderComponent },
                    { path: 'update-password', component: ChangePasswordComponent }
                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
