import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { LstTruckComponent } from './truck/lst-truck/lst-truck.component';
import { FrmTruckComponent } from './truck/frm-truck/frm-truck.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    LstTruckComponent,
    FrmTruckComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: LstTruckComponent, pathMatch: 'full' },
      { path: 'frm-truck', component: FrmTruckComponent },
    ]),
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
