import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CoronaVaccine } from 'src/app/classes/CoronaVaccine';
import { Patient } from 'src/app/classes/Patient';
import { PatientAddress } from 'src/app/classes/PatientAddress';
import { Producer } from 'src/app/classes/Producter';
import { Serologion } from 'src/app/classes/Serologion';
import { Vaccine } from 'src/app/classes/Vaccine';
import { PatientService } from 'src/assets/services/patient.service';
import { EditComponent } from '../edit/edit.component';

@Component({
  selector: 'app-patients',
  templateUrl: './patients.component.html',
  styleUrls: ['./patients.component.css']
})
export class PatientsComponent implements OnInit{

  patients:Array<Patient> = Array<Patient>()
  // serologions:Array<Serologion> = Array<Serologion>()
  // coronaVaccines:Array<CoronaVaccine> = Array<CoronaVaccine>()
  // vaccines:Array<Vaccine> = Array<Vaccine>()
  // patient_addresses:Array<PatientAddress> = Array<PatientAddress>()
  // producers:Array<Producer> = Array<Producer>()

  constructor(public router:Router, public ptServ:PatientService, public edit:EditComponent) {}
  pId:string = '0'
  ngOnInit(): void {
    this.ptServ.getAll().subscribe(
      s =>{
        this.patients = s.filter(x=>x.Status==true)
        this.ptServ.all = s
        // alert("the patients were loaded successfully")
      },
      e=>{
        alert("there is error on patients loading:" + e)
      }
    )
    this.edit_pt('0')
  }

  edit_pt(id:string){
    this.pId = id
    this.router.navigate([`Patients/Edit/${id}`])
    // debugger
    // this.edit.ngOnInit()
    // this.edit.patient_data(id)
    this.pId = id
  }

  details_pt(id:string) {
    this.pId = id
    this.router.navigate([`Details/${this.pId = id}`])
  }

}
