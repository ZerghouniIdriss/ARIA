import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
 import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { TimeSheetComponent } from './time-sheet/time-sheet.component';
import { CommonModule, DatePipe } from '@angular/common';
import { EmployeeComponent } from './employee/employee.component';
import { PaystubComponent } from './paystub/paystub.component';
import { MatDialogModule } from '@angular/material/dialog';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FetchDataComponent,
    TimeSheetComponent,
    EmployeeComponent,
    PaystubComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule, CommonModule,
    BrowserModule ,
    FormsModule,
    MatDialogModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
       { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
      { path: 'time-sheet', component: TimeSheetComponent  },
      { path: 'employee', component: EmployeeComponent  },
      { path: 'paystub', component: PaystubComponent  },


    ])
  ],
  providers: [ 
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }, DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
