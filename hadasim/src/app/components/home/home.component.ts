import { Component, OnInit } from '@angular/core';
import { ChartsModule } from 'ng2-charts';
import { SerologicService } from 'src/assets/services/serologic.service';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{
  constructor(public srlServ:SerologicService){}
  sicksLastMonth:Array<number> = Array<number>()
  unVaccinated:number = 0

  ngOnInit(): void {
    this.srlServ.getLastMonthSicks().subscribe(
      s=>{
        debugger
        this.sicksLastMonth = s
        this.srlServ.getUnVaccinated().subscribe(
          vc=>{
            this.unVaccinated = vc
          }
        )
      }
    )

    
  }

}
