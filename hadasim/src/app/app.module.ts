import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { PatientsComponent } from './components/patients/patients.component';
import { MenuComponent } from './components/menu/menu.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { EditComponent } from './components/edit/edit.component';
import { PatientDetailsComponent } from './components/patient-details/patient-details.component';
import { PersonalDetailsComponent } from './components/personal-details/personal-details.component';
import { CovidDetailsComponent } from './components/covid-details/covid-details.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ChartsModule } from 'ng2-charts';



@NgModule({
  declarations: [
    AppComponent,
    PatientsComponent,
    HomeComponent,
    MenuComponent,
    EditComponent,
    PatientDetailsComponent,
    PersonalDetailsComponent,
    CovidDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule  
  ],
  providers: [
    EditComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
