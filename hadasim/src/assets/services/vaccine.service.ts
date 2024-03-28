import { HttpBackend, HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Vaccine } from 'src/app/classes/Vaccine';

@Injectable({
  providedIn: 'root'
})
export class VaccineService{

  constructor(public http:HttpClient) { }
  basicURL:string = 'https://localhost:7191/api/Vaccines_crl/'

  all:Array<Vaccine> = Array<Vaccine>()
  // ngOnInit(): void {
  //   this.getAll().subscribe(
  //     s =>{
  //       this.all = s
  //       alert("the vaccines were loaded successfully")
  //     },
  //     e=>{
  //       alert("there is error on vaccines loading:" + e)
  //     }
  //   )
  // }

  create(pd:Vaccine):Observable<number>{
    return this.http.post<number>(`${this.basicURL}CreateVaccine`,pd)
  }

  get(id:number):Observable<Vaccine>{
    return this.http.get<Vaccine>(`${this.basicURL}GetVaccine/${id}`)
  }

  getAll():Observable<Array<Vaccine>>{
    return this.http.get<Array<Vaccine>>(`${this.basicURL}GetAllVaccines`)
  }

  delete(id:number):Observable<boolean>{
    return this.http.delete<boolean>(`${this.basicURL}DeleteVaccine/${id}`)
  }

  update(pd:Vaccine):Observable<boolean>{
    return this.http.put<boolean>(`${this.basicURL}UpdateVaccine`,pd)
  }
}
