import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { CoronaVaccine } from 'src/app/classes/CoronaVaccine';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CoronaVaccinesService {

  constructor(public http:HttpClient) { }
  
  basicURL:string = 'https://localhost:7191/api/CoronaVaccines_crl/'

  all:Array<CoronaVaccine> = Array<CoronaVaccine>()
  // ngOnInit(): void {
  //   this.getAll().subscribe(
  //     s =>{
  //       this.all = s
  //       alert("the corona vaccines were loaded successfully")
  //     },
  //     e=>{
  //       alert("there is error on corona vaccines loading:" + e)
  //     }
  //   )
  // }

  create(cv:CoronaVaccine):Observable<string>{
    return this.http.post<string>(`${this.basicURL}CreateCoronaVaccine`, cv)
  }

  get(id:string):Observable<CoronaVaccine>{
    return this.http.get<CoronaVaccine>(`${this.basicURL}GetCoronaVaccine/${id}`)
  }

  getAll():Observable<Array<CoronaVaccine>>{
    return this.http.get<Array<CoronaVaccine>>(`${this.basicURL}GetAllCoronaVaccines`)
  }

  delete(id:string):Observable<boolean>{
    return this.http.delete<boolean>(`${this.basicURL}DeleteCoronaVaccine/${id}`)
  }

  update(cv:CoronaVaccine):Observable<boolean>{
    return this.http.put<boolean>(`${this.basicURL}UpdateCoronaVaccine`,cv)
  }
}
