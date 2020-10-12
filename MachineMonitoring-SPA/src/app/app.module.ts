import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MachineListComponent } from './machine/machine-list/machine-list.component';
import { MachineService } from './_Services/machine.service';
import {  HttpClientModule } from '@angular/common/http';
import { MachineDetailsComponent } from './machine/machine-details/machine-details.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
    MachineListComponent,
    MachineDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [MachineService],
  bootstrap: [AppComponent]
})
export class AppModule { }
