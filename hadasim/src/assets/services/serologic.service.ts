import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Serologion } from 'src/app/classes/Serologion';

@Injectable({
  providedIn: 'root'
})
export class SerologicService{

  constructor(public http:HttpClient) { }
  basicURL:string = 'https://localhost:7191/api/Serologions_crl/'

  all:Array<Serologion> = Array<Serologion>()
  // ngOnInit(): void {
  //   this.getAll().subscribe(
  //     s =>{
  //       this.all = s
  //       alert("the serologions were loaded successfully")
  //     },
  //     e=>{
  //       alert("there is error on serologions loading:" + e)
  //     }
  //   )
  // }

  create(srl:Serologion):Observable<string>{
    return this.http.post<string>(`${this.basicURL}CreateSerologion`, srl)
  }

  get(id:string):Observable<Serologion>{
    return this.http.get<Serologion>(`${this.basicURL}GetSerologion/${id}`)
  }

  getAll():Observable<Array<Serologion>>{
    return this.http.get<Array<Serologion>>(`${this.basicURL}GetAllSerologions`)
  }

  delete(id:string):Observable<boolean>{
    return this.http.delete<boolean>(`${this.basicURL}DeleteSerologion/${id}`)
  }

  update(cv:Serologion):Observable<boolean>{
    return this.http.put<boolean>(`${this.basicURL}UpdateSerologion`,cv)
  }

  getLastMonthSicks():Observable<Array<number>>{
    return this.http.get<Array<number>>(`${this.basicURL}GetLastMonthSicks`)
  }

  getUnVaccinated():Observable<number>{
    return this.http.get<number>(`${this.basicURL}GetUnVaccinated`)
  }
}
