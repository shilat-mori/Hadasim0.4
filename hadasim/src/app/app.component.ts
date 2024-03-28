import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Patient } from './classes/Patient';
import { Serologion } from './classes/Serologion';
import { CoronaVaccine } from './classes/CoronaVaccine';
import { Vaccine } from './classes/Vaccine';
import { PatientAddress } from './classes/PatientAddress';
import { Producer } from './classes/Producter';
import { PatientService } from 'src/assets/services/patient.service';
import { CoronaVaccinesService } from 'src/assets/services/corona-vaccines.service';
import { SerologicService } from 'src/assets/services/serologic.service';
import { VaccineService } from 'src/assets/services/vaccine.service';
import { ProducerService } from 'src/assets/services/producer.service';
import { PatientAddressService } from 'src/assets/services/patient-address.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  constructor( public router: Router,
    public ptServ:PatientService,
    public cvServ:CoronaVaccinesService,
    public srlServ:SerologicService,
    public adsServ:PatientAddressService,
    public vccServ:VaccineService,
    public pdServ:ProducerService
    ) {}
  title = 'HMO corona';
  // patients:Array<Patient> = Array<Patient>()
  // serologions:Array<Serologion> = Array<Serologion>()
  // coronaVaccines:Array<CoronaVaccine> = Array<CoronaVaccine>()
  // vaccines:Array<Vaccine> = Array<Vaccine>()
  // patient_addresses:Array<PatientAddress> = Array<PatientAddress>()
  // producers:Array<Producer> = Array<Producer>()

  ngOnInit(): void {
    this.router.navigate(['Home'])
    this.ptServ.getAll().subscribe(
      s =>{
        this.ptServ.all = s.filter(x=>x.Status==true)
        // alert("the patients were loaded successfully")
        console.log(s);
        
      },
      e=>{
        alert("there is error on patients loading:" + e)
      }
    )
    this.cvServ.getAll().subscribe(
      s =>{
        this.cvServ.all = s.filter(x=>x.Status==true)
        // alert("the corona vaccines were loaded successfully")
        console.log(s);
      },
      e=>{
        alert("there is error on corona vaccines loading:" + e)
      }
    )

    this.srlServ.getAll().subscribe(
      s =>{
        this.srlServ.all = s.filter(x=>x.Status==true)
        // alert("the serologions were loaded successfully")
        console.log(s);
      },
      e=>{
        alert("there is error on serologions loading:" + e)
      }
    )

    this.adsServ.getAll().subscribe(
      s =>{
        this.adsServ.all = s
        // alert("the patients addresses were loaded successfully")
        console.log(s);
      },
      e=>{
        alert("there is error on patients addresses loading:" + e)
      }
    )

    this.vccServ.getAll().subscribe(
      s =>{
        this.vccServ.all = s
        // alert("the vaccines were loaded successfully")
        console.log(s);
      },
      e=>{
        alert("there is error on vaccines loading:" + e)
      }
    )

    this.pdServ.getAll().subscribe(
      s =>{
        this.pdServ.all = s
        // alert("the producers were loaded successfully")
        console.log(s);
      },
      e=>{
        alert("there is error on producers loading:" + e)
      }
    )


  }

  route_menu(item:string){
    this.router.navigate([item])
  }

}
