import { Component, Input } from '@angular/core';
import { CoronaVaccine } from 'src/app/classes/CoronaVaccine';
import { Producer } from 'src/app/classes/Producter';
import { Serologion } from 'src/app/classes/Serologion';
import { Vaccine } from 'src/app/classes/Vaccine';
import { CoronaVaccinesService } from 'src/assets/services/corona-vaccines.service';
import { ProducerService } from 'src/assets/services/producer.service';
import { SerologicService } from 'src/assets/services/serologic.service';
import { VaccineService } from 'src/assets/services/vaccine.service';

@Component({
  selector: 'app-covid-details',
  templateUrl: './covid-details.component.html',
  styleUrls: ['./covid-details.component.css']
})
export class CovidDetailsComponent {
  constructor(
    public cvServ:CoronaVaccinesService,
    public srlServ:SerologicService,
    public vccServ:VaccineService,
    public pdServ:ProducerService
    ){}

  id:string = ''
  serologic?:Serologion = undefined
  corona_vaccines?:CoronaVaccine = undefined
  vaccines: Array<Vaccine> = Array<Vaccine>()
  producers:Array<Producer> = Array<Producer>()
  
  @Input() Patientid:string =''
  ngOnInit(): void {

    debugger
    this.srlServ.get(this.Patientid).subscribe(
      s=>{
        this.serologic = s
      },
      e=>{
        alert("cannot get the "+this.id+"serologic"+e)
        this.serologic = this.srlServ.all.find(x=> x.Id == this.id)
        console.log(this.serologic)
      }
    )
    this.cvServ.get(this.Patientid).subscribe(
      s=>{
        this.corona_vaccines = s
        let vacs = [this.corona_vaccines?.Vac1,this.corona_vaccines?.Vac2,this.corona_vaccines?.Vac3,this.corona_vaccines?.Vac4]

  debugger
  //חילוץ נתונים חיסונים ויצרנים
    for (let index = 0; index < 4; index++) {
      let vcc = this.vccServ.all.find(x=>x.Id == vacs[index])
      let prod = this.pdServ.all.find(x=>x.Id == vcc?.Producter)
      if(vacs[index]!=undefined&&vcc!=undefined){
        this.vaccines.push(vcc)
        if(prod!=undefined) 
        this.producers.push(prod)
        else 
        this.producers.push(new Producer())
      }
    }
      },
      e=>{
        alert("cannot get the "+this.id+"corona vaccines"+e)
        this.corona_vaccines = this.cvServ.all.find(x=> x.Id == this.id)
        console.log(this.corona_vaccines)
      }
    )
 
  

  }
}
