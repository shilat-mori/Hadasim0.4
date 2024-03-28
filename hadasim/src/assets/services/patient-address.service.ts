import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PatientAddress } from 'src/app/classes/PatientAddress';

@Injectable({
  providedIn: 'root'
})
export class PatientAddressService {

  constructor(public http:HttpClient) { }
  basicURL:string = 'https://localhost:7191/api/PatientsAddresses_crl/'

  all:Array<PatientAddress> = Array<PatientAddress>()
  // ngOnInit(): void {
  //   this.getAll().subscribe(
  //     s =>{
  //       this.all = s
  //       alert("the patients addresses were loaded successfully")
  //     },
  //     e=>{
  //       alert("there is error on patient addresses loading:" + e)
  //     }
  //   )
  // }

  create(pt:PatientAddress):Observable<number>{
    return this.http.post<number>(`${this.basicURL}CreatePatientAddress`,pt)
  }

  get(id:number):Observable<PatientAddress>{
    return this.http.get<PatientAddress>(`${this.basicURL}GetPatientAddress/${id}`)
  }

  getAll():Observable<Array<PatientAddress>>{
    return this.http.get<Array<PatientAddress>>(`${this.basicURL}GetAllPatientsAddresses`)
  }

  delete(id:number):Observable<boolean>{
    return this.http.delete<boolean>(`${this.basicURL}DeletePatientAddress/${id}`)
  }

  update(pt:PatientAddress):Observable<boolean>{
    return this.http.put<boolean>(`${this.basicURL}UpdatePatientAddress`,pt)
  }
}
