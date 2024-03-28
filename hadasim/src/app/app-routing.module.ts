import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { Patient } from './classes/Patient';
import { PatientsComponent } from './components/patients/patients.component';
import { EditComponent } from './components/edit/edit.component';
import { PatientDetailsComponent } from './components/patient-details/patient-details.component';

const routes: Routes = [
  {path:'Home', component:HomeComponent},
  {path:'Patients', component:PatientsComponent,children:[
    {path:'Edit/:id', component:EditComponent}
  ]},
  {path:'Details/:id',component:PatientDetailsComponent}



  // children:[
  //   {path:'Patients/:id',component:Patient}]
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
