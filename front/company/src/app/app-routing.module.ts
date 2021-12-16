import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeComponent } from './employee/employee.component';
import { DepartamentComponent } from './departament/departament.component';


const routes: Routes = [

  {path:'employee',component:EmployeeComponent},
  {path:'departament',component:DepartamentComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
