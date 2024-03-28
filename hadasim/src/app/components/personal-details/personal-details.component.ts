import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Patient } from 'src/app/classes/Patient';
import { PatientAddress } from 'src/app/classes/PatientAddress';
import { CoronaVaccinesService } from 'src/assets/services/corona-vaccines.service';
import { PatientAddressService } from 'src/assets/services/patient-address.service';
import { PatientService } from 'src/assets/services/patient.service';
import { SerologicService } from 'src/assets/services/serologic.service';
import { VaccineService } from 'src/assets/services/vaccine.service';

@Component({
  selector: 'app-personal-details',
  templateUrl: './personal-details.component.html',
  styleUrls: ['./personal-details.component.css']
})
export class PersonalDetailsComponent implements OnInit {
  constructor(public acr:ActivatedRoute,
    public ptServ:PatientService,
    public adsServ:PatientAddressService,
    ){}
  patient?:Patient = undefined
  address?:PatientAddress = undefined
  @Input() Patientid:string =''
  ngOnInit(): void {
    this.ptServ.get(this.Patientid).subscribe(
      s=>{
        this.patient = s
        if(s.AddressId)
        this.adsServ.get(s.AddressId).subscribe(
          ad=>{
            this.address = ad
          },
          e=>{
            alert("cannot get the "+s.AddressId+"address"+e)
            this.address = this.adsServ.all.find(x=> x.Id == s.AddressId)
          }
        )
      },
      e=>{
        alert("cannot get the "+this.Patientid+"patient"+e)
        this.patient = this.ptServ.all.find(x=> x.Id == this.Patientid)
      }
    )
    
    }



}
