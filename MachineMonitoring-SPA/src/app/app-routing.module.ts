import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MachineListComponent } from './machine/machine-list/machine-list.component';
import { MachineDetailsComponent } from './machine/machine-details/machine-details.component';


const routes: Routes = [
  {path: '', component: MachineListComponent},
  {path: 'machine/:id', component: MachineDetailsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
