import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
// import { CoronaVaccine } from 'src/app/classes/CoronaVaccine';
// import { Patient } from 'src/app/classes/Patient';
// import { PatientAddress } from 'src/app/classes/PatientAddress';
// import { Producer } from 'src/app/classes/Producter';
// import { Serologion } from 'src/app/classes/Serologion';
// import { Vaccine } from 'src/app/classes/Vaccine';
// import { CoronaVaccinesService } from 'src/assets/services/corona-vaccines.service';
// import { PatientAddressService } from 'src/assets/services/patient-address.service';
import { PatientService } from 'src/assets/services/patient.service';
// import { ProducerService } from 'src/assets/services/producer.service';
// import { SerologicService } from 'src/assets/services/serologic.service';
// import { VaccineService } from 'src/assets/services/vaccine.service';

@Component({
  selector: 'app-patient-details',
  templateUrl: './patient-details.component.html',
  styleUrls: ['./patient-details.component.css']
})
export class PatientDetailsComponent implements OnInit{

  constructor(public acr:ActivatedRoute, public ptServ:PatientService){}
  id:string = ''
  // patient?:Patient = undefined
  // serologic?:Serologion = undefined
  // corona_vaccines?:CoronaVaccine = undefined
  // address?:PatientAddress = undefined
  // vaccines: Array<Vaccine> = Array<Vaccine>()
  // producers:Array<Producer> = Array<Producer>()
  ngOnInit(): void {
    this.acr.params.subscribe(p=>{
      this.id = p['id']
      
    } )

  }

  delete_pt() {
    this.ptServ.delete(this.id).subscribe(
      s=>{
        alert(s)
      },
      e=>{
        alert('error'+ e)
      }
    )
  }

}
